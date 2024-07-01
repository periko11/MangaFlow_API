using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class User_preferences
    {
        [ForeignKey("user")]
        public long user_id { get; set; }
        public User user { get; set; }
        public bool allow_adult_content { get; set; }
    }
}
