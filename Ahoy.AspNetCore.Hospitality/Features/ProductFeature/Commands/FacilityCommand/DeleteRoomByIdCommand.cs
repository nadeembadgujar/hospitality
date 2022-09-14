using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class DeleteHotelByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteHotelByIdCommandHandler : IRequestHandler<DeleteHotelByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteHotelByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteHotelByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _context.Hotels.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (task == null) return default;
                _context.Hotels.Remove(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
