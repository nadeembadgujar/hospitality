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

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.HotelQuery
{
    public class GetAllHotels : IRequest<IEnumerable<Hotel>>
    {
        private PaginationFilter _filter;
        public GetAllHotels(PaginationFilter filter)
        {
            _filter = filter;
        }
        public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotels, IEnumerable<Hotel>>
        {
            private readonly IApplicationContext _context;
            public GetAllHotelsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Hotel>> Handle(GetAllHotels query, CancellationToken cancellationToken)
            {
               
                var taskList = await _context.Hotels.Skip((query._filter.PageNumber - 1) * query._filter.PageSize)
                .Take(query._filter.PageSize).ToListAsync();

                if (taskList == null)
                {
                    return null;
                }
                return taskList.AsReadOnly();
            }
        }
    }
}
