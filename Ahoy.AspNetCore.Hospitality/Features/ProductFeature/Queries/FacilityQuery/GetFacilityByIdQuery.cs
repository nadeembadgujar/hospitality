using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.FacilityQuery
{
    public class GetFacilityByIdQuery : IRequest<Facility>
    {
        public int Id { get; set; }
        public class GetFacilityByIdQueryHandler : IRequestHandler<GetFacilityByIdQuery, Facility>
        {
            private readonly IApplicationContext _context;
            public GetFacilityByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Facility> Handle(GetFacilityByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Facilities.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                return product;
            }

        }
    }
}
