using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientSearchService.Data;

namespace PatientSearchService.API
{
    [Route("api/patientsearch")]
    [ApiController]
    public class PatientSearchController : ControllerBase
    {
        private readonly ILogger<PatientSearchController> _logger;
        private readonly IPatientSearchRepository _elasticSearchService;
        private IMediator _mediatr;

        //protected readonly IPatientSearchRepository PatientSearchRepository;

        public PatientSearchController(ILogger<PatientSearchController> logger, IPatientSearchRepository elasticSearchService,
            IMediator mediatr)
        {
            _logger = logger;
            _elasticSearchService = elasticSearchService;
            _mediatr = mediatr;
        }

        [HttpGet("CreateClientIndex")]
        public async Task<ActionResult<bool>> CreateClientIndex()
        {
            await _elasticSearchService.CreateIndexIfNotExist();

            return Ok();
        }

        [HttpGet()]
        public async Task<ActionResult> SearchAsync([FromQuery] QueryStringConstructor q)
        {
            var command = new SearchPatientDetailsQuery() { QueryText = q.Query};
            _logger.LogInformation("-----Sending command: RegistrationCommand");
            var result = await _mediatr.Send(command);
            return new JsonResult(result);
        }
        //public string Get()
        //{
        //    PatientSearchRepository.AddAndSaveToES(new PatientDetailDto() { ClientID = "123", FirstName = "Supholo" });
        //    return "Hello";
        //}
    }

   
}
