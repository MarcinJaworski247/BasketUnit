import Index from '../views/Index.vue';
import LeagueLeaders from '../views/LeaugeLeaders/Index.vue';
import TeamStatistics from '../views/TeamStatistics/Index.vue';

const routes = [
    {
        path: `/statistics`,
        name: `statistics.index`,
        component: Index
    },
    {
        path: `/statistics/leagueLeaders`,
        name: `statistics.leagueLeaders`,
        component: LeagueLeaders
    },
    {
        path: `/statistics/teamStatistics`,
        name: `statistics.teamStatistics`,
        component: TeamStatistics
    }
]

export default routes