using System.Collections.Generic;

namespace HelloFriendsAPI.Model
{
    public class CompletaFrase : Atividade
    {
        public string Enunciado { get; set; }


        /* EF Relations */
        public IEnumerable<PalavraChave> PalavrasChaves { get; set; }
    }
}
