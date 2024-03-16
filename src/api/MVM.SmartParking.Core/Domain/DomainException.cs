namespace MVM.SmartParking.Domain.Core;

public class DomainException : Exception
{
    public string Property { get; init; }
    

    public DomainException(string? property, string? message) : base(message)
    {
        Property = property;
    }
    
    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}