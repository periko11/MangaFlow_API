using System.ComponentModel.DataAnnotations;

namespace MangaFlow_API.Models
{
    public class Role
    {
        [Key]
        public long role_id { get; set; }
        public string name { get; set; } = new string("");
        public string permissions { get; set; } = new string("");
    }
}
