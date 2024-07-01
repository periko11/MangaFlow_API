using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class Series_tag
    {
        [ForeignKey("tag")]
        public long tag_id { get; set; }
        public Tag tag { get; set; }
        [ForeignKey("series")]
        public long series_id { get; set; }
        public Series series { get; set; }
    }
}
