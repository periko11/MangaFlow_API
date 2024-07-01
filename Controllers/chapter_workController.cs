using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.chapter_work;

namespace MangaFlow_API.Controllers
{
    [Route("api/chapter_works")]
    [ApiController]
    public class chapter_workController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public chapter_workController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var chapter_works = _context.chapter_work.ToList().Select(cw => cw.tochapter_workDto());
            return Ok(chapter_works);
        }

        [HttpGet("{chapter_id}/{role_id}/{user_id}")]
        public IActionResult GetById([FromRoute] long chapter_id, [FromRoute] long role_id, [FromRoute] long user_id)
        {
            var chapter_work = _context.chapter_work
                .FirstOrDefault(cw => cw.chapter_id == chapter_id && cw.role_id == role_id && cw.user_id == user_id);

            if (chapter_work == null)
            {
                return NotFound();
            }

            return Ok(chapter_work.tochapter_workDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Createchapter_workDto chapter_workDto)
        {
            var newChapter_work = chapter_workDto.Createchapter_workDto();
            _context.chapter_work.Add(newChapter_work);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { chapter_id = newChapter_work.chapter_id, role_id = newChapter_work.role_id, user_id = newChapter_work.user_id }, newChapter_work.tochapter_workDto());
        }

        [HttpPut("{chapter_id}/{role_id}/{user_id}")]
        public IActionResult Update([FromRoute] long chapter_id, [FromRoute] long role_id, [FromRoute] long user_id, [FromBody] Updatechapter_workDto chapter_workDto)
        {
            var existingChapter_work = _context.chapter_work
                .FirstOrDefault(cw => cw.chapter_id == chapter_id && cw.role_id == role_id && cw.user_id == user_id);

            if (existingChapter_work == null)
            {
                return NotFound();
            }

            existingChapter_work.status = chapter_workDto.status;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{chapter_id}/{role_id}/{user_id}")]
        public IActionResult Delete([FromRoute] long chapter_id, [FromRoute] long role_id, [FromRoute] long user_id)
        {
            var chapter_work = _context.chapter_work
                .FirstOrDefault(cw => cw.chapter_id == chapter_id && cw.role_id == role_id && cw.user_id == user_id);

            if (chapter_work == null)
            {
                return NotFound();
            }

            _context.chapter_work.Remove(chapter_work);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
