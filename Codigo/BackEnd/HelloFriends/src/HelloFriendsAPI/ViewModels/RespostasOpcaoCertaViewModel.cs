using System;

namespace HelloFriendsAPI.ViewModels
{
    public class RespostasOpcaoCertaViewModel
    {
        public long Id { get; set; }
        public double Resultado { get; set; }
        public long AlunoId { get; set; }
        public long MId { get; set; }
        public Guid OpcaoCertaID { get; set; }
    }
}
