using System.ComponentModel.DataAnnotations;

namespace SampleWebApiAspNetCore.Dtos
{
    public class MovieCreateDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
    }
}
