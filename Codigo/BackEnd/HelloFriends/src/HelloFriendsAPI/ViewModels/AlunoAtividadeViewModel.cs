namespace HelloFriendsAPI.ViewModels
{
    public class AlunoAtividadeViewModel
    {
        public long IdAluno { get; set; }
        public string NomeCompleto { get; set; }
        public long IdModulo { get; set; }
        
        public string NomeModulo { get; set; }
        public string NomeAtividade { get; set; }
        public double Resultado { get; set; }
    }
}