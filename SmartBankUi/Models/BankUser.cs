using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBankUi.Models
{
    public class BankUser
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Maximum username length is 16")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(128, ErrorMessage = "Maximum name length is 128")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(128, ErrorMessage = "Maximum password length is 128")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Pin is required")]
        [Range(1111,9999, ErrorMessage = "Pin must be between 1111 and 9999")]
        public int Pin { get; set; }

        public override string ToString()
        {
            return $"{{ {nameof(Username)}: {Username}, {nameof(Name)}: {Name}, {nameof(Password)}: {Password}, {nameof(Pin)}: {Pin} }}";
        }
    }
}