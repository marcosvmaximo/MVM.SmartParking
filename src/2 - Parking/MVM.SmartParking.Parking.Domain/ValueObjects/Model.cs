using MVM.SmartParking.Domain.Core;

namespace MVM.SmartParking.Parking.Domain.ValueObjects;

public class Model : ValueObject
{
    public Model(int id, string name)
    {
        SerialId = id;
        Name = name;
    }
    
    protected Model(){}
    
    public int SerialId { get; private set; }
    public string Name { get; private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}