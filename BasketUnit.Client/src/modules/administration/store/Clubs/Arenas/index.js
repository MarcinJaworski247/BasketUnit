import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/Clubs/index";

const namespaced = true;

const state = {
    addForm: {
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
        return state.addForm;
    },
    getArenasList: (state) => {
        return state.arenas;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.Name = '',
        state.addForm.Address = '',
        state.addForm.Capacity = null
    },
    setArenasList: (state, payload) => {
        state.arenas = payload;
    }
}

const actions = {
    addArena: ({ state }) => {
        service.addArena(state.addForm);
    },
    setArenasList: ({ commit }) => {
        service.getArenas()
            .then(response => {
                commit("setArenasList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
