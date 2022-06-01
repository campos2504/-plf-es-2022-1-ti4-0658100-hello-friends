using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using HelloFriendsAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        public AlunoMediaViewModel FindMediaAluno(Aluno aluno)
        {
            var idAluno = aluno.Id;
            
            var listaRespostaCompletaTexto = _context.RespostasCompletaTexto.Where(p =>  p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaCompletaFrase = _context.RespostasCompleFrase.Where(p =>  p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaVF = _context.RespostasVF.Where(p =>  p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaOpcaoCerta = _context.RespostasOpcaoCerta.Where(p => p.AlunoId.Equals(idAluno)).ToList();
            
            var somaResultado = listaRespostaCompletaTexto.Sum(p => p.Resultado) +
                                listaRespostaCompletaFrase.Sum(p => p.Resultado) +
                                listaRespostaOpcaoCerta.Sum(p => p.Resultado) +
                                listaRespostaVF.Sum(p => p.Resultado);

            var qtdeAtividades = _context.CompletaFrase.ToList().Count+_context.VerdadeiroFalso.ToList().Count
                +_context.OpcaoCerta.ToList().Count+_context.CompletaTexto.ToList().Count;
            var qtdeFeita = listaRespostaCompletaFrase.Count + listaRespostaCompletaTexto.Count
                                                        + listaRespostaOpcaoCerta.Count + listaRespostaVF.Count;

            var alunoMedia = new AlunoMediaViewModel();
            alunoMedia.Id = aluno.Id;
            alunoMedia.NomeCompleto = aluno.NomeCompleto;
            alunoMedia.AtividadesFeitas = qtdeFeita;
            alunoMedia.TotalAtividades = qtdeAtividades;
            alunoMedia.Media = somaResultado / qtdeFeita;
            return alunoMedia;
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
        public List<AlunoAtividadeViewModel> FindAlunoMediaAtividade(Aluno aluno)
        {
            var listAlunoAtividade = new List<AlunoAtividadeViewModel>();
            var idAluno = aluno.Id;

            var listaModulos = _context.Modulo.ToList();
            var listaRespostaCompletaTexto = _context.RespostasCompletaTexto.Where(p => p.AlunoId.Equals(idAluno)).Include(p => p.CompletaTexto).ToList();
            var listaRespostaCompletaFrase = _context.RespostasCompleFrase.Where(p =>  p.AlunoId.Equals(idAluno)).Include(p => p.CompletaFrase).ToList();
            var listaRespostaVF = _context.RespostasVF.Where(p =>  p.AlunoId.Equals(idAluno)).Include(p => p.VerdadeiroFalso).ToList();
            var listaRespostaOpcaoCerta = _context.RespostasOpcaoCerta.Where(p => p.AlunoId.Equals(idAluno)).Include(p => p.OpcaoCerta).ToList();



            AlunoAtividadeViewModel alunoAtividade;

            foreach (var atividade in listaRespostaCompletaTexto)
            {
                alunoAtividade=new AlunoAtividadeViewModel();
                alunoAtividade.IdAluno = aluno.Id;
                alunoAtividade.NomeCompleto = aluno.NomeCompleto;
                alunoAtividade.IdModulo = atividade.MId;
                alunoAtividade.NomeModulo = listaModulos.Find(modulo => modulo.Id == atividade.MId).NomeModulo;
                alunoAtividade.NomeAtividade = atividade.CompletaTexto.Titulo;
                alunoAtividade.Resultado = atividade.Resultado;
                listAlunoAtividade.Add(alunoAtividade);
            }
            foreach (var atividade in listaRespostaCompletaFrase)
            {
                alunoAtividade=new AlunoAtividadeViewModel();
                alunoAtividade.IdAluno = aluno.Id;
                alunoAtividade.NomeCompleto = aluno.NomeCompleto;
                alunoAtividade.IdModulo = atividade.MId;
                alunoAtividade.NomeModulo = listaModulos.Find(modulo => modulo.Id == atividade.MId).NomeModulo;
                alunoAtividade.NomeAtividade = atividade.CompletaFrase.Titulo;
                alunoAtividade.Resultado = atividade.Resultado;
                listAlunoAtividade.Add(alunoAtividade);
            }
            foreach (var atividade in listaRespostaVF)
            {
                alunoAtividade=new AlunoAtividadeViewModel();
                alunoAtividade.IdAluno = aluno.Id;
                alunoAtividade.NomeCompleto = aluno.NomeCompleto;
                alunoAtividade.IdModulo = atividade.MId;
                alunoAtividade.NomeModulo = listaModulos.Find(modulo => modulo.Id == atividade.MId).NomeModulo;
                alunoAtividade.NomeAtividade = atividade.VerdadeiroFalso.Titulo;
                alunoAtividade.Resultado = atividade.Resultado;
                listAlunoAtividade.Add(alunoAtividade);
            }
            foreach (var atividade in listaRespostaOpcaoCerta)
            {
                alunoAtividade=new AlunoAtividadeViewModel();
                alunoAtividade.IdAluno = aluno.Id;
                alunoAtividade.NomeCompleto = aluno.NomeCompleto;
                alunoAtividade.IdModulo = atividade.MId;
                alunoAtividade.NomeModulo = listaModulos.Find(modulo => modulo.Id == atividade.MId).NomeModulo;
                alunoAtividade.NomeAtividade = atividade.OpcaoCerta.Titulo;
                alunoAtividade.Resultado = atividade.Resultado;
                listAlunoAtividade.Add(alunoAtividade);
            }

            
            
            return listAlunoAtividade;
        }
    }
}
