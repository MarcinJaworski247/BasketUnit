import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/index.js";
const namespaced = true;

const state = {
    activities: [],
    workouts: [],
    teams: [],
    excersices: [],
    newActivity: {
        startDate: null,
        endDate: null,
        subject: '',
        excersiceId: null
    }
}

const getters = {
    getField,
    getActivities: (state) => {
        return state.activities;
    },
    getExcercises: (state) => {
        return state.excersices;
    },
    getTeams: (state) => {
        return state.teams;
    }
}

const mutations = {
    updateField,
    setActivities: (state, payload) => {
        state.activities = payload;
    },
    setExcercises: (state, payload) => {
        state.excersices = payload;
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    }
}

const actions = {
    setActivities: ({ commit }) => {
        service.getActivities()
            .then(response => {
                commit("setActivities", response.data)
            });
    },
    setExcercises: ({ commit }) => {
        service.getExcercisesToLookup()
            .then(response => {
                commit("setExcercises", response.data);
            })
    },
    setTeams: ({ commit }) => {
        service.getTeamsToLookup()
            .then(response => {
                commit("setTeams", response.data)
            });
    }
}

export default { state, getters, mutations, actions, namespaced };