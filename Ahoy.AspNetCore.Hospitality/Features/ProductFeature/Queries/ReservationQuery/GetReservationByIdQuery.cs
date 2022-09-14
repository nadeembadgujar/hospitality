using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.ReservationQuery
{
    public class GetReservationByIdQuery : IRequest<Reservation>
    {
        public int Id { get; set; }
        public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Reservation>
        {
            private readonly IApplicationContext _context;
            public GetReservationByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Reservation> Handle(GetReservationByIdQuery query, CancellationToken cancellationToken)
            {
                var Reservation = await _context.Reservations.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (Reservation == null) return null;
                return Reservation;
            }

        }
    }
}
