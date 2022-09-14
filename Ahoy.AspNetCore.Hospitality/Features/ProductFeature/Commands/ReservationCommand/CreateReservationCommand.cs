using System;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class CreateReservationCommand : IRequest<int>
    {

        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string MadeBy { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Guest { get; set; }

        public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateReservationCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
            {
                var Reservation = new Models.Reservation
                {
                    Id = request.Id,
                    HotelId = request.HotelId,
                    RoomId = request.RoomId,
                    MadeBy =request.MadeBy,
                    DateIn = request.DateIn,
                    DateOut = request.DateOut,
                    Guest = request.Guest
                };
                _context.Reservations.Add(Reservation);
                await _context.SaveChangesAsync();
                return Reservation.Id;
            }
        }
    }
}
