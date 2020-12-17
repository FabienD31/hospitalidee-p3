using System;
using System.Collections.Generic;

namespace Hospitalidée_CRM_Back_End.Models
{
    public class UniteLegale
    {
        public Guid uniteLegaleId { get; set; }
        public string prenom_usuel { get; set; }
        public string nom { get; set; }
        public string siren { get; set; }
        public string denomination { get; set; }
        public string nomenclature_activité_principale { get; set; }
        public IEnumerable<Etablissement> etablissement { get; set; }
    }
}