import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        Name: '',
        Flag: ''
    },
    nationalities: [],
    idToDelete: null
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
        state.addForm.Name = '',
        state.addForm.Flag = ''
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
    }
}

const actions = {
    setNationalities: ({ commit }) => {
        service.getNationalitiesList()
            .then(response => {
                commit("setNationalities", response.data);
            });
    },
    setDetails: ({ commit }, id) => {
        service.getNationalityDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    async addNationality ({ commit, state, dispatch }) {
        try {
            await service.addNationality(state.addForm);
            dispatch("setNationalities");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    async deleteNationality ({ state, dispatch }) {
        try {
            await service.deleteNationality(state.idToDelete);
            dispatch("setNationalities");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };