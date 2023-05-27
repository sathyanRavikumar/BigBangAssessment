using HotelReservation.Models;
using HotelReservation.Repository.counts;
using HotelReservation.Repository.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelReservation.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly ICount _context;

        public CountController(ICount context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<int>> RoomCount(string hotelname)
        {
            try
            {
                return Ok(await _context.RoomCount(hotelname));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("Each hotel room count")]
        public async Task<ActionResult<List<CountBuffer>>> HotelsRoomCount()
        {
            try
            {
                return Ok(await _context.HotelsRoomCount());
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
