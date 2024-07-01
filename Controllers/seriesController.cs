using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.series;

namespace MangaFlow_API.Controllers
{
    [Route("api/series")]
    [ApiController]
    public class seriesController : ControllerBase
    {

        private readonly ApplicationDBContext _context;

        public seriesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var series = _context.series.ToList().Select(s => s.ToseriesDto());
            return Ok(series);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var series = _context.series.Find(id);
            if (series == null)
            {
                return NotFound();
            }

            return Ok(series.ToseriesDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateseriesDto seriesDto)
        {
            var series = seriesDto.CreateseriesDto();
            _context.series.Add(series);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = series.series_id }, series.ToseriesDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] UpdateseriesDto updateDto)
        {
            var series = _context.series.Find(id);
            if (series == null)
            {
                return NotFound();
            }

            series.type = updateDto.type;
            series.name = updateDto.name;
            series.is_adult_content = updateDto.is_adult_content;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var series = _context.series.Find(id);
            if (series == null)
            {
                return NotFound();
            }

            _context.series.Remove(series);
            _context.SaveChanges();

            return NoContent();
        }
    }
}