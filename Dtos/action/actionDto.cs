namespace MangaFlow_API.Dtos.action
{
    public class actionDto
    {
        public long action_id { get; set; }
        public long user_id { get; set; }
        public long chapter_id { get; set; }
        public long role_id { get; set; }
        public string type { get; set; }
        public DateTime timestamp { get; set; }
    }
}