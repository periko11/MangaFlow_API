using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class Chapter_work
    {
        [ForeignKey("chapter")]
        public long chapter_id { get; set; }
        public Chapter chapter { get; set; }
        [ForeignKey("role")]
        public long role_id { get; set; }
        public Role role { get; set; }
        [ForeignKey("user")]
        public long user_id { get; set; }
        public User user { get; set; }
        public string status { get; set; } = new string("");
    }
}
