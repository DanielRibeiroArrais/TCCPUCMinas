using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.PUC.SCA.Alert.Models;

namespace TCC.PUC.SCA.Alert
{
    public partial class Alert : ServiceBase
    {
        private Timer tempo;
        private readonly string nomeAplicacao = System.AppDomain.CurrentDomain.FriendlyName.Substring(0, System.AppDomain.CurrentDomain.FriendlyName.Length - 4);

        public Alert()
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
                using (var httpClient = new HttpClient())
                {
                    HttpContent httpContent = new StringContent("{\"Usuario\": \"api\", \"Senha\": \"123456\"}", Encoding.UTF8, "application/json");
                    HttpResponseMessage responseAutenticar = httpClient.PostAsync("https://localhost:44396/api/Login/Autenticar", httpContent).Result;
                    object objectConversion1 = JsonConvert.DeserializeObject<ClientLoginResponse>(responseAutenticar.Content.ReadAsStringAsync().Result);
                    ClientLoginResponse clientLoginResponse = (ClientLoginResponse)Convert.ChangeType(objectConversion1, typeof(ClientLoginResponse));


                    ClientLoginResponse c = new ClientLoginResponse();

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", clientLoginResponse.data.AccessToken);
                    HttpResponseMessage response = httpClient.GetAsync("https://localhost:44396/api/Alerta/Get").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        object objectConversion = JsonConvert.DeserializeObject<List<Alerta>>(response.Content.ReadAsStringAsync().Result);
                        List<Alerta> lAlerta = (List<Alerta>)Convert.ChangeType(objectConversion, typeof(List<Alerta>));

                        if (lAlerta.Count > 0)
                        {
                            List<Action> lAcoesProcessar = new List<Action>();

                            foreach (Alerta alerta in lAlerta)
                            {
                                try
                                {
                                    lAcoesProcessar.Add(async () => await Processar(alerta));
                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                            }
                            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = 10 };
                            Parallel.Invoke(options, lAcoesProcessar.ToArray());
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                        throw new Exception($"{ response.StatusCode.ToString() }");
                    else
                        throw new Exception($"Content: {response.Content.ReadAsStringAsync().Result}");
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

        public async Task Processar(Alerta alerta)
        {
            string mensagem = alerta.BarragemNome + " " + alerta.PlanoAcaoMensagem;

            new Mensageria.RabbitMQ().BasicPublish(mensagem, alerta.PessoaNome, alerta.PessoaEmail, alerta.PessoaCelular, alerta.PessoaSMS, alerta.PessoaWhatsapp);
        }

        protected override void OnStop()
        {

        }
    }
}
