
namespace SampleWebApiAspNetCore.Dtos
{
    public class MovieUpdateDto
    {
        public string? Name { get; set; }
        public int Rating { get; set; }
        public string? Genre { get; set; }
        public DateTime Created { get; set; }
    }
}
