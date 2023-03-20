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
    public class PaidTimeOffController : ControllerBase
    {
        private readonly PTOContext _context;

        public PaidTimeOffController(PTOContext context)
        {
            _context = context;
        }

        // GET: api/PaidTimeOff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaidTimeOff>>> GetPaidTimeOffs()
        {
          if (_context.PaidTimeOffs == null)
          {
              return NotFound();
          }

            var ptos = await _context.PaidTimeOffs.ToListAsync();
            var response = ptos.Select(p => new
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                PtoDate = p.PtoDate,
                PtoType = _context?.PtoTypes?.Find(p.Type)
            });

            return Ok(response);
        }

        // GET: api/PaidTimeOff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaidTimeOff>> GetPaidTimeOff(long id)
        {
          if (_context.PaidTimeOffs == null)
          {
              return NotFound();
          }
            var paidTimeOff = await _context.PaidTimeOffs.FindAsync(id);

            if (paidTimeOff == null)
            {
                return NotFound();
            }

            paidTimeOff.PtoType = _context?.PtoTypes?.Find(paidTimeOff.Type);

            return paidTimeOff;
        }

        // PUT: api/PaidTimeOff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaidTimeOff(long id, PaidTimeOff paidTimeOff)
        {
            if (id != paidTimeOff.Id)
            {
                return BadRequest();
            }

            _context.Entry(paidTimeOff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaidTimeOffExists(id))
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

        // POST: api/PaidTimeOff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaidTimeOff>> PostPaidTimeOff(PaidTimeOff paidTimeOff)
        {
          if (_context.PaidTimeOffs == null)
          {
              return Problem("Entity set 'PTOContext.PaidTimeOffs'  is null.");
          }
            _context.PaidTimeOffs.Add(paidTimeOff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaidTimeOff", new { id = paidTimeOff.Id }, paidTimeOff);
        }

        // DELETE: api/PaidTimeOff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaidTimeOff(long id)
        {
            if (_context.PaidTimeOffs == null)
            {
                return NotFound();
            }
            var paidTimeOff = await _context.PaidTimeOffs.FindAsync(id);
            if (paidTimeOff == null)
            {
                return NotFound();
            }

            _context.PaidTimeOffs.Remove(paidTimeOff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaidTimeOffExists(long id)
        {
            return (_context.PaidTimeOffs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
