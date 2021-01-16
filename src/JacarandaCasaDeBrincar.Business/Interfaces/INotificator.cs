using JacarandaCasaDeBrincar.Business.Notificacoes;
using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface INotificator
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
