using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public class ProfessorViewModel : UserViewModel
    {
        [StringLength(11, MinimumLength = 11,  ErrorMessage = "O telefone precisa ter 11 caracteres. Insira também o DDD.")]
        public string NumeroTelefone { get; set; }
    }
}
 