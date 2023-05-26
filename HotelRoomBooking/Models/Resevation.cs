using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomBooking.Models
{
    public class Resevation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reserId { get; set; }

        [ForeignKey(nameof(User))]
        public int userId { get; set; }

        [ForeignKey(nameof(Rooms))]
        public int RoomId { get; set; }

        public string? Cust_address { get; set; }
        public DateFormat checkIn { get; set; }
        public DateFormat checkOut { get; set; }



    }
}
