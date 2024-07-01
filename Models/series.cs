using System.ComponentModel.DataAnnotations;

namespace MangaFlow_API.Models
{
    public class Series
    {
        [Key]
        public long series_id { get; set; }
        public string type { get; set; } = new string("");
        public string name { get; set; } = new string("");
        public bool is_adult_content { get; set; }
    }
}
