using System;
using System.Collections.Generic;

namespace Hospitalidée_CRM_Back_End.Models
{
    public class UniteLegaleJson
    {
        public string prenom_usuel { get; set; }
        public string nom { get; set; }
        public string siren { get; set; }
        public string denomination { get; set; }
        public string nomenclature_activite_principale { get; set; }
        public string message { get; set; }
        public IEnumerable<EtablissementJson> etablissements { get; set; }
    }
}