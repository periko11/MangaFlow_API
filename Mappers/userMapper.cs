using MangaFlow_API.Dtos;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class userMapper
    {
        public static userDto TouserDto(this user userModel)
        {
            return new userDto
            {
                user_id = userModel.user_id,
                group_id = userModel.group_id,
                username = userModel.username,
                description = userModel.description,
                status = userModel.status,
            };
        }

        public static user CreateuserDto(this CreateuserDto createuserDto)
        {
            return new user
            {
                group_id = createuserDto.group_id,
                username = createuserDto.username,
                description = createuserDto.description,
                status = createuserDto.status,
            };
        }
    }
}