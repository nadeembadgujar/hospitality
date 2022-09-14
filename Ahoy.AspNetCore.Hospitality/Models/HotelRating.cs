using System;
namespace Ahoy.AspNetCore.Hospitality.Models
{
    public class HotelRating
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public double Rating { get; set; }
        public string Guest { get; set; }
        public string Review { get; set; }
    }
}
