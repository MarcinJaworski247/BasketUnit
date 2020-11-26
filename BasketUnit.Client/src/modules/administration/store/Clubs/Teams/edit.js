import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/Clubs/index";

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
    },
    getTeamsList: (state) => {
        return state.teams;
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
        debugger
        state.editForm.Id = payload.id;
        state.editForm.Name = payload.name,
        state.editForm.City = payload.city,
        state.editForm.CoachId = payload.coachId,
        state.editForm.ArenaId = payload.arenaId,
        state.editForm.Badge = payload.badge
    },
    setTeamsList: (state, payload) => {
        state.teams = payload;
    }
}

const actions = {
    async editTeam ({ state, commit, dispatch }) {
        try {
            await service.editTeam(state.editForm);
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
    setTeamDetails: ({ commit }, id) => {
        debugger
        service.setTeamDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    setTeamsList: ({ commit }) => {
        service.getTeams()
            .then(response => {
                commit("setTeamsList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };