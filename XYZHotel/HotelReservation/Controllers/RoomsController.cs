using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.Room;

namespace HotelReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _context;

        public RoomsController(IRoom context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room_Details>>> Getrooms()
        {
            try
            {
                return Ok(await _context.Getrooms());
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room_Details>> GetRoom(int id)
        {
            try
            {
                return Ok(await _context.GetRoom(id));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Room_Details>>> PutRoom(int id, Room_Details room)
        {

            try
            {
                return Ok(await _context.PutRoom(id,room));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room_Details>> PostRoom(Room_Details room)
        {
          if (_context.rooms == null)
          {
              return Problem("Entity set 'ModelDbContext.rooms'  is null.");
          }
            _context.rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.rooms == null)
            {
                return NotFound();
            }
            var room = await _context.rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return (_context.rooms?.Any(e => e.RoomId == id)).GetValueOrDefault();
        }
    }
}
