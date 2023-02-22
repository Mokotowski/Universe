using System.ComponentModel.DataAnnotations;

namespace Universe.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Pole nazwa jest wymagane!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest wymagane!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest wymagane!")]
        public string SecondPassword { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Pole nazwa jest wymagane!")]
        public string Email { get; set; }


    }
}
