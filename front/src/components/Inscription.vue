<template>
  <div id="search">
    <h2>S'inscrire</h2>
    <div class="container-sm text-justify">
      <modale :revele="revele" :toggleModale="toggleModale" :closeModale="closeModale"> </modale>
      <div class="form-group text-center">
        <label for="inscription"
          >Veuillez renseigner votre numéro de SIREN
        </label>
        <div style="margin-left: 30%; margin-right: 30%">
          <input
            type="text"
            name="siren"
            class="form-control mb-2 mr-sm-2 text-center"
            v-model="praticiens.siren"
            placeholder="9 chiffres"
          />
          <div @click="validateSiren">
            <button
              v-on:click="fetchSiret"
              class="btn btn-outline-success ml-1 my-2 my-sm-3 p-1"
            >
              Search
            </button>
          </div>
        </div>
        <div v-show="IsValidateSiren">
          <h4 class="text-center">Formulaire d'inscription</h4>
          <div v-if="praticiens.nom != null" class="d-flex justify-content-between">
            <div style="width: 30%; margin-left: 10%">
              <label for="nom" class="sr-only">Nom </label>
              <input
                type="text"
                name="nom"
                class="form-control mb-2 mr-sm-2"
                v-model="praticiens.nom"
                placeholder="Nom"
                readonly
              />
            </div>
            <div style="width: 30%; margin-right: 10%">
              <label for="prenom" class="sr-only">Prénom </label>
              <input
                type="text"
                name="prenom"
                class="form-control mb-2 mr-sm-2"
                v-model="praticiens.prenom_usuel"
                placeholder="Prénom"
                readonly
              />
            </div>
          </div>
          <div v-else style="width: 50%; margin-left: 25%" class="d-flex justify-content-center">
          <label for="Dénomination" class="sr-only">Dénomination </label>
          <input
            type="text"
            name="Dénomination"
            class="form-control mb-2 mr-sm-2 text-center"
            v-model="praticiens.denomination"
            placeholder="Dénomination"
            readonly
          />
        </div>
        </div>
        <br>
        <div v-show="IsValidateSiren" >
          <table class="table">
            <thead>
              <tr>
                <th scope="col">Utiliser ?</th>
                <th scope="col">SIRET</th>
                <th scope="col">Adresse</th>
              </tr>
            </thead>

            <tbody>
              <tr
                v-for="(etablissement, index) in praticiens.etablissements"
                :key="index"
              >
                <th>
                  <input
                    type="checkbox"
                    id="checkbox"
                    class="form-check-input"
                    :value="etablissement"
                    v-model="SavedSiret"
                  />
                </th>
                <label
                  ><td>{{ etablissement.siret }}</td></label
                >
                <td>
                  {{ etablissement.numero_voie }}
                  {{ etablissement.type_voie }}
                  {{ etablissement.libelle_voie }}
                  {{ etablissement.code_postal }}
                  {{ etablissement.libelle_commune }}
                </td>
              </tr>
            </tbody>
          </table>
          <div class="form-check mt-2">
            <input type="checkbox" class="form-check-input" id="checkbox" v-model="checked" @change="adeli" />
            <label class="form-check-label mb-2 mr-sm-2" for="checkbox">
              En cochant cette case, vous indiquez ne pas être référencé dans la
              base Adeli
            </label> 
          </div>
         
          <div class="display" v-if="displayBox">
            <div v-show="false">
            <p>contenu de la checkbox</p>
            <ul>
              <li
                for="checkbox"
                v-for="(info, index) in SavedSiret"
                v-bind:key="index"
              >
                {{ info.siret}}
              </li>
            </ul>
            </div>
            <button
              id="validate"
              class="btn btn-primary"
              @click="RegisterMethod()"
            >
              Valider
            </button>
            
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Modale from "./Modale.vue"
import axios from "axios";
export default {
  name: "Inscription",
  components: {
    'modale' : Modale
  },
  data() {
    return {
      praticiens: {
        prenom_usuel: null,
        nom: null,
        siren: null,
        denomination: null,
        nomenclature_activite_principale: null,
        message: null,
        etablissements: [
          {
            denomination_usuelle: null,
            siret: null,
            activite_principale: null,
            numero_voie: null,
            type_voie: null,
            libelle_voie: null,
            code_postal: null,
            libelle_commune: null,
          },
        ],
      },
      SavedSiret: [],
      IsValidateSiren: false,
      revele: false,
      checked: true,

    };
  },
  methods: {
    closeModale: function(){
        this.revele = false;
    },
    toggleModale: function(){
        this.revele = true;
    },
    fetchSiret: function () {
      axios
        .get(`${process.env.VUE_APP_BACK_END_URL}/siren/` + this.praticiens.siren)
        .then((response) => (this.praticiens = response.data))
        .catch(function (error) {
          console.log(error.response),
          alert("Veuillez entrer un numéro de SIREN valide")
          });
    },
    validateSiren() {
      this.IsValidateSiren = true;
    },
    RegisterMethod() {
      const sirets = this.SavedSiret.map(etablissement => {
        return etablissement.siret;
      });
      axios
      .post(`${process.env.VUE_APP_BACK_END_URL}/save/UniteLegale`, sirets)
      .then((response) => (this.praticiens = response.data))
      .then(this.toggleModale)
      .catch(function (error) {
          console.log(error.response),
          alert("Ce praticien est déjà référencé, veuillez vous authentifier.");
          });
    },
    adeli() {
      if(!this.checked) {
        alert("vous ne devez pas être référencé dans la base ADELI")
      }
    }
  },
  computed: {
    displayBox() {
      return this.SavedSiret.length;
    },
  },
};
</script>

<style>
th {
  background-color: #16428a;
  color: white;
}
</style>
