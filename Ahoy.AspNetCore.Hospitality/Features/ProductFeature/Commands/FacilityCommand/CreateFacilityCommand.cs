using System;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class CreateFacilityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateFacilityCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateFacilityCommand request, CancellationToken cancellationToken)
            {
                var task = new Models.Facility
                {
                    Id = request.Id,
                    Name = request.Name,
                    HotelId=request.HotelId,
                    Image=request.Image

                };
                _context.Facilities.Add(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
