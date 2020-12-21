using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Hospitalidée_CRM_Back_End.Actions;
using Hospitalidée_CRM_Back_End.Models;
using Hospitalidée_CRM_Back_End.Models.Request;
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
        private readonly CreateUniteLegale _createUniteLegale;
        private readonly RetrieveEtablissement _retrieveEtablissement;
        public SirenController(UniteLegaleContext context, CreateUniteLegale createUniteLegale, RetrieveEtablissement retrieveEtablissement)
        {
            _createUniteLegale = createUniteLegale;
            _context = context;
            _retrieveEtablissement = retrieveEtablissement;
        }
        
        [Route("{siren?}")]
        [HttpGet]
        public UniteLegaleJson GetEtablissement(string? siren)
        {
            if(siren == null)
            {
                return null;
            }
            
            GovernmentApiJson jsonGovernment =_retrieveEtablissement.RetrieveEtablissementFromGovernment(siren);
            if(jsonGovernment == null)
            {
                return null;
            }
            UniteLegaleJson uniteLegaleJson = ConvertIntoResponse(jsonGovernment);
            return uniteLegaleJson;

        }
        [HttpPost]
        public IActionResult PostNewForm([FromBody]UniteLegaleCreationRequest formEntry)
        {
            _createUniteLegale.Create(formEntry);
            return Ok();
        }

        private UniteLegaleJson ConvertIntoResponse(GovernmentApiJson jsonGovernment)
        {
            UniteLegaleJson uniteLegaleJson = new UniteLegaleJson();
            List<EtablissementJson> listEtablissementAPE = new List<EtablissementJson>();

            uniteLegaleJson.denomination = jsonGovernment.unite_legale.denomination;
            uniteLegaleJson.prenom_usuel = jsonGovernment.unite_legale.prenom_usuel;
            uniteLegaleJson.nom = jsonGovernment.unite_legale.nom;
            uniteLegaleJson.nomenclature_activite_principale = jsonGovernment.unite_legale.nomenclature_activite_principale;
            uniteLegaleJson.siren = jsonGovernment.unite_legale.siren;
            
            foreach(EtablissementJson etablissement in jsonGovernment.unite_legale.etablissements)
            {
                string apeCode = "85";
                jsonGovernment.unite_legale.etablissements.ToList();
                
                if(etablissement.activite_principale.Contains(apeCode))
                {
                    listEtablissementAPE.Add(etablissement);
                    uniteLegaleJson.etablissements = listEtablissementAPE;
                }
            }
            return uniteLegaleJson;
        }


    }
}
