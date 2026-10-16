
using System.ComponentModel.DataAnnotations;

namespace WebAppi.Models
{
    public class TrainBooking
    {
        [Key]
        public int TicketID { get; set; }

        public string PassengerName { get; set; } = string.Empty;

        public string TrainNumber { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

        public DateTime JourneyDate { get; set; }

        public string SeatClass { get; set; } = string.Empty;
    }
}
