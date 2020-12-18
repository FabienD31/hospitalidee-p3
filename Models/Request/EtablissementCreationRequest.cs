namespace Hospitalidée_CRM_Back_End.Models.Request
{
    public class EtablissementCreationRequest
    {
        public string denomination_usuelle { get; set; }
        public string siret { get; set; }
        public string activite_principale { get; set; }
        public string numero_voie { get; set; }
        public string type_voie { get; set; }
        public string libelle_voie { get; set; }
        public string code_postal { get; set; }
        public string libelle_commune { get; set; }
    }
}