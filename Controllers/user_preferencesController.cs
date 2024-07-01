using Microsoft.AspNetCore.Mvc;
using MangaFlow_API.Data;
using MangaFlow_API.Mappers;
using MangaFlow_API.Dtos.user_preferences;

namespace MangaFlow_API.Controllers
{
    [Route("api/user_preferences")]
    [ApiController]
    public class user_preferencesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public user_preferencesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("{user_id}")]
        public IActionResult GetByUserId([FromRoute] long user_id)
        {
            var user_preferences = _context.user_preferences.Find(user_id);
            if (user_preferences == null)
            {
                return NotFound();
            }
            return Ok(user_preferences.touser_preferencesDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Createuser_preferencesDto user_preferencesDto)
        {
            var newUser_preferences = user_preferencesDto.Createuser_preferencesDto();
            _context.user_preferences.Add(newUser_preferences);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetByUserId), new { user_id = newUser_preferences.user_id }, newUser_preferences.touser_preferencesDto());
        }

        [HttpPut("{user_id}")]
        public IActionResult Update([FromRoute] long user_id, [FromBody] Updateuser_preferencesDto user_preferencesDto)
        {
            var existingUser_preferences = _context.user_preferences.Find(user_id);
            if (existingUser_preferences == null)
            {
                return NotFound();
            }

            existingUser_preferences.allow_adult_content = user_preferencesDto.allow_adult_content;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{user_id}")]
        public IActionResult Delete([FromRoute] long user_id)
        {
            var user_preferences = _context.user_preferences.Find(user_id);
            if (user_preferences == null)
            {
                return NotFound();
            }

            _context.user_preferences.Remove(user_preferences);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
