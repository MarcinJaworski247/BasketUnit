import Vue from "vue";
import Router from "vue-router";

// Modules routes
import administrationRouter from './modules/administration/router/index'
// import dashboardRouter from './modules/dashboard/router/index'
// import gamesRouter from './modules/games/router/index'
// import playersRouter from './modules/players/router/index'
import schedulesRouter from './modules/schedules/router/index'
import statisticsRouter from './modules/statistics/router/index'
import teamRouter from './modules/teams/router/index'
import workoutsRouter from './modules/workouts/router/index'

Vue.use(Router);

var allRoutes = [];
allRoutes = allRoutes
                .concat(
                    administrationRouter,
                    schedulesRouter,
                    statisticsRouter,
                    teamRouter,
                    workoutsRouter
                )

const routes = allRoutes;

export default new Router({
    mode: "history",
    routes: routes
});