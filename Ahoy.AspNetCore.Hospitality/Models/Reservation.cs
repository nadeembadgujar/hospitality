using System;
namespace Ahoy.AspNetCore.Hospitality.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string MadeBy { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Guest { get; set; }
    }
}
