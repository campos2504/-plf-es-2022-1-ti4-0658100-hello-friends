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
    [Route("api/respostasvf")]
    public class RespostasVFController : ControllerBase
    {
        private IRespostasVFBusiness _respostasVFBusiness;

        public RespostasVFController(IRespostasVFBusiness respostasVFBusiness)
        {
            _respostasVFBusiness = respostasVFBusiness;
        }

        [ClaimsAuthorize("respostasvf", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<RespostasVF> respotasVF = _respostasVFBusiness.FindAll();
            return Ok(respotasVF);
        }

        [ClaimsAuthorize("respostasvf", "retornar")]
        [HttpGet("{idModulo}/{idAluno}")]
        public IActionResult GetModuloAluno(long idModulo, long idAluno)
        {
            var respostas = _respostasVFBusiness.FindByModuloAluno(idModulo, idAluno);

            if (respostas == null)
            {
                return NotFound();
            }

            return Ok(respostas);
        }

        [ClaimsAuthorize("respostasvf", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] RespostasVFViewModel respostasVF)
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

            if (respostasVF == null) return BadRequest();
                
            return Ok(_respostasVFBusiness.Create(respostasVF));
        }

        [ClaimsAuthorize("respostasvf", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] RespostasVFViewModel respostasVF)
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

            if (respostasVF == null) return BadRequest();
           
            return Ok(_respostasVFBusiness.Update(respostasVF));

        }

        [ClaimsAuthorize("respostasvf", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _respostasVFBusiness.Delete(id);

            return NoContent();
        }
    }
}

