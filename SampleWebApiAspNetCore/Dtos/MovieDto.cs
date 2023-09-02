namespace SampleWebApiAspNetCore.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
    }
}
