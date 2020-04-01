using System;
using System.Globalization;
using System.ServiceProcess;
using System.Threading;

namespace TCC.PUC.SCA.Alert.Email
{
    public partial class Email : ServiceBase
    {
        private Timer tempo;
        private readonly string nomeAplicacao = System.AppDomain.CurrentDomain.FriendlyName.Substring(0, System.AppDomain.CurrentDomain.FriendlyName.Length - 4);

        public Email()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            tempo = new Timer(new TimerCallback(Iniciar), null, 0, 0);
        }

        private void Iniciar(object sender)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            tempo.Change(Timeout.Infinite, Timeout.Infinite);
            int tempoParadoAplicacao = 10000;

            try
            {
                new Mensageria.RabbitMQ().BasicGetMessageBackup();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                tempo.Change(tempoParadoAplicacao, tempoParadoAplicacao);
            }
        }

        protected override void OnStop()
        {

        }
    }
}
