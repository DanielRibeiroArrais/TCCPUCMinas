using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.PUC.SCA.API.Models;
using TCC.PUC.SCA.Business;
using TCC.PUC.SCA.Business.Intefaces;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Common;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SensorDadosController : MainController
    {
        private readonly AppSettings _appSettings;

        public SensorDadosController(IOptions<AppSettings> appSettings, INotificador notificador) : base(appSettings, notificador)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Authorize(Roles = "APIAcesso")]
        [ProducesResponseType(typeof(List<Alerta>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SensorDados>> Post([FromBody] InformacaoSensor informacaoSensor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Sensor sensor = new Business.SensorBLL(_appSettings).ObterLista().FirstOrDefault(x => x.Codigo.Equals(informacaoSensor.Codigo, StringComparison.OrdinalIgnoreCase));

                    if (sensor != null)
                    {
                        SensorDadosIncidente sensorDadosIncidente = new SensorDadosIncidente();

                        SensorDados sensorDados = new SensorDados();
                        sensorDados.SensorId = sensor.Id;
                        sensorDados.Intensidade = informacaoSensor.Intensidade;
                        sensorDados.DataInclusao = DateTime.Now;

                        sensorDadosIncidente.SensorDados = new SensorDados();
                        sensorDadosIncidente.SensorDados = sensorDados;

                        if ((sensor.Tipo.Equals("tremor", StringComparison.OrdinalIgnoreCase) && informacaoSensor.Intensidade >= 10)
                            || (sensor.Tipo.Equals("ruido", StringComparison.OrdinalIgnoreCase) && informacaoSensor.Intensidade >= 70))
                        {
                            List<PlanoAcao> lPlanoAcao = new Business.PlanoAcaoBLL(_appSettings).ObterLista().Where(x => x.Tipo.Equals(sensor.Tipo, StringComparison.OrdinalIgnoreCase)).ToList();

                            if (lPlanoAcao.Count == 0)
                                return Problem("Plano de Ação não encontrado!");

                            Incidente incidente = new Incidente();
                            incidente.SensorDadosId = 0;
                            incidente.PlanoAcaoId = lPlanoAcao.FirstOrDefault(x => informacaoSensor.Intensidade >= x.De && informacaoSensor.Intensidade <= x.Ate).Id;
                            incidente.DataInclusao = DateTime.Now;

                            sensorDadosIncidente.Incidente = new Incidente();
                            sensorDadosIncidente.Incidente = incidente;
                        }

                        new Business.EspecificoBLL(_appSettings).InserirSensorDadosIncidente(sensorDadosIncidente);

                        return Ok("Sucesso!");
                    }

                    return Problem("Sensor não identificado!");
                }
                else
                {
                    return CustomResponse(ModelState);
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
                return CustomResponse();
            }
        }
    }
}