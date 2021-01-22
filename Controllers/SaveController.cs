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
        private readonly APIClient _apiClient;

        public SaveController(UniteLegaleContext injectedContext, APIClient apiClient)
        {
            _context = injectedContext;
            _apiClient = apiClient;
        }

        [HttpPost]
        [Route("UniteLegale")]
        public IActionResult SaveUniteLegale([FromBody] List<String> sirets)
        {
            string siren = sirets.First().Substring(0,9);
            UniteLegale uniteLegale = _apiClient.GetUniteLegale(siren);
            List<Etablissement> etablissementBySiret = new List<Etablissement>();
            foreach(string siret in sirets)
            {
                Etablissement selectedEtablissement = uniteLegale.etablissements.FirstOrDefault(etablissement => etablissement.siret == siret);
                Etablissement existingEtablissement = _context.Etablissements.FirstOrDefault(e => e.siret == selectedEtablissement.siret);
                
                if (selectedEtablissement != null)
                {
                    if (existingEtablissement != null)
                    {
                        return BadRequest(StatusCode(404));
                    }
                    else
                    {
                        etablissementBySiret.Add(selectedEtablissement);
                    }
                }

            }
            uniteLegale.etablissements = etablissementBySiret;
            UniteLegale existingUniteLegale = _context.UniteLegale.Include(u=>u.etablissements).FirstOrDefault(u => u.siren == uniteLegale.siren);
            
            if (existingUniteLegale != null)
            {
                return BadRequest(StatusCode(404));
            }
            else
            {
                _context.Add(uniteLegale);
            }
            
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("siret")]
        public IActionResult UpdateUniteLegale([FromBody] List<String> sirets)
        {
            string siren = sirets.First().Substring(0, 9);
            UniteLegale uniteLegale = _apiClient.GetUniteLegale(siren);
            List<Etablissement> etablissementBySiret = new List<Etablissement>();
            foreach (string siret in sirets)
            {
                Etablissement selectedEtablissement = uniteLegale.etablissements.FirstOrDefault(etablissement => etablissement.siret == siret);
                Etablissement existingEtablissement = _context.Etablissements.FirstOrDefault(e => e.siret == selectedEtablissement.siret);

                if (selectedEtablissement != null)
                {
                    if (existingEtablissement != null)
                    {
                        etablissementBySiret.Remove(existingEtablissement);
                        etablissementBySiret.Add(selectedEtablissement);
                    }
                    else
                    {
                        return BadRequest(StatusCode(404));
                    }
                }

            }
            uniteLegale.etablissements = etablissementBySiret;
            UniteLegale existingUniteLegale = _context.UniteLegale.Include(u => u.etablissements).FirstOrDefault(u => u.siren == uniteLegale.siren);

            if (existingUniteLegale != null)
            {
                _context.Remove(existingUniteLegale);
                _context.Add(uniteLegale);
            }
            else
            {
                return BadRequest(StatusCode(404));
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
