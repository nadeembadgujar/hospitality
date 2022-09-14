using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class DeleteHotelRatingByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteHotelRatingByIdCommandHandler : IRequestHandler<DeleteHotelRatingByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteHotelRatingByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteHotelRatingByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _context.HotelRatings.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (task == null) return default;
                _context.HotelRatings.Remove(task);
                await _context.SaveChangesAsync();
                return task.Id;
            }
        }
    }
}
