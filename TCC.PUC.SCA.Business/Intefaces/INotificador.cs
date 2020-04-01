using System.Collections.Generic;
using TCC.PUC.SCA.Business.Notificacoes;

namespace TCC.PUC.SCA.Business.Intefaces
{
    public interface INotificador
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
