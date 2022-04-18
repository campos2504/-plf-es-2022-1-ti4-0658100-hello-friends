using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloFriendsAPI.ViewModels
{
    public class AlunoAuthViewModel
    {
        public bool Status { get; set; }
        public string Situacao { get; set; }
    }
}
