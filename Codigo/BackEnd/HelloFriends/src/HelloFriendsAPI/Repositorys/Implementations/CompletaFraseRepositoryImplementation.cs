using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class CompletaFraseRepositoryImplementation : ICompletaFraseRepository
    {
        private HelloFriendsContext _context;

        public CompletaFraseRepositoryImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public CompletaFrase Create(CompletaFrase completaFrase)
        {
            try
            {
                _context.Add(completaFrase);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return completaFrase;
        }

        public void Delete(Guid id)
        {

            var result = _context.CompletaFrase.SingleOrDefault(p => p.Id.Equals(id));

            /*var result2 = _context.CompletaFrase.OrderBy(e => e.Id).Include(e => e.PalavrasChaves).ToList();
            var result3 = result2.Single(e => e.Id.Equals(id));*/            
            

            if(result != null) {
                try {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex) {
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
            return _context.CompletaFrase.Any(p => p.Id.Equals(id));
        }

        public List<CompletaFrase> FindAll()
        {
            return _context.CompletaFrase.ToList();
        }

        public CompletaFrase FindByID(Guid id)
        {
            return _context.CompletaFrase.SingleOrDefault(p => p.Id.Equals(id));
        }

        public CompletaFrase Update(CompletaFrase completaFrase)
        {
            /*if (!Exists(completaFrase.Id)) return null;*/

            var result = _context.CompletaFrase.SingleOrDefault(p => p.Id.Equals(completaFrase.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(completaFrase);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return completaFrase;
        }
    }
}
