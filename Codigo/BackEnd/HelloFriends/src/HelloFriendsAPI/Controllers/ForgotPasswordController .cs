using HelloFriendsAPI.Business;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Services;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Controllers
{

    [Route("api/forgotpassword")]
    [ApiController]
    public class ForgotPassWordController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private IAlunoBusiness _alunoBusiness;
        private readonly IMailService _mailService;

        public ForgotPassWordController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager, IAlunoBusiness alunoBusiness, IMailService mailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _alunoBusiness = alunoBusiness;
            _mailService = mailService;

        }

        //api/forgotpassword/recoveryEmail
        [HttpPost("recoveryEmail")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(await user);
                    var resetUrl = "http://127.0.0.1:5500/Codigo/FrontEnd/resetSenha.html?token=" + token + "&email=" + model.Email;
                    MailRequest request = new MailRequest() ;
                    request.ToEmail = model.Email; request.Subject = "Recuperação de Senha"; request.Body = resetUrl;
                    try
                    {
                        await _mailService.SendEmailAsync(request);
                        return Ok(new
                        {
                            success = true,
                           });
                    }
                    catch (Exception e)
                    {
                        return BadRequest(new
                        {
                            exception=e.Message,
                            success = false,
                            errors = "Não foi possivel enviar o Email",
                        });
                    }
                    
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Não foi possivel encontar o Email",
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Model Invalid",
                });
            }


        }


        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(await user,
                        model.Token, model.Password);
                    if (!result.Succeeded)
                    {
                        return BadRequest(new
                        {
                            success = false,
                            errors = result.Errors,
                        });
                    }

                    return Ok(new
                    {
                        success = true

                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Não foi possivel encontar o Usuario",
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Model Invalid",
                });
            }

        }


    }
}
