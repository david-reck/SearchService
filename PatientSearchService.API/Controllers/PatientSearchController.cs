using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PatientSearchService.API
{
    [Route("api/patientsearch")]
    [ApiController]
    public class PatientSearchController : ControllerBase
    {
        private readonly ILogger<PatientSearchController> _logger;
        private readonly IPatientSearchRepository _elasticSearchService;

        //protected readonly IPatientSearchRepository PatientSearchRepository;

        public PatientSearchController(ILogger<PatientSearchController> logger, IPatientSearchRepository elasticSearchService)
        {
            _logger = logger;
            _elasticSearchService = elasticSearchService;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> GetCities(string query)
        {
           await _elasticSearchService.CreateIndexIfNotExist();

            return Ok();
        }
        //public string Get()
        //{
        //    PatientSearchRepository.AddAndSaveToES(new PatientDetailDto() { ClientID = "123", FirstName = "Supholo" });
        //    return "Hello";
        //}
    }

   
}
