using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class UpdateHotelCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateHotelCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateHotelCommand command, CancellationToken cancellationToken)
            {
                var hotel = _context.Hotels.Where(a => a.Id == command.Id).FirstOrDefault();
                if (hotel == null)
                {
                    return default;
                }
                else
                {
                    hotel.Name = command.Name;
                    hotel.Address = command.Address;
                    hotel.Latitude = command.Latitude;
                    hotel.Longitude = command.Longitude;
                    hotel.Description = command.Description;
                    hotel.Country = command.Country;
                    hotel.City = command.City;

                    await _context.SaveChangesAsync();
                    return hotel.Id;
                }
            }
        }
    }
}
