using MangaFlow_API.Dtos.chapter_work;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class chapter_workMapper
    {
        public static chapter_workDto tochapter_workDto(this chapter_work chapter_workModel)
        {
            return new chapter_workDto
            {
                chapter_id = chapter_workModel.chapter_id,
                role_id = chapter_workModel.role_id,
                user_id = chapter_workModel.user_id,
                status = chapter_workModel.status
            };
        }

        public static chapter_work Createchapter_workDto(this Createchapter_workDto createchapter_workDto)
        {
            return new chapter_work
            {
                chapter_id = createchapter_workDto.chapter_id,
                role_id = createchapter_workDto.role_id,
                user_id = createchapter_workDto.user_id,
                status = createchapter_workDto.status
            };
        }
    }
}
