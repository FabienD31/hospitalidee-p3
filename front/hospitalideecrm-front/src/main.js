import Vue from 'vue'
import VueRouter from 'vue-router'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'

Vue.use(VueRouter)
Vue.use(VueAxios, axios)
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.config.productionTip = false

const router = new VueRouter({
    mode: 'history',
    routes:[
        {
            path: '/',
            component: ()=> import('./components/Inscription.vue')
        },
        {
            path: '/list',
            component: ()=> import('./components/List.vue')
        }
    ]
})

new Vue({
    el : '#app',
    router,
    render: h => h(App)
})