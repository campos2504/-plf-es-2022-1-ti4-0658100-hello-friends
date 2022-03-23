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
    [Route("api/completar-frase")]
    public class CompletarFrasesController : ControllerBase
    {
        private ICompletaFraseBusiness _completaFraseBusiness;

        public CompletarFrasesController(ICompletaFraseBusiness completaFraseBusiness)
        {
            _completaFraseBusiness = completaFraseBusiness;
        }

        [ClaimsAuthorize("completarfrase", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<CompletaFrase> resultado = _completaFraseBusiness.FindAll();

            return Ok(resultado);
        }

        [ClaimsAuthorize("completarfrase", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var completaFrase = _completaFraseBusiness.FindByID(id);

            if (completaFrase == null)
            {
                return NotFound();
            }

            return Ok(completaFrase);
        }

        [ClaimsAuthorize("completarfrase", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] CompletaFraseCreateViewModel completaFrase) {

            if (completaFrase == null || !ModelState.IsValid) return BadRequest();

            return Ok(_completaFraseBusiness.Create(completaFrase));
        }

        [ClaimsAuthorize("completarfrase", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] CompletaFraseCreateViewModel completaFrase)
        {
            if (!ModelState.IsValid) {
                return BadRequest(new {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            return Ok(_completaFraseBusiness.Update(completaFrase));
        }

        [ClaimsAuthorize("completarfrase", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _completaFraseBusiness.Delete(id);
            return NoContent();
        }
    }
}
