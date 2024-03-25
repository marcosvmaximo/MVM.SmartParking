namespace MVM.SmartParking.Company.API.Services.Notifications;

public class Notification
{
    public Notification(string property, string message)
    {
        Property = property;
        Message = message;
    }

    public string Property { get; }
    public string Message { get; }
}