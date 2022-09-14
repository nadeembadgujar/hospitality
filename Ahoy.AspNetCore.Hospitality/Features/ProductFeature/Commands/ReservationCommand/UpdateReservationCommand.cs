using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands
{
    public class UpdateReservationCommand : IRequest<int>
    {

        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string MadeBy { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, int>
        {


            private readonly IApplicationContext _context;
            public UpdateReservationCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateReservationCommand command, CancellationToken cancellationToken)
            {
                var reservation = _context.Reservations.Where(a => a.Id == command.Id).FirstOrDefault();
                if (reservation == null)
                {
                    return default;
                }
                else
                {
                    reservation.HotelId = command.HotelId;
                    reservation.RoomId = command.RoomId;
                    reservation.MadeBy = command.MadeBy;
                    reservation.DateOut = command.DateOut;
                    reservation.DateIn = command.DateIn;

                    await _context.SaveChangesAsync();
                    return reservation.Id;
                }
            }
        }
    }
}
