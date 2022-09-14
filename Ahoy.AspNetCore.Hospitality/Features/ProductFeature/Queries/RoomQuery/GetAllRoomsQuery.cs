using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Filter;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.FacilityQuery
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<Room>>
    {
        private PaginationFilter _filter;
        public GetAllRoomsQuery(PaginationFilter filter)
        {
            _filter = filter;
        }

        public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<Room>>
        {
            private readonly IApplicationContext _context;
            public GetAllRoomsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Room>> Handle(GetAllRoomsQuery query, CancellationToken cancellationToken)
            {
                var rooms = await _context.Rooms.Skip((query._filter.PageNumber - 1) * query._filter.PageSize)
                .Take(query._filter.PageSize).ToListAsync();
                if (rooms == null)
                {
                    return null;
                }
                return rooms.AsReadOnly();
            }
        }
    }
}
