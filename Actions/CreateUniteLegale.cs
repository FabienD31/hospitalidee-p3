using Hospitalidée_CRM_Back_End.Models;
using Hospitalidée_CRM_Back_End.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End.Actions
{
    public class CreateUniteLegale
    {
        private readonly UniteLegaleContext _context;
        public CreateUniteLegale(UniteLegaleContext context)
        {
            _context = context;
        }
        public void Create(UniteLegaleCreationRequest formEntry)
        {
            UniteLegale uniteLegale = ConvertRequest(formEntry);
            _context.uniteLegale.Add(uniteLegale);
            _context.SaveChanges();
        }
        private UniteLegale ConvertRequest(UniteLegaleCreationRequest formEntry)
        {
            List<Etablissement> etablissements = new List<Etablissement>();
            UniteLegale uniteLegale = new UniteLegale();
            uniteLegale.prenom_usuel = formEntry.prenom_usuel;
            uniteLegale.nom = formEntry.nom;
            uniteLegale.siren = formEntry.siren;
            uniteLegale.nomenclature_activite_principale = formEntry.nomenclature_activite_principale;
            uniteLegale.denomination = formEntry.denomination;
            foreach (EtablissementCreationRequest etablissementRequest in formEntry.etablissements)
            {
                Etablissement etablissement = new Etablissement();
                etablissement.activite_principale = etablissementRequest.activite_principale;
                etablissement.code_postal = etablissementRequest.code_postal;
                etablissement.denomination_usuelle = etablissementRequest.denomination_usuelle;
                etablissement.libelle_commune = etablissementRequest.libelle_commune;
                etablissement.libelle_voie = etablissementRequest.libelle_voie;
                etablissement.numero_voie = etablissementRequest.numero_voie;
                etablissement.siret = etablissementRequest.siret;
                etablissement.type_voie = etablissementRequest.type_voie;
                etablissements.Add(etablissement);
            }
            uniteLegale.etablissements = etablissements;
            return uniteLegale;
        }

    }
}
