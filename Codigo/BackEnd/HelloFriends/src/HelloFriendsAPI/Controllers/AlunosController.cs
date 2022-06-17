using HelloFriendsAPI.Business;
using HelloFriendsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using HelloFriendsAPI.Extensions;
using HelloFriendsAPI.ViewModels;
using System.Text.RegularExpressions;
using HelloFriendsAPI.Helpers;
using System.IO;

namespace HelloFriendsAPI.Controllers {

    [Authorize]
    [ApiController]
    [Route("api/alunos")]

    public class AlunosController : ControllerBase{

        private IAlunoBusiness _alunoBusiness;

        public AlunosController(IAlunoBusiness alunoBusiness) {
            _alunoBusiness = alunoBusiness;
        }

        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet]
        public IActionResult Get() {
            List<Aluno> alunos = _alunoBusiness.FindAll();
            var resultado = alunos.Select(x => new Aluno
            {
                Id = x.Id,
                NomeCompleto = x.NomeCompleto,
                NomeResponsavel = x.NomeResponsavel,
                Email = x.Email,
                DataAniversario = x.DataAniversario,
                Imagem = x.Imagem,
                Status = x.Status,
                Situacao = x.Situacao,
                ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Imagem)
            });
            return Ok(resultado);
        }
        
        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet("media")]
        public IActionResult GetMedia()
        {
            List<AlunoMediaViewModel> alunoMedia = _alunoBusiness.GetMedia();
            var resultado = alunoMedia.Select(x => new AlunoMediaViewModel()
            {
                Id = x.Id,
                NomeCompleto = x.NomeCompleto,
                Media = x.Media,
                TotalAtividades = x.TotalAtividades,
                AtividadesFeitas = x.AtividadesFeitas
            });
            return Ok(resultado);
        }
        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet("notas/{id}")]
        public IActionResult GetNotasAluno(long id)
        {
            List<AlunoAtividadeViewModel> alunoAtividade = _alunoBusiness.GetResultadoAtividadeViewModels(id);
            var resultado = alunoAtividade.Select(x => new AlunoAtividadeViewModel()
            {
                IdAluno = x.IdAluno,
                NomeCompleto = x.NomeCompleto,
                IdModulo=x.IdModulo,
                NomeModulo=x.NomeModulo,
                NomeAtividade=x.NomeAtividade,
                Resultado=x.Resultado
            });
            return Ok(resultado);
        }

        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(long id) {

            var aluno = _alunoBusiness.FindByID(id);
            aluno.ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, aluno.Imagem);
            if (aluno == null) {
                return NotFound();
            }

            return Ok(aluno);
        }

        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {

            var aluno = _alunoBusiness.FindByEmail(email);

            if (email != "joyce@gmail.com")
            {
                aluno.ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, aluno.Imagem);
            }            

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [ClaimsAuthorize("gestaoalunos", "atualizar")]
        public IActionResult Put([FromBody] AlunoViewModel aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            if(aluno.Imagem != null)
            {
                var imagemNomeAluno = Guid.NewGuid() + "_" + aluno.Imagem;
                aluno.Imagem = imagemNomeAluno;

                if (!UploadArquivo(aluno.ImagemUpload, imagemNomeAluno))
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Não foi possivel fazer upload da imagem",
                    });
                }
            }                

            return Ok(_alunoBusiness.Update(aluno));
        }

        [ClaimsAuthorize("gestaoalunos", "atualizar")]
        [HttpPut("autorizar/{id}")]
        public IActionResult Autorizar(long id, [FromBody] AlunoAuthViewModel aluno)
        {

            return Ok(_alunoBusiness.Autorizar(id, aluno));
        }

        [ClaimsAuthorize("gestaoalunos", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {

            _alunoBusiness.Delete(id);
            return NoContent();
        }

        private bool UploadArquivo(string arquivoModulo, string imgNomeModulo)
        {
            Regex extensionsAllowed = new Regex(@"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)");
            var matchesModulo = extensionsAllowed.Matches(imgNomeModulo);

            if (string.IsNullOrEmpty(arquivoModulo) || matchesModulo.Count == 0)
            {
                return false;
            }

            var imageDataByteArrayModulo = Convert.FromBase64String(arquivoModulo);

            CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here

            var filePathModulo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imgNomeModulo);

            if (System.IO.File.Exists(filePathModulo))
            {
                return false;
            }
            System.IO.File.WriteAllBytes(filePathModulo, imageDataByteArrayModulo);

            return true;
        }

    }
}
