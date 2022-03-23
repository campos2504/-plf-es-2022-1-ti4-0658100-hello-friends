using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels {
    public class ModuloViewModel {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Só podem ser passadas letras e espaços")]
        public string NomeModulo { get; set; }
        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }
        public long Id { get; set; }
    }
}
