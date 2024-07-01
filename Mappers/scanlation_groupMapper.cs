using MangaFlow_API.Dtos.scanlation_group;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class scanlation_groupMapper
    {
        public static scanlation_groupDto Toscanlation_groupDto(this scanlation_group scanlation_groupModel)
        {
            return new scanlation_groupDto
            {
                group_id = scanlation_groupModel.group_id,
                name = scanlation_groupModel.name
            };
        }

        public static scanlation_group Createscanlation_groupDto(this Createscanlation_groupDto createscanlation_groupDto)
        {
            return new scanlation_group
            {
                name = createscanlation_groupDto.name
            };
        }
    }
}