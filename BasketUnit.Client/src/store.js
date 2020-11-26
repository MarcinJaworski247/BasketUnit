import Vue from 'vue'
import Vuex from 'vuex'
import axios from "./http-common";
// Administration/Clubs/Teams
import AdministrationTeamStore from './modules/administration/store/Clubs/Teams/index.js'
import AdministrationEditTeamStore from './modules/administration/store/Clubs/Teams/edit.js'

// Administration/Clubs/Arenas
import AdministrationArenaStore from './modules/administration/store/Clubs/Arenas/index.js'
import AdministrationEditArenaStore from './modules/administration/store/Clubs/Arenas/edit.js'

// Administration/HumanResources/Coaches
import AdministrationCoachStore from './modules/administration/store/HumanResources/Coaches/index.js'
import AdministrationEditCoachStore from './modules/administration/store/HumanResources/Coaches/edit.js'

// Administration/HumanResources/Players
import AdministrationPlayerStore from './modules/administration/store/HumanResources/Players/index.js'
import AdministrationEditPlayerStore from './modules/administration/store/HumanResources/Players/edit.js'
import AdministrationDetailsPlayerStore from './modules/administration/store/HumanResources/Players/details.js'

// Administration/HumanResources/Referees
import AdministrationRefereeStore from './modules/administration/store/HumanResources/Referees/index.js'
import AdministrationEditRefereeStore from './modules/administration/store/HumanResources/Referees/edit.js'

// Schedules
import SchedulesStore from './modules/schedules/store/index.js'

// Statistics
import TeamStatisticsStore from './modules/statistics/store/TeamStatistics/index.js'
import LeagueLeadersStore from './modules/statistics/store/LeagueLeaders/index.js'

// Team
import TeamStore from './modules/teams/store/index.js'
import TeamPlayerDetailsStore from './modules/teams/store/details.js'
import FirstLineupStore from './modules/teams/store/firstLineup.js'

// Workouts
import WorkoutsExcercisesStore from './modules/workouts/store/Excercises/index.js'
import WorkoutsExcercisesEditStore from './modules/workouts/store/Excercises/edit.js'
import WorkoutsTypesStore from './modules/workouts/store/WorkoutTypes/index.js'
import WorkoutsTypesEditStore from './modules/workouts/store/WorkoutTypes/edit.js'


import { getField, updateField } from 'vuex-map-fields';


Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        AdministrationTeamStore, 
        AdministrationEditTeamStore, 
        AdministrationArenaStore, 
        AdministrationEditArenaStore, 
        AdministrationCoachStore, 
        AdministrationEditCoachStore,
        AdministrationPlayerStore, 
        AdministrationEditPlayerStore, 
        AdministrationDetailsPlayerStore, 
        AdministrationRefereeStore, 
        AdministrationEditRefereeStore, 
        SchedulesStore,
        TeamStatisticsStore, 
        LeagueLeadersStore, 
        TeamStore, 
        WorkoutsExcercisesStore,
        WorkoutsExcercisesEditStore, 
        WorkoutsTypesStore, 
        WorkoutsTypesEditStore,
        TeamPlayerDetailsStore,
        FirstLineupStore
    },
    state: {
        leagueaLeaders: [],
        closestGames: []
    },
    getters: {
        getField,
        getLeaugueLeaders(state) {
            return state.leagueLeaders;
        },
        getClosestGames(state) {
            return state.closestGames;
        }
    },
    mutations: {
        updateField,
        setLeagueaLeaders: (state, payload) => {
            state.leagueLeaders = payload;
        },
        setClosestGames: (state, payload) => {
            state.closestGames = payload;
        }
    },
    actions: {
        setLeagueaLeaders: ({ commit }) => {
            axios.get("/statistics/LeagueLeaders/getLeadersToWidget")
                .then(response => {
                    commit("setLeagueaLeaders", response.data);
                });
        },
        setClosestGames: ({ commit }) => {
            axios.get("/schedules/getClosestGamesToWidget")
                .then(response => {
                    commit("setClosestGames", response.data);
                });
        }
    }
});
