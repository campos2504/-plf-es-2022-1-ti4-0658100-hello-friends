using System;

namespace HelloFriendsAPI.Model
{
    public class RespostasOpcaoCerta
    {
        public long Id { get; set; }
        public double Resultado { get; set; }
        public long AlunoId { get; set; }
        public long MId { get; set; }
        public Guid OpcaoCertaID { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual OpcaoCerta OpcaoCerta { get; set; }
    }
}
