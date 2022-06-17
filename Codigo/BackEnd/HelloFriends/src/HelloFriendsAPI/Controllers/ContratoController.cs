using HelloFriendsAPI.Business;
using HelloFriendsAPI.Extensions;
using HelloFriendsAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace HelloFriendsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/contrato")]
    public class ContratoController : ControllerBase
    {
        private IContratoBusiness _contratoBusiness;

        public ContratoController(IContratoBusiness contratoBusiness)
        {
            _contratoBusiness = contratoBusiness;
        }

        [ClaimsAuthorize("contrato", "retornar")]
        [HttpGet]
        public IActionResult Get()
        {
            List<Contrato> respotas = _contratoBusiness.FindAll();
            return Ok(respotas);
        }


        [ClaimsAuthorize("contrato", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            var modulo = _contratoBusiness.FindByID(id);
            if (modulo == null)
            {
                return NotFound();
            }

            return Ok(modulo);
        }

        [ClaimsAuthorize("contrato", "criar")]
        [HttpPost]
        public IActionResult Post([FromBody] Contrato contrato)
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

            if (contrato == null) return BadRequest();
                
            return Ok(_contratoBusiness.Create(contrato));
        }

        [ClaimsAuthorize("contrato", "editar")]
        [HttpPut]
        public IActionResult Put([FromBody] Contrato contrato)
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

            if (contrato == null) return BadRequest();
           
            return Ok(_contratoBusiness.Update(contrato));

        }

        [ClaimsAuthorize("contrato", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _contratoBusiness.Delete(id);

            return NoContent();
        }
    }
}

