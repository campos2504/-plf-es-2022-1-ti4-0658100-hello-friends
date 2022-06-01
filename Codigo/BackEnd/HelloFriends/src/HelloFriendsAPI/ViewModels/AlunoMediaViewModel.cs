namespace HelloFriendsAPI.ViewModels
{
    public class AlunoMediaViewModel
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public int TotalAtividades { get; set; }
        public int AtividadesFeitas { get; set; }
        public double Media { get; set; }
    }
}