using System;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class CreateHotelCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateHotelCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
            {
                var task = new Models.Hotel
                {
                    Id = request.Id,
                    Name = request.Name,
                    Address = request.Address,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    City = request.City,
                    Country = request.Country,
                    Description = request.Description

                };
                _context.Hotels.Add(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
