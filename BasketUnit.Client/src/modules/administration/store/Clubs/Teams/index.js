import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/Clubs/index";

const namespaced = true;

const state = {
    addForm: {
        Name: '',
        City: '',
        CoachId: null,
        ArenaId: null,
        Badge: ''
    },
    coaches: [],
    arenas: [],
    teams: [],
    idToDelete: null
}

const getters = {
    getField,
    getForm: (state)  => {
        return state.addForm;
    },
    getCoaches: (state) => {
        return state.coaches;
    },
    getArenas: (state)  => {
        return state.arenas;
    },
    getTeamsList: (state) => {
        return state.teams;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.Name = '',
        state.addForm.City = '',
        state.addForm.CoachId = null,
        state.addForm.ArenaId = null,
        state.addForm.Badge = ''
    },
    setCoaches: (state, payload) => {
        state.coaches = payload;
    },
    setArenas: (state, payload) => {
        state.arenas = payload;
    },
    setTeamsList: (state, payload) => {
        state.teams = payload;
    }
}

const actions = {
    async addTeam ({ state, dispatch, commit }) {
        try {
            await service.addTeam(state.addForm);
            dispatch("setTeamsList");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setCoaches: ({ commit }) => {
        service.getCoachesToLookup()
            .then(response => {
                commit("setCoaches", response.data);
            });
    },
    setArenas: ({ commit }) => {
        service.getArenasToLookup()
            .then(response => {
                commit("setArenas", response.data);
            });
    },
    setTeamsList: ({ commit }) => {
        service.getTeams()
            .then(response => {
                commit("setTeamsList", response.data);
            });
    },
    async deleteTeam ({ state, dispatch }) {
        try {
            await service.deleteTeam(state.idToDelete);
            dispatch("setTeamsList");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };