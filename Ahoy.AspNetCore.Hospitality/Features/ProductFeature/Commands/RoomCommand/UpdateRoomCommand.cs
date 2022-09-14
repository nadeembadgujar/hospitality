using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class UpdateRoomCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, int>
        {


            private readonly IApplicationContext _context;
            public UpdateRoomCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
            {
                var room = _context.Rooms.Where(a => a.Id == command.Id).FirstOrDefault();
                if (room == null)
                {
                    return default;
                }
                else
                {
                    room.Name = command.Name;
                    room.HotelId = command.HotelId;
                    room.Name = command.Name;
                    room.Number = command.Number;
                    room.Type = command.Type;
                    room.Price = command.Price;
                    room.Description = command.Description;
                    await _context.SaveChangesAsync();
                    return room.Id;
                }
            }
        }
    }
}
