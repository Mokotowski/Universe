using System.ComponentModel.DataAnnotations;

namespace Universe.Models
{
    public class Video
    {
        [Key]
        public ushort Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Fps { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }   
    }
}
