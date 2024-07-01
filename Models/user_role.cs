using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFlow_API.Models
{
    public class User_role
    {
        [ForeignKey("user")]
        public long user_id { get; set; }
        public User user { get; set; }
        [ForeignKey("role")]
        public long role_id { get; set; }
        public Role role { get; set; }
    }
}
