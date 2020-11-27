import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        NationalityId: null,
        BirthDate: null,
        LicenseExpirationDate: null
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
        state.addForm.LicenseExpirationDate = null
    },
    setRefereesList: (state, payload) => {
        state.referees = payload;
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
    }
}

const actions = {
    async addReferee ({ state, dispatch, commit }) {
        try {
            await service.addReferee(state.addForm);
            dispatch("setRefereesList");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setRefereesList: ({ commit }) => {
        service.getReferees()
            .then(response => {
                commit("setRefereesList", response.data);
            });
    },
    setNationalities: ({ commit }) => {
        service.getNationalitiesToLookup()
            .then(response => {
                commit("setNationalities", response.data);
            });
    },
    async deleteReferee ({ state, dispatch }) {
        try {
            await service.deleteReferee(state.idToDelete);
            dispatch("setRefereesList");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };