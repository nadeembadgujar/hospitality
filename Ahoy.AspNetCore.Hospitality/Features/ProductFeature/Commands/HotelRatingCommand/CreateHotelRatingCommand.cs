using System;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class CreateHotelRatingCommand : IRequest<int>
    {


        public int Id { get; set; }
        public int HotelId { get; set; }
        public double Rating { get; set; }
        public string Guest { get; set; }
        public string Review { get; set; }

        public class CreateHotelRatingCommandHandler : IRequestHandler<CreateHotelRatingCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateHotelRatingCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateHotelRatingCommand request, CancellationToken cancellationToken)
            {
                var HotelRating = new Models.HotelRating
                {
                    Id = request.Id,
                    HotelId = request.HotelId,
                    Rating = request.Rating,
                    Guest = request.Guest,
                    Review= request.Review
                };
                _context.HotelRatings.Add(HotelRating);
                await _context.SaveChangesAsync();
                return HotelRating.Id;
            }
        }
    }
}
