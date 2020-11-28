import Index from '../views/Index.vue';
import GameDetails from '../views/Details.vue';

const routes = [
    {
        path: `/games`,
        name: `games.index`,
        component: Index
    },
    {
        path: `/games/details/:gameId`,
        name: `games.details`,
        component: GameDetails
    }
]

export default routes;