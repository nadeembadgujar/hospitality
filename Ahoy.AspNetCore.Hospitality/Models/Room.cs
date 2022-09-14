using System;
namespace Ahoy.AspNetCore.Hospitality.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
