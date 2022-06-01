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

namespace HelloFriendsAPI.Controllers {

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ModulosController : ControllerBase{

        private IModuloBusiness _moduloBusiness;

        public ModulosController(IModuloBusiness moduloBusiness) {
            _moduloBusiness = moduloBusiness;
        }

        [ClaimsAuthorize("modulos", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<Modulo> modulos = _moduloBusiness.FindAll();
            var resultado = modulos.Select(x => new Modulo
            {
                Id = x.Id,
                NomeModulo = x.NomeModulo,
                Imagem = x.Imagem,
                ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Imagem)
            });
            return Ok(resultado);
        }

        [ClaimsAuthorize("modulos", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(long id) {

            var modulo = _moduloBusiness.FindByID(id);
            if (modulo == null) {
                return NotFound();
            }

            return Ok(modulo);
        }

        [ClaimsAuthorize("modulos", "retornar")]
        [HttpGet("medalha/{idModulo}/{idAluno}")]
        public IActionResult GetMedalha(long idModulo, long idAluno)
        {
            var respostas = _moduloBusiness.FindMedalha(idModulo, idAluno);

            if (respostas == null)
            {
                return NotFound();
            }

            return Ok(respostas);
        }


        [ClaimsAuthorize("modulos", "retornar")]
        [HttpGet("qtdModulosConcluidos")]
        public IActionResult FindMQtdModulosConcluidos()
        {
            var respostas = _moduloBusiness.FindMQtdModulosConcluidos();

            if (respostas == null)
            {
                return NotFound();
            }

            return Ok(respostas);
        }

        [ClaimsAuthorize("modulos", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] ModuloViewModel modulo) {

            if (!ModelState.IsValid) {
                return BadRequest(new {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            if (!string.IsNullOrEmpty(modulo.Imagem))
            {
                var imagemNomeModulo = Guid.NewGuid() + "_" + modulo.Imagem;
                modulo.Imagem = imagemNomeModulo;

                if (!UploadArquivo(modulo.ImagemUpload, imagemNomeModulo))
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Não foi possivel fazer upload da imagem",
                    });
                }
            }

            return Ok(_moduloBusiness.Create(modulo));            
        }

        [ClaimsAuthorize("modulos", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] ModuloViewModel modulo) {
            if (!ModelState.IsValid) {
                return BadRequest(new {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            var imagemNomeModulo = Guid.NewGuid() + "_" + modulo.Imagem;
            modulo.Imagem = imagemNomeModulo;

            if (!UploadArquivo(modulo.ImagemUpload, imagemNomeModulo)) {
                return BadRequest(new {
                    success = false,
                    errors = "Não foi possivel fazer upload da imagem",
                });
            }

            return Ok(_moduloBusiness.Update(modulo));
        }

        [ClaimsAuthorize("modulos", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            _moduloBusiness.Delete(id);

            return NoContent();
        }

        private bool UploadArquivo(string arquivoModulo, string imgNomeModulo) {
            Regex extensionsAllowed = new Regex(@"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)");
            var matchesModulo = extensionsAllowed.Matches(imgNomeModulo);

            if (string.IsNullOrEmpty(arquivoModulo) || matchesModulo.Count == 0) {
                return false;
            }

            var imageDataByteArrayModulo = Convert.FromBase64String(arquivoModulo);

            CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here

            var filePathModulo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imgNomeModulo);

            if (System.IO.File.Exists(filePathModulo)) {
                return false;
            }
            System.IO.File.WriteAllBytes(filePathModulo, imageDataByteArrayModulo);

            return true;
        }

    }
}
