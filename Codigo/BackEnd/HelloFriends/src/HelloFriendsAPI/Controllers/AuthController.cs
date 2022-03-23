using HelloFriendsAPI.Business;
using HelloFriendsAPI.Extensions;
using HelloFriendsAPI.Helpers;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Controllers {

    [Route("api/autenticacao")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private IAlunoBusiness _alunoBusiness;

        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IAlunoBusiness alunoBusiness)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _alunoBusiness = alunoBusiness;
            _appSettings = appSettings.Value;
        }

        [HttpPost("registrar-aluno")]
        public async Task<ActionResult> RegistrarAluno([FromBody] AlunoViewModel registerAluno) {
            if (!ModelState.IsValid) {
                return BadRequest(new {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            var user = new IdentityUser {
                UserName = registerAluno.Email,
                Email = registerAluno.Email,
                EmailConfirmed = true
            };

            if (!string.IsNullOrEmpty(registerAluno.Imagem))
            {
                var imagemNome = Guid.NewGuid() + "_" + registerAluno.Imagem;
                registerAluno.Imagem = imagemNome;

                if (!UploadArquivo(registerAluno.ImagemUpload, imagemNome))
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Não foi possivel fazer upload da imagem",
                    });
                }
            }

            var result = await _userManager.CreateAsync(user, registerAluno.Senha);

            if (result.Succeeded) {
                //Registro dos dados do aluno na tabela "Aluno"
                _alunoBusiness.Create(registerAluno);

                var moduloClaim = await _userManager.AddClaimAsync(user, new Claim("modulos", "retornar"));
                if (!moduloClaim.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({moduloClaim.ToString()}) ao usuário '{user.Id}'.");
                }

                var completarFraseClaim = await _userManager.AddClaimAsync(user, new Claim("completarfrase", "retornar,realizar"));
                if (!completarFraseClaim.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({completarFraseClaim.ToString()}) ao usuário '{user.Id}'.");
                }

                var opcacaoCertaClaim = await _userManager.AddClaimAsync(user, new Claim("opcaocerta", "retornar,realizar"));
                if (!opcacaoCertaClaim.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({opcacaoCertaClaim.ToString()}) ao usuário '{user.Id}'.");
                }

                return Ok(new {
                    success = true,
                });   
            }

            return BadRequest(new {
                success = false,
                errors = result.Errors,
            });
        }

        [HttpPost("registrar-professor")]
        public async Task<ActionResult> RegistrarProfessor(ProfessorViewModel registerProfessor) {
            if (!ModelState.IsValid) {
                return BadRequest(new {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            var user = new IdentityUser {
                UserName = registerProfessor.Email,
                Email = registerProfessor.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerProfessor.Senha);

            if (result.Succeeded) {
                var moduloClaim = await _userManager.AddClaimAsync(user, new Claim("modulos", "criar,editar,excluir,retornar"));
                if (!moduloClaim.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({moduloClaim.ToString()}) ao usuário '{user.Id}'.");
                }

                var completarFraseClaim = await _userManager.AddClaimAsync(user, new Claim("completarfrase", "criar,editar,excluir,retornar,realizar"));
                if (!completarFraseClaim.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({completarFraseClaim.ToString()}) ao usuário '{user.Id}'.");
                }

                var opcacaoCertaClaim = await _userManager.AddClaimAsync(user, new Claim("opcaocerta", "criar,editar,excluir,retornar,realizar"));
                if (!opcacaoCertaClaim.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({opcacaoCertaClaim.ToString()}) ao usuário '{user.Id}'.");
                }

                var gestaoaluno = await _userManager.AddClaimAsync(user, new Claim("gestaoalunos", "retornar,excluir,atualizar"));
                if (!gestaoaluno.Succeeded)
                {
                    throw new InvalidOperationException($"Erro ao associar claim" + $" ({gestaoaluno.ToString()}) ao usuário '{user.Id}'.");
                }

                return Ok(new {
                    success = true,
                });
            }

            return BadRequest(new {
                success = false,
                errors = result.Errors,
            });
        }


        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser) {

            if (!ModelState.IsValid) {
                return BadRequest(new {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            //Verifica se o usuário é um aluno
            var usuarioAluno = _alunoBusiness.FindAll()
                                             .SingleOrDefault(p => p.Email.Equals(loginUser.Email));

            //Se o usuário for um aluno, estiver com Status true e as corretas credencias realiza o login
            if (usuarioAluno != null)
            {
                if (usuarioAluno.Status == true)
                {
                    var loginAluno = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Senha, false, false);

                    if (loginAluno.Succeeded)
                    {
                        return Ok(new
                        {
                            success = true,
                            data = await GerarJwt(loginUser.Email, "aluno"),
                        });
                    }
                    else if (!loginAluno.Succeeded || loginAluno.IsLockedOut)
                    { 
                        return Unauthorized();
                    }
                }

                return Unauthorized();
            }

            var loginProfessor = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Senha, false, false);

            if (loginProfessor.Succeeded)
            {
                return Ok(new {
                    success = true,
                    data = await GerarJwt(loginUser.Email, "professor"),
            });
            }

            if (loginProfessor.IsLockedOut) return Unauthorized();

            return Unauthorized();
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            Regex extensionsAllowed = new Regex(@"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)");
            var matches = extensionsAllowed.Matches(imgNome);

            if (string.IsNullOrEmpty(arquivo) || matches.Count == 0) return false;

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imgNome);

            if (System.IO.File.Exists(filePath)) return false;

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

        private async Task<LoginResponseViewModel> GerarJwt(string email, string userType)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserType = userType,
                User = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
