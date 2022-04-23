using System;

namespace HelloFriendsAPI.Model
{
    public class RespostasVF
    {
        public long Id { get; set; }
        public double Resultado { get; set; }
        public long AlunoId { get; set; }
        public long MId { get; set; }
        public Guid CompletaFraseID { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual VerdadeiroFalso VerdadeiroFalso { get; set; }
    }
}
