using HelloFriendsAPI.Business;
using HelloFriendsAPI.Extensions;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFriendsAPI.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/completar-texto")]
    public class CompletarTextoController : ControllerBase
    {
        private ICompletaTextoBusiness _completaTextoBusiness;

        public CompletarTextoController(ICompletaTextoBusiness completaTextoBusiness)
        {
            _completaTextoBusiness = completaTextoBusiness;
        }

        [ClaimsAuthorize("completartexto", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<CompletaTexto> resultado = _completaTextoBusiness.FindAll();

            return Ok(resultado);
        }

        [ClaimsAuthorize("completartexto", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var completaTexto = _completaTextoBusiness.FindByID(id);

            if (completaTexto == null)
            {
                return NotFound();
            }

            return Ok(completaTexto);
        }

        [ClaimsAuthorize("completartexto", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] CompletaTextoCreateViewModel completaTexto)
        {

            if (completaTexto == null || !ModelState.IsValid) return BadRequest();

            return Ok(_completaTextoBusiness.Create(completaTexto));
        }

        [ClaimsAuthorize("completartexto", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] CompletaTextoCreateViewModel completaTexto)
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

            return Ok(_completaTextoBusiness.Update(completaTexto));
        }

        [ClaimsAuthorize("completartexto", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _completaTextoBusiness.Delete(id);
            return NoContent();
        }
    }
}
