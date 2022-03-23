using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels {
    public class LoginUserViewModel {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O formato do campo {0} está inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo {0} precisa de no mínimo {1} caracter")]
        public string Senha { get; set; }
    }
}
