using System.ComponentModel.DataAnnotations;

namespace MangaFlow_API.Models
{
    public class Scanlation_group
    {
        [Key]
        public long group_id { get; set; }
        public string name { get; set; } = new string("");
    }
}
