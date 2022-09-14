using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.RoomQuery
{
    public class GetRoomRatingByIdQuery : IRequest<Room>
    {
        public int Id { get; set; }
        public class GetRoomRatingByIdQueryHandler : IRequestHandler<GetRoomRatingByIdQuery, Room>
        {
            private readonly IApplicationContext _context;
            public GetRoomRatingByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(GetRoomRatingByIdQuery query, CancellationToken cancellationToken)
            {
                var RoomRating = await _context.Rooms.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (RoomRating == null) return null;
                return RoomRating;
            }

        }
    }
}
