import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";

const state = {
  lastGames: [],
  futureGames: [],
  injuredPlayers: [],
  teamStats: [],
  futureWorkouts: [],
};

const getters = {
  getField,
  getLastGames: (state) => state.lastGames,
  getFutureGames: (state) => state.futureGames,
  getInjuredPlayers: (state) => state.injuredPlayers,
  getFutureWorkouts: (state) => state.futureWorkouts,
};

const mutations = {
  updateField,
  SET_LAST_GAMES: (state, payload) => {
    state.lastGames = payload;
  },
  SET_FUTURE_GAMES: (state, payload) => {
    state.futureGames = payload;
  },
  SET_INJURED_PLAYERS: (state, payload) => {
    state.injuredPlayers = payload;
  },
  SET_FUTURE_WORKOUTS: (state, payload) => {
    state.futureWorkouts = payload;
  },
};

const actions = {
  setLastGames: ({ commit }) => {
    service.getLastGames().then((response) => {
      commit("SET_LAST_GAMES", response.data);
    });
  },
  setFutureGames: ({ commit }) => {
    service.getFutureGames().then((response) => {
      commit("SET_FUTURE_GAMES", response.data);
    });
  },
  setInjuredPlayers: ({ commit }) => {
    service.getInjuredPlayers().then((response) => {
      commit("SET_INJURED_PLAYERS", response.data);
    });
  },
  setFutureWorkouts: ({ commit }) => {
    service.getFutureWorkouts().then((response) => {
      commit("SET_FUTURE_WORKOUTS", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
