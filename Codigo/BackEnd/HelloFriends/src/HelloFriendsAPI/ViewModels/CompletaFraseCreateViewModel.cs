using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public class CompletaFraseCreateViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string ImagemSrc { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long ModuloId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Enunciado { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IEnumerable<PalavraChaveViewModel> PalavrasChaves { get; set; }
        public Guid Id { get; set; }

    }
}
