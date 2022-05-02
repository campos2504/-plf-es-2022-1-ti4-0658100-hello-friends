using System;

namespace HelloFriendsAPI.ViewModels
{
    public class MedalhaViewModel
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public long ModuloId { get; set; }
        public string TipoMedalha { get; set; }
        public bool ModuloConcluido { get; set; }

    }
}
