using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospitalidée_CRM_Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospitalidée_CRM_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisteredController : ControllerBase
    {
        private readonly UniteLegaleContext _context;

        public RegisteredController(UniteLegaleContext injectedContext)
        {
            _context = injectedContext;
        }

        [HttpGet]
        public IEnumerable<UniteLegale> GetRegisteredInfo()
        {
            List<Etablissement> etablissements = new List<Etablissement>(_context.Etablissements.Select(e=>e));
            List<UniteLegale> uniteLegale = new List<UniteLegale>(_context.UniteLegale.Select(u => u));
            return uniteLegale;
        }
    }
}