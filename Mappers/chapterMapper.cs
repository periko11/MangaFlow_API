using MangaFlow_API.Dtos.chapter;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class chapterMapper
    {
        public static chapterDto tochapterDto(this chapter chapterModel)
        {
            return new chapterDto
            {
                chapter_id = chapterModel.chapter_id,
                series_id = chapterModel.series_id,
                volume_number = chapterModel.volume_number,
                chapter_number = chapterModel.chapter_number,
                chapter_name = chapterModel.chapter_name
            };
        }

        public static chapter CreatechapterDto(this CreatechapterDto createchapterDto)
        {
            return new chapter
            {
                series_id = createchapterDto.series_id,
                volume_number = createchapterDto.volume_number,
                chapter_number = createchapterDto.chapter_number,
                chapter_name = createchapterDto.chapter_name
            };
        }
    }
}
