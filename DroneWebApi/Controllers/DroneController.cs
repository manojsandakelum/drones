using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using DroneServices.Interfaces;

namespace DroneApi.Controllers
{
    [Route("~/api/[controller]/[action]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private IDroneService _droneService;
        private readonly ILogger<DroneController> _logger;
        public DroneController(IDroneService droneService, ILogger<DroneController> logger)
        {
            _droneService = droneService;
            _logger = logger;
        }


       
        [HttpGet]
        public IActionResult GetAllAvailablesForLoading()
        {
            try
            {
                return Ok(_droneService.GetAllAvailables());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("getAllAvailables Error: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

      
        [HttpGet]
        [Route("~/api/Drone/getBatteryLevelByDroneId/{id}")]
        public IActionResult GetBatteryLevelByDroneId(int id)
        {
            try
            {
                return Ok(_droneService.GetBatteryLevelByDroneId(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("GetBatteryLevel Error: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

       
        [HttpPost]
        public IActionResult Post([FromBody] dynamic value)
        {
            try
            {
                string message;

                var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                options.Converters.Add(new JsonStringEnumConverter());
                DronesDTO.DroneDTO droneDTO = JsonSerializer.Deserialize<DronesDTO.DroneDTO>(value, options);

                message = _droneService.Save(droneDTO);

                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Drone post Error: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
