namespace MVM.SmartParking.Core;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
        TimeStamp = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public DateTime TimeStamp { get; private set; }
}