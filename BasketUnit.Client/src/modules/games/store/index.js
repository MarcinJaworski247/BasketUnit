import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";

const state = {
  gamesList: [],
};

const getters = {
  getField,
  getGamesList: (state) => {
    return state.gamesList;
  },
};

const mutations = {
  updateField,
  SET_GAMES_LIST: (state, payload) => {
    state.gamesList = payload;
  },
};

const actions = {
  setGamesList: ({ commit }) => {
    service.getGamesList().then((response) => {
      commit("SET_GAMES_LIST", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
