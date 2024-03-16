using MediatR;
using MVM.SmartParking.Core.Application;

namespace MVM.SmartParking.Parking.Application.Commands.Handlers;

public class AddTickerCommandHandler : IRequestHandler<AddTicketCommand, View>
{
    public Task<View> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}