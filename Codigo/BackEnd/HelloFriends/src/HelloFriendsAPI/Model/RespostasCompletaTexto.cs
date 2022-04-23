using System;

namespace HelloFriendsAPI.Model
{
    public class RespostasCompletaTexto
    {
        public long Id { get; set; }
        public double Resultado { get; set; }
        public long AlunoId { get; set; }
        public long MId { get; set; }
        public Guid CompletaFraseID { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual CompletaTexto CompletaTexto { get; set; }
    }
}
