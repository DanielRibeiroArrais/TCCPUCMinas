using RabbitMQ.Client;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using static TCC.PUC.SCA.Alert.Email.Mensageria.RabbitMQConectar;

namespace TCC.PUC.SCA.Alert.Email.Mensageria
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
                            BasicGetResult result = channel.BasicGet("Email", false);

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

                                EnviarEmail(email, mensagem);
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

        private void EnviarEmail(string email, string mensagem)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("tccpucminasdanielarrais@gmail.com");
            mail.To.Add(email);
            mail.Subject = "ALERTA";
            mail.Body = mensagem;

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
    }
}
