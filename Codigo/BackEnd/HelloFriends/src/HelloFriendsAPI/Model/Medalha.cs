using System;

namespace HelloFriendsAPI.Model
{
    public class Medalha
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Modulo Modulo { get; set; }
        public long ModuloId { get; set; }
        public string TipoMedalha { get; set; }
        public bool ModuloConcluido { get; set; }

    }
}
