using System.Collections.Generic;
using System.Linq;
using TCC.PUC.SCA.Business.Intefaces;

namespace TCC.PUC.SCA.Business.Notificacoes
{
    public class Notifier : INotificador
    {
        private List<Notification> _notificacoes;

        public Notifier()
        {
            _notificacoes = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HaveNotification()
        {
            return _notificacoes.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notificacoes;
        }

    }
}
