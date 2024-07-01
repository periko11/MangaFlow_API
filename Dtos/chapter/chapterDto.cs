namespace MangaFlow_API.Dtos.chapter
{
    public class chapterDto
    {
        public long chapter_id { get; set; }
        public long series_id { get; set; }
        public int volume_number { get; set; }
        public float chapter_number { get; set; }
        public string? chapter_name { get; set; }
    }
}