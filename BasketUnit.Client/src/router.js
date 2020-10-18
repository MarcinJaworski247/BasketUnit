import Vue from "vue";
import Router from "vue-router";
import administrationRouter from './modules/administration/router/index'

Vue.use(Router);

export default new Router({
    mode: "history",
    routes: [
        administrationRouter
    ]
});