// main view
import Index from "../views/Index.vue";

// main categories
import HumanResources from "../views/HumanResources/Index.vue";
import Clubs from "../views/Clubs/Index.vue";

// human resources
import Coaches from "../views/HumanResources/Coaches/Index.vue";
import Players from "../views/HumanResources/Players/Index.vue";
import Referees from "../views/HumanResources/Referees/Index.vue";

// clubs
import Arenas from "../views/Clubs/Arenas/Index.vue";
import Teams from "../views/Clubs/Teams/Index.vue";

const routes = [
  {
    path: `/administration`,
    name: `administration.index`,
    component: Index,
  },
  {
    path: "/administration/humanResources",
    name: "administration.humanResources.index",
    component: HumanResources,
  },
  {
    path: "/administration/clubs",
    name: "administration.clubs.index",
    component: Clubs,
  },
  {
    path: "/administration/humanResources/coaches",
    name: "administration.humanResources.coaches",
    component: Coaches,
  },
  {
    path: "/administration/humanResources/players",
    name: "administration.humanResources.players",
    component: Players,
  },
  {
    path: "/administration/humanResoources/referees",
    name: "administration.humanResources.referees",
    component: Referees,
  },
  {
    path: "/administration/clubs/teams",
    name: "administration.clubs.teams",
    component: Teams,
  },
  {
    path: "/administration/clubs/arenas",
    name: "administration.clubs.arenas",
    component: Arenas,
  },
];

export default routes;
