import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        TeamId: null,
        BirthDate:  null,
        NationalityId: null,
        ExperienceYears: null
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
    getNationalities: (state)  => {
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
        state.addForm.NationalityId = null,
        state.addForm.ExperienceYears = null
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setCoachesList: (state, payload) => {
        state.coaches = payload;
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
    }
}

const actions = {
    async addCoach ({ state, dispatch, commit }) {
        try {
            await service.addCoach(state.addForm);
            dispatch("setCoachesList");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
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
    setNationalities: ({ commit }) => {
        service.getNationalitiesToLookup()
            .then(response => {
                commit("setNationalities", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
