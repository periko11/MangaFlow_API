using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Dtos.tag;
using MangaFlow_API.Models;

namespace MangaFlow_API.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TagController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _context.tag.ToList().Select(t => new tagDto { tag_id = t.tag_id, name = t.name });
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var tag = _context.tag.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(new tagDto { tag_id = tag.tag_id, name = tag.name });
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatetagDto tagDto)
        {
            var newTag = new tag { name = tagDto.name };
            _context.tag.Add(newTag);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newTag.tag_id }, new tagDto { tag_id = newTag.tag_id, name = newTag.name });
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] UpdatetagDto tagDto)
        {
            var existingTag = _context.tag.Find(id);
            if (existingTag == null)
            {
                return NotFound();
            }

            existingTag.name = tagDto.name;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var tag = _context.tag.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.tag.Remove(tag);
            _context.SaveChanges();

            return NoContent();
        }
    }
}