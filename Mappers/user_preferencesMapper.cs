using MangaFlow_API.Dtos.user_preferences;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class user_preferencesMapper
    {
        public static user_preferencesDto touser_preferencesDto(this user_preferences user_preferencesModel)
        {
            return new user_preferencesDto
            {
                user_id = user_preferencesModel.user_id,
                allow_adult_content = user_preferencesModel.allow_adult_content
            };
        }

        public static user_preferences Createuser_preferencesDto(this Createuser_preferencesDto createuser_preferencesDto)
        {
            return new user_preferences
            {
                user_id = createuser_preferencesDto.user_id,
                allow_adult_content = createuser_preferencesDto.allow_adult_content
            };
        }
    }
}
