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

        public double FindMediaAluno(long idAluno)
        {
            
            var listaRespostaCompletaTexto = _context.RespostasCompletaTexto.Where(p =>  p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaCompletaFrase = _context.RespostasCompleFrase.Where(p =>  p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaVF = _context.RespostasVF.Where(p =>  p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaOpcaoCerta = _context.RespostasOpcaoCerta.Where(p => p.AlunoId.Equals(idAluno)).ToList();
            
            var somaResultado = listaRespostaCompletaTexto.Sum(p => p.Resultado) +
                                listaRespostaCompletaFrase.Sum(p => p.Resultado) +
                                listaRespostaOpcaoCerta.Sum(p => p.Resultado) +
                                listaRespostaVF.Sum(p => p.Resultado);

            var qtde = listaRespostaCompletaFrase.Count + listaRespostaCompletaTexto.Count
                                                        + listaRespostaOpcaoCerta.Count + listaRespostaVF.Count;
            return somaResultado / qtde;
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

        public Aluno FindByEmail(string email)
        {

            return _context.Aluno.SingleOrDefault(p => p.Email.Equals(email));
        }
    }
}
