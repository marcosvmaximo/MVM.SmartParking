using MediatR;
using MVM.SmartParking.Core.Application;
using MVM.SmartParking.Parking.Domain.Entities;
using MVM.SmartParking.Parking.Domain.Interfaces;

namespace MVM.SmartParking.Parking.Application.Commands.Handlers;

public class RegisterVehicleCommandHandler : IRequestHandler<RegisterVehicleCommand, View>
{
    private readonly IVehicleRepository _repository;

    public RegisterVehicleCommandHandler(IVehicleRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<View> Handle(RegisterVehicleCommand message, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetBrandById(message.BrandId);
        var model = await _repository.GetModelById(message.ModelId);
        var color = await _repository.GetColorById(message.ColorId);
        
        Vehicle vehicle = new(message.Plate, message.Type, brand, model, color);
        
    }
}