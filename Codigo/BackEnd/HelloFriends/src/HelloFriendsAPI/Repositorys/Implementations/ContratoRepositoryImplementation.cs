using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class ContratoRepositoryImplementation : IContratoRepository
    {
        private HelloFriendsContext _context;

        public ContratoRepositoryImplementation (HelloFriendsContext context)
        {
            _context = context;
        }

        public Contrato Create(Contrato contrato)
        {
            try
            {
                _context.Add(contrato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return contrato;
        }

        public void Delete(long id)
        {
            var result = _context.Contrato.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Contrato.Remove(result);
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
            return _context.Contrato.Any(p => p.Id.Equals(id));
        }

        public List<Contrato> FindAll()
        {
            return _context.Contrato.ToList();
        }

        public Contrato FindByID(long id)
        {
            return _context.Contrato.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Contrato Update(Contrato contrato)
        {
            if (!Exists(contrato.Id)) return null;

            var result = _context.Contrato.SingleOrDefault(p => p.Id.Equals(contrato.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(contrato);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return contrato;
        }

        
    }
}
