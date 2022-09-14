using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class DeleteRoomByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteRoomByIdCommandHandler : IRequestHandler<DeleteRoomByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteRoomByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteRoomByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _context.Rooms.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (task == null) return default;
                _context.Rooms.Remove(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
