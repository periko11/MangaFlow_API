using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.role;

namespace MangaFlow_API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class roleController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public roleController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _context.role.ToList().Select(r => r.toroleDto());
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var role = _context.role.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role.toroleDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateroleDto roleDto)
        {
            var newRole = roleDto.CreaterolDto();
            _context.role.Add(newRole);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newRole.role_id }, newRole.toroleDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] UpdateroleDto roleDto)
        {
            var existingRole = _context.role.Find(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.name = roleDto.name;
            existingRole.permissions = roleDto.permissions;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var role = _context.role.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.role.Remove(role);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
