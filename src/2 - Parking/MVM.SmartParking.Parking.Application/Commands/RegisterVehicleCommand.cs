using System.ComponentModel.DataAnnotations;
using MediatR;
using MVM.SmartParking.Core.Application;
using MVM.SmartParking.Parking.Domain.Enum;

namespace MVM.SmartParking.Parking.Application.Commands;

public record RegisterVehicleCommand : IRequest<View>
{
    public string Plate { get; init; }
    public ETypeVehicle Type { get; init; }
    public int ColorId { get; init; }
    public int BrandId { get; init; }
    public int ModelId { get; init; }
}