namespace MVM.SmartParking.Company.API.Services.Notifications;

public class Notify : INotify
{
    private ICollection<Notification?> _notification;

    public Notify()
    {
        _notification = new List<Notification>();
    }

    public bool AnyNotification()
    {
        return _notification.Any();
    }
    
    public void AddNotification(Notification notification)
    {
        if (notification is null) throw new ArgumentNullException("Messagem de notificação nula.");
        
        _notification.Add(notification);
    }

    public void AddNotification(string property, string message)
    {
        AddNotification(new Notification(property, message));
    }

    public void AddNotification(IEnumerable<Notification> notifications)
    {
        foreach (Notification notification in notifications)
        {
            AddNotification(notification);
        }
    }

    public ICollection<Notification?> GetNotifications()
    {
        return _notification;
    }
}