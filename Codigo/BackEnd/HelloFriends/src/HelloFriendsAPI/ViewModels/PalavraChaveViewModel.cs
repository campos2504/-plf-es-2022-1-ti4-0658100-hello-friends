using System;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public class PalavraChaveViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Texto { get; set; }

        public Guid Id { get; set; }
    }
}
