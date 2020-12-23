import Index from '../views/Index.vue';
import PlayerDetails from '../views/Components/PlayerDetailsTabPanel.vue';
import Lineup from '../views/Components/LineupTab.vue';
import FirstLineup from '../views/Components/FirstLineupTab.vue';

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
    },
    {
        path: `/team/lineup`,
        name: `team.lineup.index`,
        component: Lineup
    },
    {
        path: `/team/firstLineup`,
        name: `team.firstLineup.index`,
        component: FirstLineup
    }
]

export default routes;

