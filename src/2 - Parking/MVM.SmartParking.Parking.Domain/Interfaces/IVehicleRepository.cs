using MVM.SmartParking.Data.Core;
using MVM.SmartParking.Parking.Domain.Entities;
using MVM.SmartParking.Parking.Domain.ValueObjects;

namespace MVM.SmartParking.Parking.Domain.Interfaces;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<Brand> GetBrandById(int id);
    Task<Model> GetModelById(int id);
    Task<Color> GetColorById(int id);
}