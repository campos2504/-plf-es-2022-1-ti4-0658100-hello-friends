using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
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
            return _context.RespostasCompletaTexto.ToList();
        }

        public RespostasCompletaTexto FindByID(long id)
        {
            return _context.RespostasCompletaTexto.SingleOrDefault(p => p.Id.Equals(id));
        }

        public RespostasCompletaTexto Update(RespostasCompletaTexto respostasCompletaTexto)
        {
            if (!Exists(respostasCompletaTexto.Id)) return null;

            var result = _context.VerdadeiroFalso.SingleOrDefault(p => p.Id.Equals(respostasCompletaTexto.Id));

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
