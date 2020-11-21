import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        NationalityId: null,
        BirthDate: null,
        PhoneNumber: '',
        EmailAddress: ''
    },
    referees: [],
    idToDelete: null,
    nationalities: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.addForm;
    },
    getRefereesList: (state) => {
        return state.referees;
    },
    getNationalities: (state) => {
        return state.nationalities;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.FirstName = '',
        state.addForm.LastName = '',
        state.addForm.NationalitId = null,
        state.addForm.BirthDate = null,
        state.addForm.PhoneNumber = ''
        state.addForm.EmailAddress = ''
    },
    setRefereesList: (state, payload) => {
        state.referees = payload;
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
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
    },
    setNationalities: ({ commit }) => {
        service.getNationalities()
            .then(response => {
                commit("setNationalities", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };