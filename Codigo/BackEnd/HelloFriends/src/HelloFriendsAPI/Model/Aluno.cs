using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloFriendsAPI.Model {
    public class Aluno {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeResponsavel { get; set; }
        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public string Imagem { get; set; }
        public bool Status { get; set; }
        public string Situacao { get; set; }
        [NotMapped]
        public string ImagemSrc { get; set; }
    }
}
