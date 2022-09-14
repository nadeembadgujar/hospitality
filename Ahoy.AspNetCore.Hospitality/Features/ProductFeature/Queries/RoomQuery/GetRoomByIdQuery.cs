using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.HotelRatingRatingQuery
{
    public class GetHotelRatingByIdQuery : IRequest<HotelRating>
    {
        public int Id { get; set; }
        public class GetHotelRatingByIdQueryHandler : IRequestHandler<GetHotelRatingByIdQuery, HotelRating>
        {
            private readonly IApplicationContext _context;
            public GetHotelRatingByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<HotelRating> Handle(GetHotelRatingByIdQuery query, CancellationToken cancellationToken)
            {
                var HotelRating = await _context.HotelRatings.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (HotelRating == null) return null;
                return HotelRating;
            }

        }
    }
}
