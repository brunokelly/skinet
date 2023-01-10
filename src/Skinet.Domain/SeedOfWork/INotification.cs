using static Skinet.Domain.SeedOfWork.NotificationModel;

namespace Skinet.Domain.SeedOfWork
{
      public interface INotification
    {
        NotificationModel? NotificationModel { get; }
        bool HasNotification { get; }
        void AddNotification(string key, string message, ENotificationType notificationType);
    }
}