import Vue from 'vue'
import Vuex from 'vuex'
import administrationStore from './modules/administration/store/index'
import dashboardStore from './modules/dashboard/store/index'
import gamesStore from './modules/games/store/index'
import playersStore from './modules/players/store/index'
import schedulesStore from './modules/schedules/store/index'
import statisticsStore from './modules/statistics/store/index'
import teamsStore from './modules/teams/store/index'
import workoutsStore from './modules/workouts/store/index'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        administrationStore,
        dashboardStore,
        gamesStore,
        playersStore,
        schedulesStore,
        statisticsStore,
        teamsStore,
        workoutsStore
    }
});