
using MangaFlow_API.Dtos.tag;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class tagMapper
    {
        public static tagDto totagDto(this tag tagModel)
        {
            return new tagDto
            {
                tag_id = tagModel.tag_id,
                name = tagModel.name
            };
        }

        public static tag CreatetagDto(this CreatetagDto createtagDto)
        {
            return new tag
            {
                name = createtagDto.name
            };
        }
    }
}