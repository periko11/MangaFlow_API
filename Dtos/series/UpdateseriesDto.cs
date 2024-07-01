namespace MangaFlow_API.Dtos.series
{
    public class UpdateseriesDto
    {
        public string type { get; set; } = new string("");
        public string name { get; set; } = new string("");
        public Boolean is_adult_content { get; set; } = new Boolean();
    }
}