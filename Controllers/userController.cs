using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos;
using MangaFlow_API.Models;

namespace MangaFlow_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public userController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.user.ToList().Select(u => u.TouserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var user = _context.user.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.TouserDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateuserDto userDto)
        {
            var user = userDto.CreateuserDto();
            _context.user.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.user_id }, user.TouserDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] UpdateuserDto updateDto)
        {
            var user = _context.user.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.group_id = updateDto.group_id;
            user.username = updateDto.username;
            user.description = updateDto.description;
            user.status = updateDto.status;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var user = _context.user.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.user.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
