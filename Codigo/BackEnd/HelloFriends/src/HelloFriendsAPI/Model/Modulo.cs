using System.ComponentModel.DataAnnotations.Schema;

namespace HelloFriendsAPI.Model {
    public class Modulo {
        public long Id { get; set; }
        public string NomeModulo { get; set; }
        public string Imagem { get; set; }
        [NotMapped]
        public string ImagemSrc { get; set; }
    }
}
