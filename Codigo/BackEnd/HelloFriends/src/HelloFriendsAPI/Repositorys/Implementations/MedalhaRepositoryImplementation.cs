using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class MedalhaRepositoryImplementation : IMedalhaRepository
    {
        private HelloFriendsContext _context;

        public MedalhaRepositoryImplementation (HelloFriendsContext context)
        {
            _context = context;
        }

        public Medalha Create(Medalha medalha)
        {
            try
            {
                _context.Add(medalha);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return medalha;
        }

        public void Delete(long id)
        {
            var result = _context.Medalha.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Medalha.Remove(result);
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
            return _context.Medalha.Any(p => p.Id.Equals(id));
        }

        public List<Medalha> FindAll()
        {
            return _context.Medalha.ToList();
        }

        public Medalha FindByID(long id)
        {
            return _context.Medalha.SingleOrDefault(p => p.Id.Equals(id));
        }

   
        public Medalha FindByModuloAluno(long idModulo, long idAluno)
        {
           var medalha = _context.Medalha.Where(p => p.AlunoId.Equals(idAluno) && p.ModuloId.Equals(idModulo)).ToList();
           var medalha2 = medalha.FirstOrDefault(p => p.AlunoId.Equals(idAluno));
            return medalha2;
        }

        public Medalha Update(Medalha medalha)
        {
            if (!Exists(medalha.Id)) return null;

            var result = _context.Medalha.SingleOrDefault(p => p.Id.Equals(medalha.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(medalha);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return medalha;
        }

        
    }
}
