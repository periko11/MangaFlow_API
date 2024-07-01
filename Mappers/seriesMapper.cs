using MangaFlow_API.Dtos.series;
using MangaFlow_API.Models;

namespace MangaFlow_API.Mappers
{
    public static class seriesMapper
    {
        public static seriesDto ToseriesDto(this series seriesModel)
        {
            return new seriesDto
            {
                series_id = seriesModel.series_id,
                type = seriesModel.type,
                name = seriesModel.name,
                is_adult_content = seriesModel.is_adult_content,
            };
        }

        public static series CreateseriesDto(this CreateseriesDto createseriesDto)
        {
            return new series
            {
                type = createseriesDto.type,
                name = createseriesDto.name,
                is_adult_content = createseriesDto.is_adult_content,
            };
        }
    }
}