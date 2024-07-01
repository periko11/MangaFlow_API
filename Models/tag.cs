using System.ComponentModel.DataAnnotations;

namespace MangaFlow_API.Models
{
    public class Tag
    {
        [Key]
        public long tag_id { get; set; }
        public string name { get; set; } = new string("");
    }
}
