using DroneApi.Controllers;
using DroneServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using DronesDTO;

namespace DroneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private IDispatchService _dispatchService;
        private readonly ILogger<DispatchController> _logger;
        public DispatchController(IDispatchService dispatchService, ILogger<DispatchController> logger)
        {
            _dispatchService = dispatchService;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Post([FromBody]DispatchDTO dispatchDTO)
        {
            try
            {
                string message;


                message = _dispatchService.Save(dispatchDTO);

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