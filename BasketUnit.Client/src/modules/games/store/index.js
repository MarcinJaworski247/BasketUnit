import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";
const namespaced = true;

const state = {
    gamesList: []
}

const getters = {
    getField,
    getGamesList: (state) => {
        return state.gamesList;
    }
}

const mutations = {
    updateField,
    setGamesList: (state, payload) => {
        state.gamesList = payload;
    }
}

const actions = {
    setGamesList: ({ commit }) => {
        service.getGamesList()
            .then(response => {
                commit("setGamesList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };