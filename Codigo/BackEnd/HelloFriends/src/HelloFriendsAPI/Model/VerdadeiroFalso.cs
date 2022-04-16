using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Model
{
    public class VerdadeiroFalso : Atividade
    {
        public string Texto { get; set; }
        public string Video { get; set; }
        public string Pergunta { get; set; }
        public bool AlternativaCerta { get; set; }
    }
}
