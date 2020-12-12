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
        NationalityId: null,
        ExperienceYears: null
    },
    teams: [],
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
        state.editForm.NationalityId = null,
        state.editForm.ExperienceYears = null
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setDetails: (state, payload) => {
        state.editForm.Id = payload.id,
        state.editForm.FirstName = payload.firstName,
        state.editForm.LastName = payload.lastName,
        state.editForm.TeamId = payload.teamId,
        state.editForm.BirthDate = payload.birthDate,
        state.editForm.NationalityId = payload.nationalityId,
        state.editForm.ExperienceYears = payload.experienceYears
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
    async editCoach ({ state, commit, dispatch }) {
        try {
            await service.editCoach(state.editForm);
            dispatch("AdministrationCoachStore/setCoachesList", null, { root: true });
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setCoachDetails: ({ commit }, id) => {
        service.getCoachDetails(id)
            .then(response => {
                commit("setDetails", response.data);
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