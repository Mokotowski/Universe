using System.ComponentModel.DataAnnotations;

namespace Universe.Models
{
    public class Search
    {
        [Required(ErrorMessage = "Musisz podać nazwę filmu!")]
        public string looking { get; set; }
    }
}
