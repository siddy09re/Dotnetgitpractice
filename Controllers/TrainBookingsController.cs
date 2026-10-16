
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppi.Models;

namespace WebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainBookingsController : ControllerBase
    {
        private readonly Appdb _context;

        public TrainBookingsController()
        {
            _context = new Appdb();
        }

        // POST: api/TrainBookings
        [HttpPost]
        public async Task<ActionResult<TrainBooking>> PostBooking(
            TrainBooking booking)
        {
            _context.TrainBookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBooking),
                new { id = booking.TicketID },
                booking);
        }

        // GET: api/TrainBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainBooking>> GetBooking(int id)
        {
            var booking = await _context.TrainBookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }



        // PUT: api/TrainBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(
            int id, TrainBooking updatedBooking)
        {
            var booking = await _context.TrainBookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.PassengerName = updatedBooking.PassengerName;
            booking.TrainNumber = updatedBooking.TrainNumber;
            booking.Source = updatedBooking.Source;
            booking.Destination = updatedBooking.Destination;
            booking.JourneyDate = updatedBooking.JourneyDate;
            booking.SeatClass = updatedBooking.SeatClass;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // PATCH: api/TrainBookings/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBooking(
            int id, [FromBody] string destination)
        {
            var booking = await _context.TrainBookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.Destination = destination;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/TrainBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.TrainBookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }


            // 3. Store the booking data before deleting
            var deletedBooking = new
            {
                booking.TicketID,
                booking.PassengerName,
                booking.TrainNumber,
                booking.Source,
                booking.Destination,
                booking.JourneyDate,
                booking.SeatClass
            };

            _context.TrainBookings.Remove(booking);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Booking deleted successfully.",
                deletedData = deletedBooking
            });
        }



    }
}
