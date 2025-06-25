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
    public class MechwarriorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MechwarriorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mechwarriors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mechwarrior>>> GetMechwarriors()
        {
            return await _context.Mechwarriors.ToListAsync();
        }

        // GET: api/Mechwarriors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mechwarrior>> GetMechwarrior(int id)
        {
            var mechwarrior = await _context.Mechwarriors.FindAsync(id);

            if (mechwarrior == null)
            {
                return NotFound();
            }

            return mechwarrior;
        }

        // PUT: api/Mechwarriors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMechwarrior(int id, Mechwarrior mechwarrior)
        {
            if (id != mechwarrior.Id)
            {
                return BadRequest();
            }

            _context.Entry(mechwarrior).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechwarriorExists(id))
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

        // POST: api/Mechwarriors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mechwarrior>> PostMechwarrior(Mechwarrior mechwarrior)
        {
            _context.Mechwarriors.Add(mechwarrior);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMechwarrior", new { id = mechwarrior.Id }, mechwarrior);
        }

        // DELETE: api/Mechwarriors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMechwarrior(int id)
        {
            var mechwarrior = await _context.Mechwarriors.FindAsync(id);
            if (mechwarrior == null)
            {
                return NotFound();
            }

            _context.Mechwarriors.Remove(mechwarrior);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MechwarriorExists(int id)
        {
            return _context.Mechwarriors.Any(e => e.Id == id);
        }
    }
}
