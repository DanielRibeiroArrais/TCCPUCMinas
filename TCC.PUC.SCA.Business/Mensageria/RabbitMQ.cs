using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.PUC.SCA.Model.SpecificEntities.Common;
using static TCC.PUC.SCA.Business.Mensageria.RabbitMQConectar;

namespace TCC.PUC.SCA.Business.Mensageria
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

        public List<Mensagem> BasicGetMessage(string queue)
        {
            try
            {
                List<Mensagem> mensagens = new List<Mensagem>();
                Mensagem mensagem = null;

                using (var channel = Connection.CreateModel())
                {
                    while (true)
                    {
                        try
                        {
                            BasicGetResult result = channel.BasicGet(queue, true);

                            if (result == null)
                                break;
                            else
                            {
                                mensagem = new Mensagem();

                                mensagem.MessageId = new Guid(result.BasicProperties.MessageId);
                                mensagem.InclusionDate = Convert.ToDateTime(Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["InclusionDate"]));
                                mensagem.Nome = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["Nome"]);
                                mensagem.Email = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["Email"]);
                                mensagem.Celular = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["Celular"]);
                                mensagem.SMS = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["SMS"]);
                                mensagem.WhatsApp = Encoding.UTF8.GetString((byte[])result.BasicProperties.Headers["WhatsApp"]);
                                mensagem.Msg = mensagem.Nome + " " + Encoding.UTF8.GetString(result.Body);

                                mensagens.Add(mensagem);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                return mensagens;
            }
            catch (Exception ex)
            {
                throw new Exception($"Classe: RabbitMQ - Método: BasicGetMessageBackup - Erro: {ex.Message}");
            }
        }
    }
}
