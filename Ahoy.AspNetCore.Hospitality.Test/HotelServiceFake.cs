using System;
using System.Collections.Generic;
using System.Linq;
using Ahoy.AspNetCore.Hospitality.Contracts;
using Ahoy.AspNetCore.Hospitality.Models;

namespace Ahoy.AspNetCore.Hospitality.Test
{
    public class HotelServiceFake : IHotelService
    {
        private readonly List<Hotel> _hotels;
        public HotelServiceFake()
        {
            _hotels = new List<Hotel>()
            {
                new Hotel() { Name = "JW Marriott Marquis Hotel Dubai" , Address = "Business bay" , City = "Dubai", Country = "UAE" , Description ="5*" , Latitude = 25.185633497310405, Longitude = 55.25810905475642},
                new Hotel() { Name = "Hilton Dubai Al Habtoor City" , Address = "Sheikh Zayed Rd - Dubai" , City = "Dubai", Country = "UAE" , Description ="In a high-rise building overlooking Dubai Water Canal, this upmarket hotel is 6 km from Jumeirah Beach Park on the Gulf, and 17 km from Dubai International Airport." , Latitude = 25.185633497310405, Longitude = 55.25810905475642},
                new Hotel() { Name = "CITY PREMIERE HOTEL APARTMENTS" , Address = "Business Bay - Dubai" , City = "Dubai", Country = "UAE" , Description ="5*" , Latitude = 25.185633497310405, Longitude = 55.25810905475642},
            };
        }


        public Hotel Add(Hotel newItem)
        {
            _hotels.Add(newItem);
            return newItem;
        }

        public IEnumerable<Hotel> GetAllItems()
        {
            return _hotels;
        }

        public Hotel GetById(int id)
        {
            return _hotels.Where(a =>
            {
                return a.Id == id;
            })
              .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _hotels.First(a => a.Id == id);
            _hotels.Remove(existing);
        }
    }
}
