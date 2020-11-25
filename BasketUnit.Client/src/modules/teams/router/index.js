import Index from '../views/Index.vue';
import PlayerDetails from '../views/Components/PlayerDetails.vue';

const routes = [
    {
        path: `/team`,
        name: `team.index`,
        component: Index
    },
    {
        path: `/team/player/:playerId`,
        name: `team.player.details`,
        component: PlayerDetails
    }
]

export default routes;

