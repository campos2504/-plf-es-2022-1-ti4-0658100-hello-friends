using System;

namespace HelloFriendsAPI.Model
{
    public class PalavraChave
    {
        public PalavraChave()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Texto { get; set; }

        /* EF Relations */
        public CompletaFrase Atividade { get; set; }
    }
}
