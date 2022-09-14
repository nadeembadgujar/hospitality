using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class UpdateFacilityCommand : IRequest<int>
    {

        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, int>
        {


            private readonly IApplicationContext _context;
            public UpdateFacilityCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateFacilityCommand command, CancellationToken cancellationToken)
            {
                var facility = _context.Facilities.Where(a => a.Id == command.Id).FirstOrDefault();
                if (facility == null)
                {
                    return default;
                }
                else
                {
                    facility.Name = command.Name;
                    facility.HotelId = command.HotelId;
                    facility.Image = command.Image;
                    await _context.SaveChangesAsync();
                    return facility.Id;
                }
            }
        }
    }
}
