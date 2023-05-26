using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomBooking.Models
{
    public class Hotels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        public string? HotelName { get; set;}

        public string? Location { get; set; }

        public ICollection<Rooms>? rooms { get; set; }
        
    }
}
