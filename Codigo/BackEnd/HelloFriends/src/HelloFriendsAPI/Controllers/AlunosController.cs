using HelloFriendsAPI.Business;
using HelloFriendsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using HelloFriendsAPI.Extensions;

namespace HelloFriendsAPI.Controllers {

    [Authorize]
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase{

        private IAlunoBusiness _alunoBusiness;

        public AlunosController(IAlunoBusiness alunoBusiness) {
            _alunoBusiness = alunoBusiness;
        }

        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet]
        public IActionResult Get() {
            List<Aluno> alunos = _alunoBusiness.FindAll();
            var resultado = alunos.Select(x => new Aluno
            {
                Id = x.Id,
                NomeCompleto = x.NomeCompleto,
                NomeResponsavel = x.NomeResponsavel,
                Email = x.Email,
                DataAniversario = x.DataAniversario,
                Imagem = x.Imagem,
                Status = x.Status,
                Situacao = x.Situacao,
                ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Imagem)
            });
            return Ok(resultado);
        }

        [ClaimsAuthorize("gestaoalunos", "retornar")]
        [HttpGet("{id}")]
        public IActionResult Get(long id) {

            var aluno = _alunoBusiness.FindByID(id);
            if (aluno == null) {
                return NotFound();
            }

            return Ok(aluno);
        }

        [ClaimsAuthorize("gestaoalunos", "atualizar")]
        public IActionResult Put([FromBody] Aluno aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_alunoBusiness.Update(aluno));
        }

        [ClaimsAuthorize("gestaoalunos", "excluir")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {

            _alunoBusiness.Delete(id);
            return NoContent();
        }

    }
}
