using HelloFriendsAPI.Business;
using HelloFriendsAPI.Business.Implementations;
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
    [Route("api/respostasCompletaTexto")]
    public class RespostasCompletaTextoController : ControllerBase
    {
        private IRespostasCompletaTextoBusiness _respostasBusiness;

        public RespostasCompletaTextoController(IRespostasCompletaTextoBusiness respostasBusiness)
        {
            _respostasBusiness = respostasBusiness;
        }

        [ClaimsAuthorize("respostascomptexto", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<RespostasCompletaTexto> respotas = _respostasBusiness.FindAll();
            return Ok(respotas);
        }

        [ClaimsAuthorize("respostascomptexto", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var respostas = _respostasBusiness.FindByID(id);

            if (respostas == null)
            {
                return NotFound();
            }

            return Ok(respostas);
        }

        [ClaimsAuthorize("respostascomptexto", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] RespostasCompletaTextoViewModel respostas)
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

            if (respostas == null) return BadRequest();
                
            return Ok(_respostasBusiness.Create(respostas));
        }

        [ClaimsAuthorize("respostascomptexto", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] RespostasCompletaTextoViewModel respostas)
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

            if (respostas == null) return BadRequest();
           
            return Ok(_respostasBusiness.Update(respostas));

        }

        [ClaimsAuthorize("respostascomptexto", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _respostasBusiness.Delete(id);

            return NoContent();
        }
    }
}

