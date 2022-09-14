using System;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class CreateRoomCommand : IRequest<int>
    {

        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateRoomCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                var room = new Models.Room
                {
                    Id = request.Id,
                    HotelId = request.HotelId,
                    Name = request.Name,
                    Number =request.Number,
                    Type = request.Type,
                    Price = request.Price,
                    Description = request.Description
                };
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room.Id;
            }
        }
    }
}
