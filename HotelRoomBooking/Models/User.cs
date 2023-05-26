using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HotelRoomBooking.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        public string? userName { get; set; }
        public string emailId { get; set; } = string.Empty;
         
        public string? password { get; set; }

        public ICollection<Resevation>? Resevations { get; set; }
    }
}
