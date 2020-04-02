using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceProcess;
using System.Threading;
using TCC.PUC.SCA.Model.SpecificEntities.Common;

namespace TCC.PUC.SCA.Alert.WhatsApp
{
    public partial class WhatsApp : ServiceBase
    {
        private Timer tempo;
        private readonly string nomeAplicacao = System.AppDomain.CurrentDomain.FriendlyName.Substring(0, System.AppDomain.CurrentDomain.FriendlyName.Length - 4);

        public WhatsApp()
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
                List<Mensagem> mensagens = new Business.Mensageria.RabbitMQ().BasicGetMessage("WhatsApp");

                foreach (Mensagem mensagem in mensagens)
                {
                    EnviarWhatsApp(mensagem);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                tempo.Change(tempoParadoAplicacao, tempoParadoAplicacao);
            }
        }

        private void EnviarWhatsApp(Mensagem mensagem)
        {

        }

        protected override void OnStop()
        {
        }
    }
}
