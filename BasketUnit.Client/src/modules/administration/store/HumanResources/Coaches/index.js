import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        TeamId: null,
        BirthDate:  null,
        Nationality: ''
    },
    teams: [],
    coaches: [],
    idToDelete: null
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
    }
    
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.FirstName = '',
        state.addForm.LastName = '',
        state.addForm.TeamId = null,
        state.addForm.BirthDate = null,
        state.addForm.Nationality = ''
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setCoachesList: (state, payload) => {
        state.coaches = payload;
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
    }
}

export default { state, getters, mutations, actions, namespaced };
