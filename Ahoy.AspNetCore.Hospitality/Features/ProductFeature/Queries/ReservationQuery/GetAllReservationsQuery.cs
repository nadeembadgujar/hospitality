using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Filter;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.ReservationQuery
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<Reservation>>
    {
        private PaginationFilter _filter;
        public GetAllReservationsQuery(PaginationFilter filter)
        {
            _filter = filter;
        }
        public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<Reservation>>
        {
            private readonly IApplicationContext _context;
            public GetAllReservationsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery query, CancellationToken cancellationToken)
            {
                var reservations = await _context.Reservations.ToListAsync();
                if (reservations == null)
                {
                    return null;
                }
                return reservations.AsReadOnly();
            }
        }
    }
}
