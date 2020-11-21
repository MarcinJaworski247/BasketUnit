import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        FirstName: '',
        LastName: '',
        TeamId: null,
        BirthDate:  null,
        NationalityId: null
    },
    teams: [],
    coaches: [],
    nationalities: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getTeams: (state) => {
        return state.teams;
    },
    getNationalities: (state)  => {
        return state.nationalities;
    }
    
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.Id = null,
        state.editForm.FirstName = '',
        state.editForm.LastName = '',
        state.editForm.TeamId = null,
        state.editForm.BirthDate = null,
        state.editForm.NationalityId = null
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setCoachesList: (state, payload) => {
        state.coaches = payload;
    },
    setDetails: (state, payload) => {
        state.editForm.Id = payload.Model.Id,
        state.editForm.FirstName = payload.Model.FirstName,
        state.editForm.LastName = payload.Model.LastName,
        state.editForm.TeamId = payload.Model.TeamId,
        state.editForm.BirthDate = payload.Model.BirthDate,
        state.editForm.NationalityId = payload.Model.NationalityId
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
    }
}

const actions = {
    setTeams: ({ commit }) => {
        service.getTeamsToLookup()
            .then(response => {
                commit("setTeams", response.data);
            });
    },
    editCoach: ({ state }) => {
        service.editCoach(state.editForm);
    },
    setCoachDetails: ({ commit }, id) => {
        service.setCoachDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    setNationalities: ({ commit }) => {
        service.getNationalities()
            .then(response => {
                commit("setNationalities", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };