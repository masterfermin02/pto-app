using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PtoApp.Models;

namespace PtoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PtoTypesController : ControllerBase
    {
        private readonly PTOContext _context;

        public PtoTypesController(PTOContext context)
        {
            _context = context;
        }

        // GET: api/PtoTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PtoType>>> GetPtoTypes()
        {
          if (_context.PtoTypes == null)
          {
              return NotFound();
          }
            return await _context.PtoTypes.Include(t => t.PaidTimeOffs).ToListAsync();
        }

        // GET: api/PtoTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PtoType>> GetPtoType(long id)
        {
          if (_context.PtoTypes == null)
          {
              return NotFound();
          }
            var ptoType = await _context.PtoTypes.FindAsync(id);

            if (ptoType == null)
            {
                return NotFound();
            }

            return ptoType;
        }

        // PUT: api/PtoTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPtoType(long id, PtoType ptoType)
        {
            if (id != ptoType.Id)
            {
                return BadRequest();
            }

            _context.Entry(ptoType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PtoTypeExists(id))
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

        // POST: api/PtoTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PtoType>> PostPtoType(PtoType ptoType)
        {
          if (_context.PtoTypes == null)
          {
              return Problem("Entity set 'PTOContext.PtoTypes'  is null.");
          }
            _context.PtoTypes.Add(ptoType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPtoType", new { id = ptoType.Id }, ptoType);
        }

        // DELETE: api/PtoTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePtoType(long id)
        {
            if (_context.PtoTypes == null)
            {
                return NotFound();
            }
            var ptoType = await _context.PtoTypes.FindAsync(id);
            if (ptoType == null)
            {
                return NotFound();
            }

            _context.PtoTypes.Remove(ptoType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PtoTypeExists(long id)
        {
            return (_context.PtoTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
