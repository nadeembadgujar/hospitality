using System;
namespace Ahoy.AspNetCore.Hospitality.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }
}
