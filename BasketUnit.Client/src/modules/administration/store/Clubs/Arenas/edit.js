import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/Clubs/index";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        Name: '',
        Address: '',
        Capacity: null
    },
    arenas: [],
    idToDelete: null
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
        state.editForm.Id = null;
        state.editForm.Name = '',
        state.editForm.Address = '',
        state.editForm.Capacity = null
    },
    setDetails: (state, payload) => {
        state.editForm.Id = payload.Model.Id;
        state.editForm.Name = payload.Model.Name,
        state.editForm.Address = payload.Model.Address,
        state.editForm.Capacity = payload.Model.Capacity
    }
}

const actions = {
    editArena: ({ state }) => {
        service.editArena(state.editForm);
    },
    setArenaDetails: ({ commit }, id) => {
        service.setArenaDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };