using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFriendsAPI.Repositorys.Implementations {
    public class AlunoRepositoryImplementation : IAlunoRepository {

        private HelloFriendsContext _context;

        public AlunoRepositoryImplementation(HelloFriendsContext context) {
            _context = context;
        }

        public Aluno Create(Aluno aluno) {

            try {
                _context.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex) {

                throw ex;
            }

            return aluno;
        }

        public void Delete(long id) {

            var result = _context.Aluno.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null) {
                try {
                    _context.Aluno.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception) {

                    throw;
                }
            }
        }

        public bool Exists(long id) {

            return _context.Aluno.Any(p => p.Id.Equals(id));
        }

        public List<Aluno> FindAll() {

            return _context.Aluno.ToList();
        }

        public Aluno FindByID(long id) {

            return _context.Aluno.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Aluno Update(Aluno aluno) {

            if (!Exists(aluno.Id)) return null;

            var result = _context.Aluno.SingleOrDefault(p => p.Id.Equals(aluno.Id));

            if (result != null) {
                try {
                    _context.Entry(result).CurrentValues.SetValues(aluno);
                    _context.SaveChanges();
                }
                catch (Exception) {

                    throw;
                }
            }
            return aluno;
        }
    }
}
