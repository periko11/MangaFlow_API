using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.chapter;

namespace MangaFlow_API.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class chapterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public chapterController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var chapters = _context.chapter.ToList().Select(c => c.tochapterDto());
            return Ok(chapters);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var chapter = _context.chapter.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter.tochapterDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatechapterDto chapterDto)
        {
            var newChapter = chapterDto.CreatechapterDto();
            _context.chapter.Add(newChapter);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newChapter.chapter_id }, newChapter.tochapterDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] CreatechapterDto chapterDto)
        {
            var existingChapter = _context.chapter.Find(id);
            if (existingChapter == null)
            {
                return NotFound();
            }

            existingChapter.series_id = chapterDto.series_id;
            existingChapter.volume_number = chapterDto.volume_number;
            existingChapter.chapter_number = chapterDto.chapter_number;
            existingChapter.chapter_name = chapterDto.chapter_name;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var chapter = _context.chapter.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }

            _context.chapter.Remove(chapter);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
