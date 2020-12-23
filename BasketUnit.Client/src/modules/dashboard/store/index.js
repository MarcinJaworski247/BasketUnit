import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";
const namespaced = true;

const state = {
    lastGames: [],
    futureGames: [],
    injuredPlayers: [],
    teamStats: [],
    futureWorkouts: []
}

const getters = {
    getField,
    getLastGames: (state) => {
        return state.lastGames;
    },
    getFutureGames: (state) => {
        return state.futureGames;
    },
    getInjuredPlayers: (state) => {
        return state.injuredPlayers;
    },
    // getTeamStats: (state) => {
    //     return state.teamStats;
    // }
    getFutureWorkouts: (state) => {
        return state.futureWorkouts;
    }
}

const mutations = {
    updateField,
    setLastGames: (state, payload) => {
        state.lastGames = payload;
    },
    setFutureGames: (state, payload) => {
        state.futureGames = payload;
    },
    setInjuredPlayers: (state, payload) => {
        state.injuredPlayers = payload;
    },
    // setTeamStats: (state, payload) => {
    //     state.teamStats = payload;
    // },
    setFutureWorkouts: (state, payload) => {
        state.futureWorkouts = payload;
    },
}

const actions = {
    setLastGames: ({ commit }) => {
        service.getLastGames()
            .then(response => {
                commit("setLastGames", response.data);
            });
    },
    setFutureGames: ({ commit }) => {
        service.getFutureGames()
            .then(response => {
                commit("setFutureGames", response.data);
            });
    },
    setInjuredPlayers: ({ commit }) => {
        service.getInjuredPlayers()
            .then(response => {
                commit("setInjuredPlayers", response.data);
            });
    },
    // setTeamStats: ({ commit }) => {
    //     service.getTeamStats()
    //         .then(response =>{
    //             commit("setTeamStats", response.data);
    //         });
    // },
    setFutureWorkouts: ({ commit }) => {
        service.getFutureWorkouts()
            .then(response => {
                commit("setFutureWorkouts", response.data);
            });
    },
}

export default { state, getters, mutations, actions, namespaced };