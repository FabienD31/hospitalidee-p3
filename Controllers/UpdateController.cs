using Hospitalidée_CRM_Back_End.Models;
using Microsoft.AspNetCore.Http;
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
        public class UpdateController : ControllerBase
        {
            private readonly UniteLegaleContext _context;
            private readonly APIClient _apiClient;

            public UpdateController(UniteLegaleContext injectedContext, APIClient apiClient)
            {
                _context = injectedContext;
                _apiClient = apiClient;
            }

            [HttpPut]
            [Route("UniteLegale")]
            public IActionResult UpdateUniteLegale([FromBody] List<String> sirets)
            {
                string siren = sirets.First().Substring(0, 9);
                UniteLegale uniteLegale = _apiClient.GetUniteLegale(siren);
                List<Etablissement> etablissementBySiret = new List<Etablissement>();
                foreach (string siret in sirets)
                {
                    Etablissement selectedEtablissement = uniteLegale.etablissements.FirstOrDefault(etablissement => etablissement.siret == siret);
                    if (selectedEtablissement != null)
                    {
                        if (selectedEtablissement.siret.Any())
                        {
                            etablissementBySiret.Remove(selectedEtablissement);
                            etablissementBySiret.Add(selectedEtablissement);
                        }

                    return BadRequest("Ce siret n'est pas enregistré");
                    
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
                    return BadRequest("Ce siren n'est pas enregistré");
                }
                _context.SaveChanges();
                return Ok();
            }
        }
    }
