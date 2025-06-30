using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPostgreSQL_TestIntegrationProject.Models;
using Microsoft.AspNetCore.Cors;

namespace DotNetPostgreSQL_TestIntegrationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MechsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mechs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mech>>> GetMechs()
        {
            return await _context.Mechs.ToListAsync();
        }

        // GET: api/Mechs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mech>> GetMech(int id)
        {
            var mech = await _context.Mechs.FindAsync(id);

            if (mech == null)
            {
                return NotFound();
            }

            return mech;
        }

        // PUT: api/Mechs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMech(int id, Mech mech)
        {
            if (id != mech.Id)
            {
                return BadRequest();
            }

            _context.Entry(mech).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechExists(id))
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

        // POST: api/Mechs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mech>> PostMech(Mech mech)
        {
            _context.Mechs.Add(mech);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMech", new { id = mech.Id }, mech);
        }

        // DELETE: api/Mechs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMech(int id)
        {
            var mech = await _context.Mechs.FindAsync(id);
            if (mech == null)
            {
                return NotFound();
            }

            _context.Mechs.Remove(mech);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MechExists(int id)
        {
            return _context.Mechs.Any(e => e.Id == id);
        }
    }
}
