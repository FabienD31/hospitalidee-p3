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
    public class SaveController : ControllerBase
    {
        private readonly UniteLegaleContext _context;

        public SaveController(UniteLegaleContext injectedContext)
        {
            _context = injectedContext;
        }

        [HttpPost]
        [Route("UniteLegale")]
        public IActionResult SaveUniteLegale([FromBody] UniteLegale uniteLegaleForm)
        {
            UniteLegale existingUniteLegale = _context.UniteLegale.FirstOrDefault(u => u.siren == uniteLegaleForm.siren);
            if (existingUniteLegale != null)
            {
                _context.Remove(existingUniteLegale);
                _context.Add(uniteLegaleForm);
            }
            else
            {
                _context.Add(uniteLegaleForm);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{siren}")]
        public IActionResult DeleteUniteLegale(String siren)
        {
            UniteLegale existingUniteLegale = _context.UniteLegale.Include(u => u.etablissements)
                                                                  .FirstOrDefault(u => u.siren == siren);
            
            if (existingUniteLegale == null)
            {
                return BadRequest(); 
            }

            _context.Remove(existingUniteLegale);
            _context.SaveChanges();
            return Ok();

        }

    }
}
