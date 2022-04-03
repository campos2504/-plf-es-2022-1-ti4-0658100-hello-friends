using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public class VerdadeiroFalsoCreateViewModel
    {
        public string Texto { get; set; }

        public string Imagem { get; set; }

        public string ImagemSrc { get; set; }

        public string Video { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Pergunta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long ModuloId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool AlternativaCerta { get; set; }

        public Guid Id { get; set; }
    }
}
