using System;
using System.Collections.Generic;
using Ahoy.AspNetCore.Hospitality.Models;

namespace Ahoy.AspNetCore.Hospitality.Contracts
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAllItems();
        Hotel Add(Hotel newItem);
        Hotel GetById(int id);
        void Remove(int id);
    }
}
