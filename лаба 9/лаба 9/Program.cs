using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_9
{
    public abstract class Notification
    {
        public string Message { get; set; }

        protected Notification(string message)
        {
            Message = message;
        }
    }
    public class NotificationContainer<T> where T : Notification, IComparable<T>
    {
        private List<T> NotificationsList;

        public NotificationContainer()
        {
            NotificationsList = new List<T>();
        }

        // Добавление уведомления
        public void AddNotification(T notification)
        {
            NotificationsList.Add(notification);
        }

        // Получение уведомления по индексу
        public T GetNotification(int index)
        {
            if (index < 0 || index >= NotificationsList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы диапазона.");
            }
            return NotificationsList[index];
        }

        // Проверка наличия уведомлений
        public bool HasNotifications()
        {
            return NotificationsList.Count > 0;
        }

        // Сортировка уведомлений
        public void SortNotifications()
        {
            NotificationsList.Sort();
        }

        // Получение всех уведомлений
        public IEnumerable<T> GetAllNotifications()
        {
            return NotificationsList;
        }
    }
    public class EmailNotification : Notification, IComparable<EmailNotification>
    {
        public DateTime SentTime { get; set; }

        public EmailNotification(string message, DateTime sentTime) : base(message)
        {
            SentTime = sentTime;
        }

        public int CompareTo(EmailNotification other)
        {
            return SentTime.CompareTo(other.SentTime);
        }

        public override string ToString()
        {
            return $"Email: {Message}, Sent: {SentTime}";
        }
    }
    public class SMSNotification : Notification, IComparable<SMSNotification>
    {
        public string PhoneNumber { get; set; }

        public SMSNotification(string message, string phoneNumber) : base(message)
        {
            PhoneNumber = phoneNumber;
        }

        public int CompareTo(SMSNotification other)
        {
            return PhoneNumber.CompareTo(other.PhoneNumber);
        }

        public override string ToString()
        {
            return $"SMS to {PhoneNumber}: {Message}";
        }
    }
    public class PushNotification : Notification, IComparable<PushNotification>
    {
        public string AppName { get; set; }

        public PushNotification(string message, string appName) : base(message)
        {
            AppName = appName;
        }

        public int CompareTo(PushNotification other)
        {
            return AppName.CompareTo(other.AppName);
        }

        public override string ToString()
        {
            return $"Push Notification from {AppName}: {Message}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Контейнер для EmailNotification
            var emailContainer = new NotificationContainer<EmailNotification>();
            emailContainer.AddNotification(new EmailNotification("Hello Email 1", DateTime.Now.AddMinutes(-2)));
            emailContainer.AddNotification(new EmailNotification("Hello Email 2", DateTime.Now.AddMinutes(1)));

            // Контейнер для SMSNotification
            var smsContainer = new NotificationContainer<SMSNotification>();
            smsContainer.AddNotification(new SMSNotification("Hello SMS", "+123456789"));

            // Контейнер для PushNotification
            var pushContainer = new NotificationContainer<PushNotification>();
            pushContainer.AddNotification(new PushNotification("Hello Push", "MyApp"));

            // Вывод всех уведомлений Email
            Console.WriteLine("Email Notifications:");
            foreach (var notification in emailContainer.GetAllNotifications())
            {
                Console.WriteLine(notification);
            }

            // Проверка наличия уведомлений SMS
            Console.WriteLine($"\nЕсть ли SMS уведомления? {smsContainer.HasNotifications()}");

            // Сортировка и вывод Email уведомлений
            emailContainer.SortNotifications();
            Console.WriteLine("\nСортированные Email Notifications:");
            foreach (var notification in emailContainer.GetAllNotifications())
            {
                Console.WriteLine(notification);
            }

            // Вывод уведомлений Push
            Console.WriteLine($"\nPush Notification: {pushContainer.GetNotification(0)}");
        }
    }
}
