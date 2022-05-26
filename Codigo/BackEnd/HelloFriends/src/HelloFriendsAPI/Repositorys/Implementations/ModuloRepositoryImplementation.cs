using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HelloFriendsAPI.ViewModels;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class ModuloRepositoryImplementation : IModuloRepository
    {

        private HelloFriendsContext _context;

        public ModuloRepositoryImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public Modulo Create(Modulo modulo)
        {

            try
            {
                _context.Add(modulo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return modulo;
        }

        public void Delete(long id)
        {

            var result = _context.Modulo.SingleOrDefault(p => p.Id.Equals(id));

            /*var acertoPalavrasChaves = _context.CompletaFrase.OrderBy(e => e.Id).Include(e => e.PalavrasChaves).ToList();

            var filtroAcetoPalavraChave = acertoPalavrasChaves.FindAll(e => e.ModuloId.Equals(id)).ToList();*/

            /*foreach(var teste in result5) {

                _context.Remove(teste);
            }*/



            if (result != null)
            {
                try
                {
                    _context.Modulo.Remove(result);
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

            return _context.Modulo.Any(p => p.Id.Equals(id));
        }

        public List<Modulo> FindAll()
        {

            return _context.Modulo.ToList();
        }

        public Modulo FindByID(long id)
        {

            return _context.Modulo.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Modulo Update(Modulo modulo)
        {

            if (!Exists(modulo.Id)) return null;

            var result = _context.Modulo.SingleOrDefault(p => p.Id.Equals(modulo.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(modulo);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return modulo;
        }

        public string FindMedalha(long idModulo, long idAluno)
        {
            var quantCompletaTexto = _context.CompletaTexto.Count(p => p.ModuloId.Equals(idModulo));
            var quantCompletaFrase = _context.CompletaFrase.Count(p => p.ModuloId.Equals(idModulo));
            var quantVF = _context.VerdadeiroFalso.Count(p => p.ModuloId.Equals(idModulo));
            var quantOpcaoCerta = _context.OpcaoCerta.Count(p => p.ModuloId.Equals(idModulo));

            var listaRespostaCompletaTexto = _context.RespostasCompletaTexto.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaCompletaFrase = _context.RespostasCompleFrase.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaVF = _context.RespostasVF.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
            var listaRespostaOpcaoCerta = _context.RespostasOpcaoCerta.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();

            //Soma das atividades criadas
            var somaQtd = quantCompletaFrase + quantCompletaTexto + quantOpcaoCerta + quantVF;

            double mediaResultado = 0;
            string tipoMedalha = "";

            if (listaRespostaCompletaTexto.Count() == quantCompletaTexto &&
                listaRespostaCompletaFrase.Count() == quantCompletaFrase &&
                listaRespostaOpcaoCerta.Count() == quantOpcaoCerta &&
                listaRespostaVF.Count() == quantVF && somaQtd > 0)
            {
                var somaResultado = listaRespostaCompletaTexto.Sum(p => p.Resultado) +
                    listaRespostaCompletaFrase.Sum(p => p.Resultado) +
                    listaRespostaOpcaoCerta.Sum(p => p.Resultado) +
                    listaRespostaVF.Sum(p => p.Resultado);

                mediaResultado = somaResultado / somaQtd;

            }
            else
            {
                return "Sem medalha";
            }


            if (mediaResultado >= 0.9)
            {
                tipoMedalha = "Ouro";
            }
            else if (mediaResultado >= 0.6)
            {
                tipoMedalha = "Prata";
            }
            else
            {
                tipoMedalha = "Bronze";
            }


            return tipoMedalha;
        }

        public List<ModuloGraficoViewModel> FindMQtdModulosConcluidos()
        {
            var listaModulos = _context.Medalha.ToList();
            var listaModulosConcluidos = listaModulos.Select(p => p.ModuloId).Distinct().ToList();

            var result = new List<ModuloGraficoViewModel>();

            ModuloGraficoViewModel moduloGraficoViewModel;

            for (int i = 0; i < listaModulosConcluidos.Count; i++)
            {
                var qtd = listaModulos.Where(p => p.ModuloId == listaModulosConcluidos[i]).Count();
                moduloGraficoViewModel = new ModuloGraficoViewModel();
                moduloGraficoViewModel.NomeModulo = _context.Modulo.SingleOrDefault(p => p.Id.Equals(listaModulosConcluidos[i])).NomeModulo;
                moduloGraficoViewModel.Repeticoes = qtd;
                result.Add(moduloGraficoViewModel);
            }
            
            return result;
        }
    }
}
