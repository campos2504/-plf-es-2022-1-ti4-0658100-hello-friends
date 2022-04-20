using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class CompletaTextoRepositoryImplementation : ICompletaTextoRepository
    {
        private HelloFriendsContext _context;

        public CompletaTextoRepositoryImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public CompletaTexto Create(CompletaTexto completaTexto)
        {
            try
            {
                _context.Add(completaTexto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return completaTexto;
        }

        public void Delete(Guid id)
        {

            var result = _context.CompletaTexto.SingleOrDefault(p => p.Id.Equals(id));

            /*var result2 = _context.CompletaFrase.OrderBy(e => e.Id).Include(e => e.PalavrasChaves).ToList();
            var result3 = result2.Single(e => e.Id.Equals(id));*/


            if (result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }



            /*if (result != null)
            {
                try
                {
                    _context.CompletaFrase.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }*/
        }

        public bool Exists(Guid id)
        {
            return _context.CompletaTexto.Any(p => p.Id.Equals(id));
        }

        public List<CompletaTexto> FindAll()
        {
            return _context.CompletaTexto.ToList();
        }

        public CompletaTexto FindByID(Guid id)
        {
            return _context.CompletaTexto.SingleOrDefault(p => p.Id.Equals(id));
        }

        public CompletaTexto Update(CompletaTexto completaTexto)
        {
            /*if (!Exists(completaFrase.Id)) return null;*/

            var result = _context.CompletaTexto.SingleOrDefault(p => p.Id.Equals(completaTexto.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(completaTexto);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return completaTexto;
        }
    }
}
