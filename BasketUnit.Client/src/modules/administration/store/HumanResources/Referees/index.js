import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        Nationality: '',
        BirthDate: null,
        PhoneNumber: '',
        EmailAddress: ''
    },
    referees: [],
    idToDelete: null
}

const getters = {
    getField,
    getForm: (state) => {
        return state.addForm;
    },
    getRefereesList: (state) => {
        return state.referees;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.FirstName = '',
        state.addForm.LastName = '',
        state.addForm.Nationality = '',
        state.addForm.BirthDate = null,
        state.addForm.PhoneNumber = ''
        state.addForm.EmailAddress = ''
    },
    setRefereesList: (state, payload) => {
        state.referees = payload;
    }
}

const actions = {
    addReferees: ({ state }) => {
        service.addReferees(state.addForm);
    },
    setRefereesList: ({ commit }) => {
        service.getReferees()
            .then(response => {
                commit("setRefereesList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };