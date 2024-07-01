using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class Chapter
    {
        [Key]
        public long chapter_id { get; set; }
        [ForeignKey("series_id")]
        public long series_id { get; set; }
        public Series series { get; set; }
        public int volume_number { get; set; }
        public float chapter_number { get; set; }
        public string? chapter_name { get; set; }
    }
}
