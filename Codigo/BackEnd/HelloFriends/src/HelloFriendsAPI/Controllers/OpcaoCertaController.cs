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
    [Route("api/[controller]")]
    public class OpcaoCertaController : ControllerBase
    {
        private IOpcaoCertaBusiness _opcaoCertaBusiness;

        public OpcaoCertaController(IOpcaoCertaBusiness opcaoCertaBusiness)
        {
            _opcaoCertaBusiness = opcaoCertaBusiness;
        }

        [ClaimsAuthorize("opcaocerta", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<OpcaoCerta> opcaoCerta = _opcaoCertaBusiness.FindAll();
            var resultado = opcaoCerta.Select(x => new OpcaoCerta
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Texto = x.Texto,
                Video = x.Video,
                Pergunta = x.Pergunta,
                AlternativaA = x.AlternativaA,
                AlternativaB = x.AlternativaB,
                AlternativaC = x.AlternativaC,
                AlternativaD = x.AlternativaD,
                AlternativaCerta = x.AlternativaCerta,
                ModuloId =x.ModuloId,
                Imagem = x.Imagem,
                ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Imagem)
            });
            return Ok(resultado);
        }

        [ClaimsAuthorize("opcaocerta", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var opcaoCerta = _opcaoCertaBusiness.FindByID(id);

            if (opcaoCerta == null)
            {
                return NotFound();
            }

            return Ok(opcaoCerta);
        }

        [ClaimsAuthorize("opcaocerta", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] OpcaoCertaCreateViewModel opcaoCerta)
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

            var imagemOpcaoCerta = Guid.NewGuid() + "_" + opcaoCerta.Imagem;
            opcaoCerta.Imagem = imagemOpcaoCerta;

            UploadArquivo(opcaoCerta.ImagemSrc, imagemOpcaoCerta);
                
            return Ok(_opcaoCertaBusiness.Create(opcaoCerta));
        }

        [ClaimsAuthorize("opcaocerta", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] OpcaoCertaCreateViewModel opcaoCerta)
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

            var imagemOpcaoCerta = Guid.NewGuid() + "_" + opcaoCerta.Imagem;
            opcaoCerta.Imagem = imagemOpcaoCerta;

            UploadArquivo(opcaoCerta.ImagemSrc, imagemOpcaoCerta);
           
            return Ok(_opcaoCertaBusiness.Update(opcaoCerta));

        }

        [ClaimsAuthorize("opcaocerta", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _opcaoCertaBusiness.Delete(id);

            return NoContent();
        }

        private bool UploadArquivo(string arquivoOpcaoCerta, string imgOpcaoCerta)
        {
            Regex extensionsAllowed = new Regex(@"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)");
            var matchesOpcaoCerta = extensionsAllowed.Matches(imgOpcaoCerta);

            if (string.IsNullOrEmpty(arquivoOpcaoCerta) || matchesOpcaoCerta.Count == 0)
            {
                return false;
            }

            var imageDataByteArrayOpcaoCerta = Convert.FromBase64String(arquivoOpcaoCerta);

            CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here

            var filePathOpcaoCerta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imgOpcaoCerta);

            if (System.IO.File.Exists(filePathOpcaoCerta))
            {
                return false;
            }
            System.IO.File.WriteAllBytes(filePathOpcaoCerta, imageDataByteArrayOpcaoCerta);

            return true;
        }

    }
}

