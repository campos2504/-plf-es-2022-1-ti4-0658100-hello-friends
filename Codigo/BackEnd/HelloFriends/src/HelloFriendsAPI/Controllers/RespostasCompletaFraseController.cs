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
    [Route("api/respostasCompletaFrase")]
    public class RespostasCompletaFraseController : ControllerBase
    {
        private IRespostasCompletaFraseBusiness _respostasBusiness;

        public RespostasCompletaFraseController(IRespostasCompletaFraseBusiness respostasBusiness)
        {
            _respostasBusiness = respostasBusiness;
        }

        [ClaimsAuthorize("respostascompfrase", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<RespostasCompleFrase> respotas = _respostasBusiness.FindAll();
            return Ok(respotas);
        }

        [ClaimsAuthorize("respostascompfrase", "retornar")]
        [HttpGet("{idModulo}/{idAluno}")]
        public IActionResult GetModuloAluno(long idModulo, long idAluno)
        {
            var respostas = _respostasBusiness.FindByModuloAluno(idModulo, idAluno);

            if (respostas == null)
            {
                return NotFound();
            }

            return Ok(respostas);
        }

        [ClaimsAuthorize("respostascompfrase", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] RespostasCompleFraseViewModel respostas)
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

        [ClaimsAuthorize("respostascompfrase", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] RespostasCompleFraseViewModel respostas)
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

        [ClaimsAuthorize("respostascompfrase", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _respostasBusiness.Delete(id);

            return NoContent();
        }
    }
}

