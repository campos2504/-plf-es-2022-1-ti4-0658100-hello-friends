using HelloFriendsAPI.Business;
using HelloFriendsAPI.Extensions;
using HelloFriendsAPI.Helpers;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloFriendsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/verdadeiro-falso")]
    public class VerdadeiroFalsoController : ControllerBase
    {
        private IVerdadeiroFalsoBusiness _verdadeiroFalsoBusiness;

        public VerdadeiroFalsoController(IVerdadeiroFalsoBusiness verdadeiroFalsoBusiness)
        {
            _verdadeiroFalsoBusiness = verdadeiroFalsoBusiness;
        }

        [ClaimsAuthorize("verdadeirofalso", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<VerdadeiroFalso> verdadeiroFalsos = _verdadeiroFalsoBusiness.FindAll();
            var resultado = verdadeiroFalsos.Select(x => new 
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Texto = x.Texto,
                Video = x.Video,
                Pergunta = x.Pergunta,
                AlternativaCerta = x.AlternativaCerta,
                ModuloId =x.ModuloId,
                Imagem = x.Imagem,
                ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Imagem)
            });
            return Ok(resultado);
        }

        [ClaimsAuthorize("verdadeirofalso", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var verdadeiroFalso = _verdadeiroFalsoBusiness.FindByID(id);

            if (verdadeiroFalso == null)
            {
                return NotFound();
            }

            return Ok(verdadeiroFalso);
        }

        [ClaimsAuthorize("verdadeirofalso", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] VerdadeiroFalsoCreateViewModel verdadeiroFalso)
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

            /*if (modulo == null) return BadRequest();*/

            var imagemVerdadeiroFalso = Guid.NewGuid() + "_" + verdadeiroFalso.Imagem;
            verdadeiroFalso.Imagem = imagemVerdadeiroFalso;

            UploadArquivo(verdadeiroFalso.ImagemSrc, imagemVerdadeiroFalso);
                
            return Ok(_verdadeiroFalsoBusiness.Create(verdadeiroFalso));
        }

        [ClaimsAuthorize("verdadeirofalso", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] VerdadeiroFalsoCreateViewModel verdadeiroFalso)
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

            /*if (modulo == null) return BadRequest();*/

            var imagemVerdadeiroFalso = Guid.NewGuid() + "_" + verdadeiroFalso.Imagem;
            verdadeiroFalso.Imagem = imagemVerdadeiroFalso;

            UploadArquivo(verdadeiroFalso.ImagemSrc, imagemVerdadeiroFalso);
           
            return Ok(_verdadeiroFalsoBusiness.Update(verdadeiroFalso));

        }

        [ClaimsAuthorize("verdadeirofalso", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _verdadeiroFalsoBusiness.Delete(id);

            return NoContent();
        }

        private bool UploadArquivo(string arquivoVerdadeiroFalso, string imagemVerdadeiroFalso)
        {
            Regex extensionsAllowed = new Regex(@"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)");
            var matchesVerdadeiroFalso = extensionsAllowed.Matches(imagemVerdadeiroFalso);

            if (string.IsNullOrEmpty(arquivoVerdadeiroFalso) || matchesVerdadeiroFalso.Count == 0)
            {
                return false;
            }

            var imageDataByteArrayVerdadeiroFalso = Convert.FromBase64String(arquivoVerdadeiroFalso);

            CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here

            var filePathVerdadeiroFalso = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imagemVerdadeiroFalso);

            if (System.IO.File.Exists(filePathVerdadeiroFalso))
            {
                return false;
            }
            System.IO.File.WriteAllBytes(filePathVerdadeiroFalso, imageDataByteArrayVerdadeiroFalso);

            return true;
        }

    }
}

