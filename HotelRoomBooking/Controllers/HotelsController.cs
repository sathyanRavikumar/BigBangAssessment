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
    public class HotelsController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public HotelsController(ModelDbContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> Gethotels()
        {
          if (_context.hotels == null)
          {
              return NotFound();
          }
            return await _context.hotels.ToListAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotels>> GetHotels(int id)
        {
          if (_context.hotels == null)
          {
              return NotFound();
          }
            var hotels = await _context.hotels.FindAsync(id);

            if (hotels == null)
            {
                return NotFound();
            }

            return hotels;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotels hotels)
        {
            if (id != hotels.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(hotels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotels>> PostHotels(Hotels hotels)
        {
          if (_context.hotels == null)
          {
              return Problem("Entity set 'ModelDbContext.hotels'  is null.");
          }
            _context.hotels.Add(hotels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotels", new { id = hotels.HotelId }, hotels);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotels(int id)
        {
            if (_context.hotels == null)
            {
                return NotFound();
            }
            var hotels = await _context.hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }

            _context.hotels.Remove(hotels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelsExists(int id)
        {
            return (_context.hotels?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
