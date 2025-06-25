using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPostgreSQL_TestIntegrationProject.Models;

namespace DotNetPostgreSQL_TestIntegrationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceLevelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExperienceLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExperienceLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceLevel>>> GetExperienceLevels()
        {
            return await _context.ExperienceLevels.ToListAsync();
        }

        // GET: api/ExperienceLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceLevel>> GetExperienceLevel(int id)
        {
            var experienceLevel = await _context.ExperienceLevels.FindAsync(id);

            if (experienceLevel == null)
            {
                return NotFound();
            }

            return experienceLevel;
        }

        // PUT: api/ExperienceLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienceLevel(int id, ExperienceLevel experienceLevel)
        {
            if (id != experienceLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(experienceLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExperienceLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExperienceLevel>> PostExperienceLevel(ExperienceLevel experienceLevel)
        {
            _context.ExperienceLevels.Add(experienceLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperienceLevel", new { id = experienceLevel.Id }, experienceLevel);
        }

        // DELETE: api/ExperienceLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienceLevel(int id)
        {
            var experienceLevel = await _context.ExperienceLevels.FindAsync(id);
            if (experienceLevel == null)
            {
                return NotFound();
            }

            _context.ExperienceLevels.Remove(experienceLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienceLevelExists(int id)
        {
            return _context.ExperienceLevels.Any(e => e.Id == id);
        }
    }
}
