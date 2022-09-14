using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using Ahoy.AspNetCore.Hospitality.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.FacilityQuery
{
    public class GetAllFacilities : IRequest<IEnumerable<Facility>>
    {
        public class GetAllTasksQueryHandler : IRequestHandler<GetAllFacilities, IEnumerable<Models.Facility>>
        {
            private readonly IApplicationContext _context;
            public GetAllTasksQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Facility>> Handle(GetAllFacilities query, CancellationToken cancellationToken)
            {
                var taskList = await _context.Facilities.ToListAsync();
                if (taskList == null)
                {
                    return null;
                }
                return taskList.AsReadOnly();
            }
        }
    }
}
