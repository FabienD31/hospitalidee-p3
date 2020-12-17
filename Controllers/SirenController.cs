using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Hospitalidée_CRM_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hospitalidée_CRM_Back_End.Controllers
{
    [ApiController]
    [Route("Siren/{siren?}")]
    public class SirenController : ControllerBase
    {
        [HttpGet]
        public UniteLegaleJson GetEtablissement(string? siren)
        {
            if(siren == null)
            {
                return null;
            }
            
            GovernmentApiJson jsonGovernment = RetrieveEtablissementFromGovernment(siren);
            if(jsonGovernment == null)
            {
                return null;
            }
            UniteLegaleJson uniteLegaleJson = ConvertIntoResponse(jsonGovernment);
            return uniteLegaleJson;

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
                string apeCode = "86";
                jsonGovernment.unite_legale.etablissements.ToList();
                
                if(etablissement.activite_principale.Contains(apeCode))
                {
                    listEtablissementAPE.Add(etablissement);
                    uniteLegaleJson.etablissements = listEtablissementAPE;
                }
            }

            

            return uniteLegaleJson;
        }

        readonly HttpClient client = new HttpClient();

        private GovernmentApiJson RetrieveEtablissementFromGovernment(string siren)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = client.GetAsync("https://entreprise.data.gouv.fr/api/sirene/v3/unites_legales/" + siren).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                GovernmentApiJson jsonGovernmentApi = JsonSerializer.Deserialize<GovernmentApiJson>(responseBody);
                
                return jsonGovernmentApi;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }

        }
    }
}
