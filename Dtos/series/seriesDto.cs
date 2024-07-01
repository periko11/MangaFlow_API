namespace MangaFlow_API.Dtos.series
{
    public class seriesDto
    {
        public long series_id { get; set; } = new long();
        public string type { get; set; } = new string("");
        public string name { get; set; } = new string("");
        public Boolean is_adult_content { get; set; } = new Boolean();
    }
}