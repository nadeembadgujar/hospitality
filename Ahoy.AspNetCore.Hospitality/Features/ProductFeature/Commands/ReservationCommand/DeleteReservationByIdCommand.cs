using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class DeleteReservationByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteReservationByIdCommandHandler : IRequestHandler<DeleteReservationByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteReservationByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteReservationByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _context.Reservations.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (task == null) return default;
                _context.Reservations.Remove(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
