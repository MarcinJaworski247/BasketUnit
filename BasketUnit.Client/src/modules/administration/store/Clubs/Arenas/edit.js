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
    },
    getArenasList: (state) => {
        return state.arenas;
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
        state.editForm.Id = payload.id;
        state.editForm.Name = payload.name,
        state.editForm.Address = payload.address,
        state.editForm.Capacity = payload.capacity
    },
    setArenasList: (state, payload) => {
        state.arenas = payload;
    }
}

const actions = {
    async editArena ({ state, commit, dispatch }) {
        try {    
            await service.editArena(state.editForm);
            dispatch("setArenasList");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setArenasList: ({ commit }) => {
        service.getArenas()
            .then(response => {
                commit("setArenasList", response.data);
            });
    },
    setArenaDetails: ({ commit }, id) => {
        service.setArenaDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };