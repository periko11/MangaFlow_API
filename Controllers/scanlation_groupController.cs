using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.scanlation_group;

namespace MangaFlow_API.Controllers
{
    [Route("api/scanlation_group")]
    [ApiController]
    public class scanlation_groupController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public scanlation_groupController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = _context.scanlation_group.ToList().Select(s => s.Toscanlation_groupDto());
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var group = _context.scanlation_group.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group.Toscanlation_groupDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Createscanlation_groupDto groupDto)
        {
            var group = groupDto.Createscanlation_groupDto();
            _context.scanlation_group.Add(group);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = group.group_id }, group.Toscanlation_groupDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] Updatescanlation_groupDto updateDto)
        {
            var group = _context.scanlation_group.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            group.name = updateDto.name;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var group = _context.scanlation_group.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            _context.scanlation_group.Remove(group);
            _context.SaveChanges();

            return NoContent();
        }
    }
}