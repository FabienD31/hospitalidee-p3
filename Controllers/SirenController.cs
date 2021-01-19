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
        private readonly UniteLegaleContext _context;
        private readonly APIClient _client;
        public SirenController(UniteLegaleContext injectedContext, 
                               APIClient injectedClient)
        {
            _context = injectedContext;
            _client = injectedClient;
        }
    }
}
