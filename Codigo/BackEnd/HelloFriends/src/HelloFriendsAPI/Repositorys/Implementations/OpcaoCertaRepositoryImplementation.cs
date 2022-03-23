using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class OpcaoCertaRepositoryImplementation : IOpcaoCertaRepository
    {
        private HelloFriendsContext _context;

        public OpcaoCertaRepositoryImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public OpcaoCerta Create(OpcaoCerta opcaoCerta)
        {
            try
            {
                _context.Add(opcaoCerta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return opcaoCerta;
        }

        public void Delete(Guid id)
        {
            var result = _context.OpcaoCerta.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.OpcaoCerta.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(Guid id)
        {
            return _context.OpcaoCerta.Any(p => p.Id.Equals(id));
        }

        public List<OpcaoCerta> FindAll()
        {
            return _context.OpcaoCerta.ToList();
        }

        public OpcaoCerta FindByID(Guid id)
        {
            return _context.OpcaoCerta.SingleOrDefault(p => p.Id.Equals(id));
        }

        public OpcaoCerta Update(OpcaoCerta opcaoCerta)
        {
            if (!Exists(opcaoCerta.Id)) return null;

            var result = _context.OpcaoCerta.SingleOrDefault(p => p.Id.Equals(opcaoCerta.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(opcaoCerta);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return opcaoCerta;
        }
    }
}
