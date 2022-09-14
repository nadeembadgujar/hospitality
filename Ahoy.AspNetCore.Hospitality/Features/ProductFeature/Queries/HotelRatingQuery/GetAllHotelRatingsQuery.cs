using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.HotelRatingQuery
{
    public class GetAllHotelRatings : IRequest<IEnumerable<HotelRating>>
    {
        public class GetAllHotelRatingsQueryHandler : IRequestHandler<GetAllHotelRatings, IEnumerable<HotelRating>>
        {
            private readonly IApplicationContext _context;
            public GetAllHotelRatingsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<HotelRating>> Handle(GetAllHotelRatings query, CancellationToken cancellationToken)
            {
                var taskList = await _context.HotelRatings.ToListAsync();
                if (taskList == null)
                {
                    return null;
                }
                return taskList.AsReadOnly();
            }
        }
    }
}
