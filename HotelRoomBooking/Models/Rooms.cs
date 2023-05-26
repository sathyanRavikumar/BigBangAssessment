using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomBooking.Models
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [ForeignKey(nameof(Hotels))]
        public int HotelId { get; set; }

        public int RoomNumber { get; set; }
        public string? status { get; set; }

        public int capacity { get; set; }

        public double price { get; set; }
        public ICollection<Resevation>? Resevations { get; set; }
    }
}
