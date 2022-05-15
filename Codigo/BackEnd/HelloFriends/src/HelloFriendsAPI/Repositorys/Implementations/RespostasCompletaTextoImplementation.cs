using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class RespostasCompletaTextoImplementation : IRespostasCompletaTextoRepository
    {
        private HelloFriendsContext _context;

        public RespostasCompletaTextoImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public RespostasCompletaTexto Create(RespostasCompletaTexto respostasCompletaTexto)
        {
            try
            {
                _context.Add(respostasCompletaTexto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return respostasCompletaTexto;
        }

        public void Delete(long id)
        {
            var result = _context.RespostasCompletaTexto.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.RespostasCompletaTexto.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        
        public bool Exists(long id)
        {
            return _context.RespostasCompletaTexto.Any(p => p.Id.Equals(id));
        }

        public List<RespostasCompletaTexto> FindAll()
        {
            var result = _context.RespostasCompletaTexto.Include(p => p.Aluno).Include(p => p.CompletaTexto).ToList();

            return result;
        }

        public RespostasCompletaTexto FindByAlunoAtividade(long idAluno, Guid idAtividade)
        {
            return _context.RespostasCompletaTexto.SingleOrDefault(p => p.AlunoId.Equals(idAluno) && p.CompletaTextoID.Equals(idAtividade));
        }

        public RespostasCompletaTexto FindByID(long id)
        {
            return _context.RespostasCompletaTexto.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<RespostasCompletaTexto> FindByModuloAluno(long idModulo, long idAluno)
        {
            return _context.RespostasCompletaTexto.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
        }

        public RespostasCompletaTexto Update(RespostasCompletaTexto respostasCompletaTexto)
        {
            if (!Exists(respostasCompletaTexto.Id)) return null;

            var result = _context.RespostasCompletaTexto.SingleOrDefault(p => p.Id.Equals(respostasCompletaTexto.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(respostasCompletaTexto);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return respostasCompletaTexto;
        }

        
    }
}
