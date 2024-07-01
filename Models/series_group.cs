using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class series_group
    {
        [ForeignKey("series")]
        public long? series_id { get; set; }
        public Series series { get; set; }
        [ForeignKey("group")]
        public long? group_id { get; set; }
        public Scanlation_group group { get; set; }
    }
}
