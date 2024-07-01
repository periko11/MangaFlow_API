using MangaFlow_API.Dtos.action;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class actionMapper
    {
        public static actionDto toactionDto(this action actionModel)
        {
            return new actionDto
            {
                action_id = actionModel.action_id,
                user_id = actionModel.user_id,
                chapter_id = actionModel.chapter_id,
                role_id = actionModel.role_id,
                type = actionModel.type,
                timestamp = actionModel.timestamp
            };
        }

        public static action CreateactionDto(this CreateactionDto createactionDto)
        {
            return new action
            {
                user_id = createactionDto.user_id,
                chapter_id = createactionDto.chapter_id,
                role_id = createactionDto.role_id,
                type = createactionDto.type
            };
        }
    }
}
