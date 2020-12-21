using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End.Models.Request
{
    public class UniteLegaleCreationRequest
    {
        public string prenom_usuel { get; set; }
        public string nom { get; set; }
        public string siren { get; set; }
        public string denomination { get; set; }
        public string nomenclature_activite_principale { get; set; }
        public ICollection<EtablissementCreationRequest> etablissements { get; set; }
    }
}
