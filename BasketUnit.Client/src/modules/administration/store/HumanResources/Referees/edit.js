import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    editForm: {
        FirstName: '',
        LastName: '',
        NationalityId: null,
        BirthDate: null,
        PhoneNumber: '',
        EmailAddress: ''
    },
    referees: [],
    nationalities: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getNationalities: (state) => {
        return state.nationalities;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.FirstName = '',
        state.editForm.LastName = '',
        state.editForm.NationalityId = null,
        state.editForm.BirthDate = null,
        state.editForm.PhoneNumber = ''
        state.editForm.EmailAddress = ''
    },
    setRefereesList: (state, payload) => {
        state.referees = payload;
    },
    setDetails: (state, payload) => {
        state.editForm.FirstName = payload.Model.FirstName,
        state.editForm.LastName = payload.Model.LastName,
        state.editForm.NationalityId = payload.Model.NationalityId,
        state.editForm.BirthDate = payload.Model.BirthDate,
        state.editForm.PhoneNumber = payload.Model.PhoneNumber,
        state.editForm.EmailAddress = payload.Model.EmailAddress
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
    }
}

const actions = {
    editReferee: ({ state }) => {
        service.editReferee(state.editForm);
    },
    setRefereeDetails: ({ commit }, id) => {
        service.setRefereeDetails(id)
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