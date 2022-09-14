using System;
namespace Ahoy.AspNetCore.Hospitality.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
