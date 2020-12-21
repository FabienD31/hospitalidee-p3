using Hospitalidée_CRM_Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End.Actions
{
    public class RetrieveEtablissement
    {
        readonly HttpClient client = new HttpClient();

        public GovernmentApiJson RetrieveEtablissementFromGovernment(string siren)
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
