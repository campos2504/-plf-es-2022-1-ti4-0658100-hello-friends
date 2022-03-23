using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public class AlunoViewModel : UserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Só podem ser passadas letras e espaços")]
        public string NomeResponsavel { get; set; }
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[MinLength(1, ErrorMessage = "É necessário ser vinculado a pelo menos 1 professor")]
        public IEnumerable<ProfessorViewModel> Professores { get; set; }
        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }
    }
}
