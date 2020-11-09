import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/Clubs/index";
import router from "../../../router/index";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        Name: '',
        City: '',
        CoachId: null,
        ArenaId: null,
        Badge: ''
    },
    coaches: [],
    arenas: [],
    teams: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getCoaches: (state) => {
        return state.coaches;
    },
    getArenas: (state)  => {
        return state.arenas;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.Id = null;
        state.editForm.Name = '',
        state.editForm.City = '',
        state.editForm.CoachId = null,
        state.editForm.ArenaId = null,
        state.editForm.Badge = ''
    },
    setCoaches: (state, payload) => {
        state.coaches = payload;
    },
    setArenas: (state, payload) => {
        state.arenas = payload;
    },
    setDetails: (state, payload) => {
        state.editForm.Id = payload.Model.Id;
        state.editForm.Name = payload.Model.Name,
        state.editForm.City = payload.Model.City,
        state.editForm.CoachId = payload.Model.CoachId,
        state.editForm.ArenaId = payload.Model.ArenaId,
        state.editForm.Badge = payload.Model.Badge
    }
}

const actions = {
    editTeam: ({ state }) => {
        service.editTeam(state.editForm);
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
    setTeamDetails: ({ commit }, id) => {
        service.setTeamDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };