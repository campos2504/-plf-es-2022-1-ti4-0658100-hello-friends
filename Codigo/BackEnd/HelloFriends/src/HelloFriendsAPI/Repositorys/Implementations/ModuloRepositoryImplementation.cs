using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HelloFriendsAPI.Repositorys.Implementations {
    public class ModuloRepositoryImplementation : IModuloRepository{

        private HelloFriendsContext _context;

        public ModuloRepositoryImplementation(HelloFriendsContext context) {
            _context = context;
        }

        public Modulo Create(Modulo modulo) {

            try {
                _context.Add(modulo);
                _context.SaveChanges();
            }
            catch (Exception ex) {

                throw ex;
            }

            return modulo;
        }

        public void Delete(long id) {

            var result = _context.Modulo.SingleOrDefault(p => p.Id.Equals(id));

            /*var acertoPalavrasChaves = _context.CompletaFrase.OrderBy(e => e.Id).Include(e => e.PalavrasChaves).ToList();

            var filtroAcetoPalavraChave = acertoPalavrasChaves.FindAll(e => e.ModuloId.Equals(id)).ToList();*/

            /*foreach(var teste in result5) {

                _context.Remove(teste);
            }*/



            if (result != null) {
                try {
                    _context.Modulo.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception) {

                    throw;
                }
            }
        }

        public bool Exists(long id) {

            return _context.Modulo.Any(p => p.Id.Equals(id));
        }

        public List<Modulo> FindAll() {

            return _context.Modulo.ToList();
        }

        public Modulo FindByID(long id) {

            return _context.Modulo.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Modulo Update(Modulo modulo) {

            if (!Exists(modulo.Id)) return null;

            var result = _context.Modulo.SingleOrDefault(p => p.Id.Equals(modulo.Id));

            if (result != null) {
                try {
                    _context.Entry(result).CurrentValues.SetValues(modulo);
                    _context.SaveChanges();
                }
                catch (Exception) {

                    throw;
                }
            }
            return modulo;
        }
    }
}
