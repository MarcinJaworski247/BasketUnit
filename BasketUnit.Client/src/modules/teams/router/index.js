import PlayerDetails from "../views/PlayerDetails.vue";
import Lineup from "../views/Lineup.vue";
import FirstLineup from "../views/FirstLineup.vue";

const routes = [
  {
    path: `/team/player/:playerId`,
    name: `team.player.details`,
    component: PlayerDetails,
  },
  {
    path: `/team/lineup`,
    name: `team.lineup.index`,
    component: Lineup,
  },
  {
    path: `/team/firstLineup`,
    name: `team.firstLineup.index`,
    component: FirstLineup,
  },
];

export default routes;
