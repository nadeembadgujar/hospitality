using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.HotelQuery
{
    public class GetHotelByIdQuery : IRequest<Hotel>
    {
        public int Id { get; set; }
        public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, Hotel>
        {
            private readonly IApplicationContext _context;
            public GetHotelByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Hotel> Handle(GetHotelByIdQuery query, CancellationToken cancellationToken)
            {
                var hotel = await _context.Hotels.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (hotel == null) return null;
                return hotel;
            }

        }
    }
}
