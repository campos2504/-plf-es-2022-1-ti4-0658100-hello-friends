using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Model
{
    public class OpcaoCerta : Atividade
    {
        public string Texto { get; set; }
        public string Video { get; set; }
        public string Pergunta { get; set; }
        public string AlternativaA { get; set; }
        public string AlternativaB { get; set; }
        public string AlternativaC { get; set; }
        public string AlternativaD { get; set; }
        public char AlternativaCerta { get; set; }
    }
}
