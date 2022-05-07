using HelloFriendsAPI.Business.Implementations;
using HelloFriendsAPI.Extensions;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace HelloFriendsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/medalha")]
    public class MedalhaController : ControllerBase
    {
        private IMedalhaBusiness _medalhaBusiness;

        public MedalhaController(IMedalhaBusiness medalhaBusiness)
        {
            _medalhaBusiness = medalhaBusiness;
        }

        [ClaimsAuthorize("medalha", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<Medalha> respotas = _medalhaBusiness.FindAll();
            return Ok(respotas);
        }

        [ClaimsAuthorize("medalha", "retornar")]
        [HttpGet("{idModulo}/{idAluno}")]
        public IActionResult GetModuloAluno(long idModulo, long idAluno)
        {
            var respostas = _medalhaBusiness.FindByModuloAluno(idModulo, idAluno);

            if (respostas == null)
            {
                return NotFound();
            }

            return Ok(respostas);
        }

        [ClaimsAuthorize("medalha", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] MedalhaViewModel medalhas)
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

            if (medalhas == null) return BadRequest();
                
            return Ok(_medalhaBusiness.Create(medalhas));
        }

        [ClaimsAuthorize("medalha", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] MedalhaViewModel medalhas)
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

            if (medalhas == null) return BadRequest();
           
            return Ok(_medalhaBusiness.Update(medalhas));

        }

        [ClaimsAuthorize("medalha", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _medalhaBusiness.Delete(id);

            return NoContent();
        }
    }
}

