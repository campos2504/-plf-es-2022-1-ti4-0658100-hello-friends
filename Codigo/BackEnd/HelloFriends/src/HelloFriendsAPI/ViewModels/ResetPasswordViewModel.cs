using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloFriendsAPI.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Token { get; set; }

        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }
    }
}
