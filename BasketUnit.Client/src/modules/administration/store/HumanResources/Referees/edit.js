import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";
import router from "../../../router/index";

const namespaced = true;

const state = {
    editForm: {
        FirstName: '',
        LastName: '',
        Nationality: '',
        BirthDate: null,
        PhoneNumber: '',
        EmailAddress: ''
    },
    referees: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.FirstName = '',
        state.editForm.LastName = '',
        state.editForm.Nationality = '',
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
        state.editForm.Nationality = payload.Model.Nationality,
        state.editForm.BirthDate = payload.Model.BirthDate,
        state.editForm.PhoneNumber = payload.Model.PhoneNumber,
        state.editForm.EmailAddress = payload.Model.EmailAddress
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
    }
}

export default { state, getters, mutations, actions, namespaced };