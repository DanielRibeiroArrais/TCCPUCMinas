using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Threading;
using TCC.PUC.SCA.Model.SpecificEntities.Common;

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
                List<Mensagem> mensagens = new Business.Mensageria.RabbitMQ().BasicGetMessage("Email");

                foreach (Mensagem mensagem in mensagens)
                {
                    EnviarEmail(mensagem);
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

        private void EnviarEmail(Mensagem mensagem)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("tccpucminasdanielarrais@gmail.com");
            mail.To.Add(mensagem.Email);
            mail.Subject = "ALERTA";
            mail.Body = mensagem.Msg;

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("tccpucminasdanielarrais@gmail.com", "@tcc@puc@minas");

                smtp.Send(mail);
            }
        }

        protected override void OnStop()
        {

        }
    }
}
