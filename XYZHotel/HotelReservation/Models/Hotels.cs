using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Hotels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        public string? HotelName { get; set; }

        public string? Location { get; set; }

        public ICollection<Room>? rooms { get; set; }
    }
}
