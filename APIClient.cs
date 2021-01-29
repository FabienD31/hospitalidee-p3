using Hospitalidée_CRM_Back_End.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End
{
    public class APIClient
    {
        private readonly String _baseUrl;
        private readonly HttpClient _httpClient;

        public APIClient(String baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public UniteLegale GetUniteLegale(String siren)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"{_baseUrl}/unites_legales/{siren}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            Task<String> responseBody = response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody.Result);
            JToken token = json["unite_legale"];
            UniteLegale uniteLegale = System.Text.Json.JsonSerializer.Deserialize<UniteLegale>(token.ToString());
            return uniteLegale;

        }


    }
}
