using Hospitalidée_CRM_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteController : Controller
    {
        private readonly UniteLegaleContext _context;

        public DeleteController(UniteLegaleContext injectedContext)
        {
            _context = injectedContext;
        }

        [HttpDelete]
        [Route("UniteLegale/{siren}")]
        public IActionResult DeleteUniteLegale(String siren)
        {
            UniteLegale existingUniteLegale = _context.UniteLegale.Include(u => u.etablissements)
                                                                  .FirstOrDefault(u => u.siren == siren);

            if (existingUniteLegale == null)
            {
                return BadRequest();
            }

            _context.RemoveRange(existingUniteLegale.etablissements);
            _context.Remove(existingUniteLegale);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        [Route("Etablissement/{siret}")]
        public IActionResult DeleteEtablissement(String siret)
        {
            string siren = siret.Substring(0, 9);
            Etablissement existingEtablissement = _context.Etablissements.FirstOrDefault(e => e.siret == siret);
            UniteLegale existingUniteLegale = _context.UniteLegale.Include(u => u.etablissements)
                                                                  .FirstOrDefault(u => u.siren == siren);
            if (existingEtablissement == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(existingEtablissement);
                _context.SaveChanges();
                if (!existingUniteLegale.etablissements.Any())
                {
                    _context.Remove(existingUniteLegale);
                    _context.SaveChanges();
                }
                return Ok();
            }


        }
    }
}
