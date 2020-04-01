using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using static TCC.PUC.SCA.Alert.Mensageria.RabbitMQConectar;

namespace TCC.PUC.SCA.Alert.Mensageria
{
    public class RabbitMQ : RabbitMQBase
    {
        public void BasicPublish(string mensagem, string nome, string email, string celular, string sms, string whatsapp)
        {
            try
            {
                Guid? guid = null;

                using (var channel = Connection.CreateModel())
                {
                    guid = Guid.NewGuid();

                    IBasicProperties iBasicProperties = channel.CreateBasicProperties();
                    iBasicProperties.Persistent = true;
                    iBasicProperties.MessageId = guid.ToString();

                    iBasicProperties.Headers = new Dictionary<string, object>();
                    iBasicProperties.Headers.Add("InclusionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    iBasicProperties.Headers.Add("Nome", nome);
                    iBasicProperties.Headers.Add("Email", email);
                    iBasicProperties.Headers.Add("Celular", celular);
                    iBasicProperties.Headers.Add("SMS", sms);
                    iBasicProperties.Headers.Add("WhatsApp", whatsapp);

                    channel.BasicPublish(exchange: "Alerta.Fanout", routingKey: "", basicProperties: iBasicProperties, body: Encoding.UTF8.GetBytes(mensagem));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"EnviarMensagem - Não foi possivel enviar a Mensagem o fila de Backup. Erro: {ex.Message}");
            }
        }
    }
}
