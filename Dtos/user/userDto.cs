namespace MangaFlow_API.Dtos
{
    public class userDto
    {
        public long user_id { get; set; }
        public long group_id { get; set; }
        public string username { get; set; }
        public string? description { get; set; }
        public string status { get; set; }
    }
}
