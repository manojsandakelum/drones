using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using DroneServices.Interfaces;
using DronesDTO;

namespace MedicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private IMedicationService _medicationService;
        private readonly ILogger<MedicationController> _logger;
        public MedicationController(IMedicationService medicationService, ILogger<MedicationController> logger)
        {
            _medicationService = medicationService;
            _logger = logger;
        }


        
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_medicationService.GetAllAvailables());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("getAllAvailables Error: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        
        [HttpPost]
        public IActionResult Post([FromBody] MedicationDTO medicationDTO)
        {
            try
            {
                string message;
               
                message = _medicationService.Save(medicationDTO);

                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Medication post Error: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}