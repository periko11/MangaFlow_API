using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.action;

namespace MangaFlow_API.Controllers
{
    [Route("api/actions")]
    [ApiController]
    public class actionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public actionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var actions = _context.action.ToList().Select(a => a.toactionDto());
            return Ok(actions);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var action = _context.action.Find(id);
            if (action == null)
            {
                return NotFound();
            }
            return Ok(action.toactionDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateactionDto actionDto)
        {
            var newAction = actionDto.CreateactionDto();
            _context.action.Add(newAction);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newAction.action_id }, newAction.toactionDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] UpdateactionDto actionDto)
        {
            var existingAction = _context.action.Find(id);
            if (existingAction == null)
            {
                return NotFound();
            }

            existingAction.user_id = actionDto.user_id;
            existingAction.chapter_id = actionDto.chapter_id;
            existingAction.role_id = actionDto.role_id;
            existingAction.type = actionDto.type;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var action = _context.action.Find(id);
            if (action == null)
            {
                return NotFound();
            }

            _context.action.Remove(action);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
