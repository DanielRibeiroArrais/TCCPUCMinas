using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading;
using TCC.PUC.SCA.Model.SpecificEntities.Common;

namespace TCC.PUC.SCA.Alert.SMS
{
    public partial class SMS : ServiceBase
    {
        private Timer tempo;
        private readonly string nomeAplicacao = System.AppDomain.CurrentDomain.FriendlyName.Substring(0, System.AppDomain.CurrentDomain.FriendlyName.Length - 4);
        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip };

        public SMS()
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
                List<Mensagem> mensagens = new Business.Mensageria.RabbitMQ().BasicGetMessage("SMS");

                foreach (Mensagem mensagem in mensagens)
                {
                    EnviarSMS(mensagem);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                tempo.Change(tempoParadoAplicacao, tempoParadoAplicacao);
            }
        }

        private void EnviarSMS(Mensagem mensagem)
        {
            const string API_KEY = "e513a253-658e-470b-b22d-9f7266924d40";
            var textMessageService = new Comtele.Sdk.Services.TextMessageService(API_KEY);
            textMessageService.Send("Barragem", mensagem.Msg, new string[] { mensagem.SMS.Replace("(", "").Replace(")", "").Replace("-", "") });
        }

        protected override void OnStop()
        {

        }
    }
}
