<template>
  <div>
    <div>
      <table>
        <thead>
          <tr>
            <th></th>

            <th>SIREN</th>

            <th>Dénomination</th>

            <th>Nom</th>

            <th>Prénom</th>

            <th>SIRET</th>

            <th>Adresse</th>
          </tr>
        </thead>

        <tbody v-for="(praticien, pIndex) in praticiens" v-bind:key="pIndex">
          <tr
            v-for="(etablissement, index) in praticien.etablissements"
            v-bind:key="index"
          >
            <th>
            <button type="button" class="btn" id="validate" v-on:click="deleteSiret(etablissement.siret)">
                <img src="../assets/trash-can_38501.png"/></button>
            </th>

            <td>
              {{ praticien.siren }}
            </td>

            <td>
              {{ praticien.denomination }}
            </td>

            <td>
              {{ praticien.nom }}
            </td>

            <td>
              {{ praticien.prenom_usuel }}
            </td>

            <td>
              {{ etablissement.siret }}
            </td>

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
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "List",
  data() {
    return {
      praticiens: [
        {
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
      ],
    };
  },
  mounted() {
    this.updateTable()
  },
  methods: {
    deleteSiret: function(siret){
      axios
      .delete(`${process.env.VUE_APP_BACK_END_URL}/Delete/Etablissement/${siret}`)
      .then(() => this.updateTable())
    },
    updateTable: function() {
      axios
      .get(`${process.env.VUE_APP_BACK_END_URL}/registered`)
      .then((response) => (this.praticiens = response.data));
    }
  }
};
</script>
<style scoped>
/*html,
body {
  height: 100%;
}*/

/*body {
  margin: 0;
  background: linear-gradient(45deg, #00bf8f, #001510);
  font-family: sans-serif;
}*/

table {
margin: auto;
margin-top: 3rem;
}

th,
td {
  padding: 10px;
  position: relative;
  text-align: center;
  color: rgba(0, 0, 0, 0.7);
  border: solid 0.1em #0b3d91;

}

th {
  background-color:#0b3d91;
  color: white;
}

td {
  background-color: rgba(0, 255, 255, 0.1);
}

tbody > tr:hover th,
tbody > tr:hover td {
  background: rgba(255, 255, 255, 0.2);
  color: #0b3d91;
}
</style>