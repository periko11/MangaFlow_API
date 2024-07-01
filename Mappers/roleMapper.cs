using MangaFlow_API.Dtos.role;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class roleMapper
    {
        public static roleDto toroleDto(this role roleModel)
        {
            return new roleDto
            {
                role_id = roleModel.role_id,
                name = roleModel.name,
                permissions = roleModel.permissions
            };
        }

        public static role CreaterolDto(this CreateroleDto createroleDto)
        {
            return new role
            {
                name = createroleDto.name,
                permissions = createroleDto.permissions
            };
        }
    }
}
