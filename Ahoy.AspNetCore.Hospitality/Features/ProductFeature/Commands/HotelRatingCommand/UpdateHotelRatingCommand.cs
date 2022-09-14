using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class UpdateHotelRatingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public double Rating { get; set; }
        public string Guest { get; set; }
        public string Review { get; set; }


        public class UpdateHotelRatingCommandHandler : IRequestHandler<UpdateHotelRatingCommand, int>
        {


            private readonly IApplicationContext _context;
            public UpdateHotelRatingCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateHotelRatingCommand command, CancellationToken cancellationToken)
            {
                var hotelRating = _context.HotelRatings.Where(a => a.Id == command.Id).FirstOrDefault();
                if (hotelRating == null)
                {
                    return default;
                }
                else
                {
                    hotelRating.HotelId = command.HotelId;
                    hotelRating.Rating = command.Rating;
                    hotelRating.Guest = command.Guest;
                    hotelRating.Review = command.Review;

                    await _context.SaveChangesAsync();
                    return hotelRating.Id;
                }
            }
        }
    }
}
