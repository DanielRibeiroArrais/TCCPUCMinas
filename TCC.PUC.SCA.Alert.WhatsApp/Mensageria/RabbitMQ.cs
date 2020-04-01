using RabbitMQ.Client;
using System;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using static TCC.PUC.SCA.Alert.WhatsApp.Mensageria.RabbitMQConectar;

namespace TCC.PUC.SCA.Alert.WhatsApp.Mensageria
{
    public class RabbitMQ : RabbitMQBase
    {
        public void BasicGetMessageBackup()
        {
            try
            {
                using (var channel = Connection.CreateModel())
                {
                    while (true)
                    {
                        try
                        {
                            BasicGetResult result = channel.BasicGet("WhatsApp", false);

                            if (result == null)
                                break;
                            else
                            {
                                Guid messageId = new Guid(result.BasicProperties.MessageId);
                                DateTime inclusionDate = Convert.ToDateTime(Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["InclusionDate"]));
                                string nome = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["Nome"]);
                                string email = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["Email"]);
                                string celular = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["Celular"]);
                                string sms = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["SMS"]);
                                string whatsapp = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["WhatsApp"]);
                                string mensagem = Encoding.UTF8.GetString(result.Body);

                                EnviarWhatsApp(whatsapp, mensagem);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Classe: RabbitMQ - Método: BasicGetMessageBackup - Erro: {ex.Message}");
            }
        }

        private void EnviarWhatsApp(string numero, string mensagem)
        {
            numero = "+55" + numero.Replace("(", "").Replace(")", "").Replace("-", "");

            const string accountSid = "ACc66d4070d3030d98cd50c76d6a9b92cb";
            const string authToken = "7cc5e7d4cf52dac2ac3275f6e4293177";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: mensagem,
                from: new Twilio.Types.PhoneNumber("+12029521859"),
                to: new Twilio.Types.PhoneNumber(numero)
            );
        }
    }
}
