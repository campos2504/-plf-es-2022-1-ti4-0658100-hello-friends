using System;

namespace HelloFriendsAPI.Model
{
    public class Contrato
    {
        public long Id { get; set; }
        public string NomeResponsavel { get; set; }
        public string Nacionalidade { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public string Ci { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string NomeAluno { get; set; }
        public string DiaAula { get; set; }
        public string Horario { get; set; }
        public string CargaHorariaSemanal { get; set; }
        public double ValorMensalidade { get; set; }
        public string ValorExtensoMensalidade { get; set; }
        public DateTime DataInicioContrato { get; set; }
        public DateTime DataFinalContrato { get; set; }

    }
}
