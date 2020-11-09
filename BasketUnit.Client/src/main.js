import Vue from 'vue'
import App from './App.vue'
import store from './store'
import router from './router';

//DevExtreme
import 'devextreme/dist/css/dx.common.css';
import 'devextreme/dist/css/dx.light.css';


//Bootstrap
import { BootstrapVue } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

//FontAwesome
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'

Vue.use(BootstrapVue);

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')

