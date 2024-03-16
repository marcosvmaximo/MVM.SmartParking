using MediatR;
using MVM.SmartParking.Core.Application;

namespace MVM.SmartParking.Parking.Application.Commands;

public record AddTicketCommand : IRequest<View>
{
    
}