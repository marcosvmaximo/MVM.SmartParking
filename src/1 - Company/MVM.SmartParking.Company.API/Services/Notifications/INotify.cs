namespace MVM.SmartParking.Company.API.Services.Notifications;

public interface INotify
{
    bool AnyNotification();
    void AddNotification(Notification notification);
    void AddNotification(string property, string message);
    void AddNotification(IEnumerable<Notification> notification);
    ICollection<Notification?> GetNotifications();
}