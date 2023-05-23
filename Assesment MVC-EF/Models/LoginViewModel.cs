using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace Assesment_MVC_EF.Models
{
    public class LoginViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
