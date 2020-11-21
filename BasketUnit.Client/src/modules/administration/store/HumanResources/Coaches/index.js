import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        TeamId: null,
        BirthDate:  null,
        NationalityId: null
    },
    teams: [],
    coaches: [],
    idToDelete: null,
    nationalities: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.addForm;
    },
    getTeams: (state) => {
        return state.teams;
    },
    getCoachesList: (state) => {
        return state.coaches;
    },
    getNationalitiesList: (state)  => {
        return state.nationalities;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.FirstName = '',
        state.addForm.LastName = '',
        state.addForm.TeamId = null,
        state.addForm.BirthDate = null,
        state.addForm.NationalityId = null
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setCoachesList: (state, payload) => {
        state.coaches = payload;
    },
    setNationalitiesList: (state, payload) => {
        state.nationalities = payload;
    }
}

const actions = {
    addCoach: ({ state }) => {
        service.addCoach(state.addForm);
    },
    setTeams: ({ commit }) => {
        service.getTeamsToLookup()
            .then(response => {
                commit("setTeams", response.data);
            });
    },
    setCoachesList: ({ commit }) => {
        service.getCoaches()
            .then(response => {
                commit("setCoachesList", response.data);
            });
    },
    setNationalitiesList: ({ commit }) => {
        service.getNationalities()
            .then(response => {
                commit("setNationalitiesList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
