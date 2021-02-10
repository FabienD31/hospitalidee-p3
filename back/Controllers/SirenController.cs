using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Hospitalidée_CRM_Back_End.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hospitalidée_CRM_Back_End.Controllers
{
    [ApiController]
    [Route("Siren")]
    public class SirenController : ControllerBase
    {
        private readonly APIClient _client;
        public SirenController(APIClient injectedClient)
        {
            _client = injectedClient;
        }
        
        [Route("{siren}")]
        [HttpGet]

        public IActionResult GetUniteLegale(string siren)
        {
            UniteLegale uniteLegale = _client.GetUniteLegale(siren);

            if (uniteLegale != null)
            {
                return Ok(uniteLegale);
            }
            else
            {
                return BadRequest(StatusCode(404));
            }

        } 

    }
}
