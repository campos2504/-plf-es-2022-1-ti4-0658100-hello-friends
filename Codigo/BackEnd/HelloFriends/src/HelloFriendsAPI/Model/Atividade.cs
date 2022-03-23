using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloFriendsAPI.Model
{
    public abstract class Atividade
    {
        protected Atividade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Imagem { get; set; }
        [NotMapped]
        public string ImagemSrc { get; set; }
        public long ModuloId { get; set; }

        public string Titulo { get; set; }

        /* EF Relations */
        public Modulo Modulo { get; set; }
    }
}
