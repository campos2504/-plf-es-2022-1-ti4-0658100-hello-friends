using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class VerdadeiroFalsoRepositoryImplementation : IVerdadeiroFalsoRepository
    {
        private HelloFriendsContext _context;

        public VerdadeiroFalsoRepositoryImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public VerdadeiroFalso Create(VerdadeiroFalso verdadeiroFalso)
        {
            try
            {
                _context.Add(verdadeiroFalso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return verdadeiroFalso;
        }

        public void Delete(Guid id)
        {
            var result = _context.VerdadeiroFalso.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.VerdadeiroFalso.Remove(result);
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
            return _context.VerdadeiroFalso.Any(p => p.Id.Equals(id));
        }

        public List<VerdadeiroFalso> FindAll()
        {
            return _context.VerdadeiroFalso.ToList();
        }

        public VerdadeiroFalso FindByID(Guid id)
        {
            return _context.VerdadeiroFalso.SingleOrDefault(p => p.Id.Equals(id));
        }

        public VerdadeiroFalso Update(VerdadeiroFalso verdadeiroFalso)
        {
            if (!Exists(verdadeiroFalso.Id)) return null;

            var result = _context.VerdadeiroFalso.SingleOrDefault(p => p.Id.Equals(verdadeiroFalso.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(verdadeiroFalso);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return verdadeiroFalso;
        }

        
    }
}
