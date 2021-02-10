<template>
    <div class="block-modale d-flex justify-content-center" v-if="revele">
        <div class="overlay" @click="closeModale" ></div>
        <div class="modale card">
            <button class="btn-modale" @click="closeModale, reloadPage()">Ok</button>
            <h4>Enregistré</h4>
            <p>Ce praticien a bien été enregistré !</p>
        </div>
    </div>

</template>

<script>
export default {
    name: 'Modale',
    props: ['revele','toggleModale','closeModale'],
    methods:{
        reloadPage(){
            window.location.reload()
        }
    }
}
</script>

<style scoped>

.bloc-modale{
    position: fixed;
    top : 0;
    bottom: 0;
    left: 0;
    right: 0;
    display: flex;
    justify-content: center;
    align-items: center;
}

.overlay{
    background: rgba(0,0,0,0.5);
    position: fixed;
    top : 0;
    bottom: 0;
    left: 0;
    right: 0;
}

.modale{
    background: #f1f1f1;
    color: #333;
    padding: 50px;
    position: fixed;
}

.btn-modale{
    background: #333;
    position: absolute;
    bottom: 10px;
    right: 10px;
    color:#f1f1f1;
}
</style>