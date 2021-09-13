import Vue from "vue";
import Router from "vue-router";

// Modules routes
import dashboardRouter from "./modules/dashboard/router/index";
import administrationRouter from "./modules/administration/router/index";
import schedulesRouter from "./modules/schedules/router/index";
import statisticsRouter from "./modules/statistics/router/index";
import teamRouter from "./modules/teams/router/index";
import workoutsRouter from "./modules/workouts/router/index";
import gamesRouter from "./modules/games/router/index";
import protocolsRouter from "./modules/protocols/router/index";

Vue.use(Router);

var allRoutes = [
  {
    path: "/",
    redirect: "/dashboard",
  },
];
allRoutes = allRoutes.concat(
  dashboardRouter,
  administrationRouter,
  schedulesRouter,
  statisticsRouter,
  teamRouter,
  workoutsRouter,
  gamesRouter,
  protocolsRouter
);

const routes = allRoutes;

export default new Router({
  mode: "history",
  routes: routes,
});
