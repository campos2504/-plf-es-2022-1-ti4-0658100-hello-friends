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
    [Route("api/respostasOpcaoCerta")]
    public class RespostasOpcaoCertaController : ControllerBase
    {
        private IRespostasOpcaoCertaBusiness _respostasBusiness;

        public RespostasOpcaoCertaController(IRespostasOpcaoCertaBusiness respostasBusiness)
        {
            _respostasBusiness = respostasBusiness;
        }

        [ClaimsAuthorize("respostasopcerta", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<RespostasOpcaoCerta> respotas = _respostasBusiness.FindAll();
            return Ok(respotas);
        }

        [ClaimsAuthorize("respostasopcerta", "retornar")]
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

        [ClaimsAuthorize("respostasopcerta", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] RespostasOpcaoCertaViewModel respostas)
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

        [ClaimsAuthorize("respostasopcerta", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] RespostasOpcaoCertaViewModel respostas)
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

        [ClaimsAuthorize("respostasopcerta", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _respostasBusiness.Delete(id);

            return NoContent();
        }
    }
}

