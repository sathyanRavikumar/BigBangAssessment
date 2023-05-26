using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelRoomBooking.Data;
using HotelRoomBooking.Models;

namespace HotelRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResevationsController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public ResevationsController(ModelDbContext context)
        {
            _context = context;
        }

        // GET: api/Resevations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resevation>>> Getresevations()
        {
          if (_context.resevations == null)
          {
              return NotFound();
          }
            return await _context.resevations.ToListAsync();
        }

        // GET: api/Resevations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resevation>> GetResevation(int id)
        {
          if (_context.resevations == null)
          {
              return NotFound();
          }
            var resevation = await _context.resevations.FindAsync(id);

            if (resevation == null)
            {
                return NotFound();
            }

            return resevation;
        }

        // PUT: api/Resevations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResevation(int id, Resevation resevation)
        {
            if (id != resevation.reserId)
            {
                return BadRequest();
            }

            _context.Entry(resevation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResevationExists(id))
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

        // POST: api/Resevations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resevation>> PostResevation(Resevation resevation)
        {
          if (_context.resevations == null)
          {
              return Problem("Entity set 'ModelDbContext.resevations'  is null.");
          }
            _context.resevations.Add(resevation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResevation", new { id = resevation.reserId }, resevation);
        }

        // DELETE: api/Resevations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResevation(int id)
        {
            if (_context.resevations == null)
            {
                return NotFound();
            }
            var resevation = await _context.resevations.FindAsync(id);
            if (resevation == null)
            {
                return NotFound();
            }

            _context.resevations.Remove(resevation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResevationExists(int id)
        {
            return (_context.resevations?.Any(e => e.reserId == id)).GetValueOrDefault();
        }
    }
}
