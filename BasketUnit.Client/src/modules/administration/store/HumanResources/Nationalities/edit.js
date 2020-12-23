import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        Name: '',
        Flag: ''
    }
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
        state.editForm.Id = null,
        state.editForm.Name = '',
        state.editForm.Flag = ''
    },
    setDetails: (state, payload) => {
        debugger
        state.editForm.Id = payload.id,
        state.editForm.Name = payload.name,
        state.editForm.Flag = payload.flag
    }
}

const actions = {
    setDetails: ({ commit }, id) => {
        service.getNationalityDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    async editNationality ({ commit, state, dispatch }) {
        try {
            await service.editNationality(state.editForm);
            dispatch("AdministrationNationalityStore/setNationalities", null, { root: true });
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };