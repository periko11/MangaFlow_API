using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class User
    {
        [Key]
        public long user_id { get; set; }
        [ForeignKey("group_id")]
        public long group_id { get; set; }
        public Scanlation_group group { get; set; }
        public string username { get; set; } = new string("");
        public string? description { get; set; }
        public string status { get; set; } = new string("Active");
    }
}
