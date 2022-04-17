using System;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public abstract class UserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Só podem ser passadas letras e espaços")]
        public string NomeCompleto { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválida")]
        public DateTime DataAniversario { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O formato do campo {0} está inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo {0} precisa de no mínimo {1} caracter")]
        public string Senha { get; set; }

    }
}
