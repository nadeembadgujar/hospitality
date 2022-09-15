using System;
using System.Collections.Generic;
using Ahoy.AspNetCore.Hospitality.Contracts;
using Ahoy.AspNetCore.Hospitality.Models;

namespace Ahoy.AspNetCore.Hospitality.Services
{
    public class HotelService : IHotelService
    {
        public Hotel Add(Hotel newItem) => throw new NotImplementedException();

        public IEnumerable<Hotel> GetAllItems() => throw new NotImplementedException();

        public Hotel GetById(int id) => throw new NotImplementedException();

        public void Remove(int id) => throw new NotImplementedException();
    }
}
