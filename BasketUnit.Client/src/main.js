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

import VueLazyload from 'vue-lazyload'

import moment from 'moment';


Vue.use(BootstrapVue);

Vue.use(VueLazyload, {
  lazyComponent: true
})

Vue.filter('formatDate', function(value) {
    if (value) {
        return moment(String(value)).format('DD-MM-YYYY')
    }
});

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')

