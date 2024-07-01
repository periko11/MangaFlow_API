using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class Action
    {
        [Key]
        public long action_id { get; set; }
        [ForeignKey("user_id")]
        public long user_id { get; set; }
        public User user { get; set; }
        [ForeignKey("chapter_id")]
        public long chapter_id { get; set; }
        public Chapter chapter { get; set; }
        [ForeignKey("role_id")]
        public long role_id { get; set; }
        public Role role { get; set; }
        public string type { get; set; } = new string("");
        public DateTime timestamp { get; set; }
    }
}
