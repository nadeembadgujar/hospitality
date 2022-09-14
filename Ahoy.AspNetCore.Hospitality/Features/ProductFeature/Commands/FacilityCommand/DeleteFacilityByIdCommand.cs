using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class DeleteFacilityByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteFacilityByIdCommandHandler : IRequestHandler<DeleteFacilityByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteFacilityByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteFacilityByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _context.Facilities.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (task == null) return default;
                _context.Facilities.Remove(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
