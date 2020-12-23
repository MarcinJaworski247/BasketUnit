import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";

const namespaced = true;

const state = {
    teamForm: {
        name: '',
        badge: ''
    },
    teamAverages: [],
    teamScoreAndLosePoints: []
}

const getters = {
    getField,
    getTeamAverages: (state) => {
        return state.teamAverages;
    },
    getTeamScoreAndLosePoints: (state) => {
        return state.teamScoreAndLosePoints;
    }
}

const mutations = {
    updateField,
    setTeamAverages: (state, payload) => {
        state.teamAverages = payload;
    },
    setTeamScoreAndLosePoints: (state, payload) => {
        state.teamScoreAndLosePoints = payload;
    },
    setTeamForm: (state, payload) => {
        state.teamForm.name = payload.name;
        state.teamForm.badge = payload.badge;
    }
}

const actions = {
    setTeamAverages: ({ commit }) => {
        service.getTeamAverages()
            .then(response => {
                commit("setTeamAverages", response.data);
            });
    },
    setTeamScoreAndLosePoints: ({ commit }) => {
        service.getTeamScoreAndLosePoints()
            .then(response => {
                commit("setTeamScoreAndLosePoints", response.data);
            });
    },
    setTeamForm: ({ commit }) => {
        service.getTeamForm()
            .then(response => {
                commit("setTeamForm", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };