using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class RespostasOpcaoCertaRepositoryImplementation : IRespostasOpcaoCertaRepository
    {
        private HelloFriendsContext _context;

        public RespostasOpcaoCertaRepositoryImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public RespostasOpcaoCerta Create(RespostasOpcaoCerta respostasOpcaoCerta)
        {
            try
            {
                _context.Add(respostasOpcaoCerta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return respostasOpcaoCerta;
        }

        public void Delete(long id)
        {
            var result = _context.RespostasOpcaoCerta.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.RespostasOpcaoCerta.Remove(result);
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
            return _context.RespostasOpcaoCerta.Any(p => p.Id.Equals(id));
        }

        public List<RespostasOpcaoCerta> FindAll()
        {
            return _context.RespostasOpcaoCerta.ToList();
        }

        public RespostasOpcaoCerta FindByAlunoAtividade(long idAluno, Guid idAtividade)
        {
            return _context.RespostasOpcaoCerta.SingleOrDefault(p => p.AlunoId.Equals(idAluno) && p.OpcaoCertaID.Equals(idAtividade));

        }

        public RespostasOpcaoCerta FindByID(long id)
        {
            return _context.RespostasOpcaoCerta.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<RespostasOpcaoCerta> FindByModuloAluno(long idModulo, long idAluno)
        {
            return _context.RespostasOpcaoCerta.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
        }

        public RespostasOpcaoCerta Update(RespostasOpcaoCerta respostasOpcaoCerta)
        {
            if (!Exists(respostasOpcaoCerta.Id)) return null;

            var result = _context.VerdadeiroFalso.SingleOrDefault(p => p.Id.Equals(respostasOpcaoCerta.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(respostasOpcaoCerta);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return respostasOpcaoCerta;
        }

        
    }
}
