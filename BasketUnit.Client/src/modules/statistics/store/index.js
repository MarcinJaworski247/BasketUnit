import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";

const state = {
  teamForm: {
    name: "",
    badge: "",
  },
  teamAverages: [],
  teamScoreAndLosePoints: [],
  futureGames: [],
};

const getters = {
  getField,
  getTeamAverages: (state) => state.teamAverages,
  getTeamScoreAndLosePoints: (state) => state.teamScoreAndLosePoints,
  getFutureGames: (state) => state.futureGames,
};

const mutations = {
  updateField,
  SET_TEAM_AVERAGES: (state, payload) => {
    state.teamAverages = payload;
  },
  SET_TEAM_SCORE_AND_LOSE_POINTS: (state, payload) => {
    state.teamScoreAndLosePoints = payload;
  },
  SET_TEAM_FORM: (state, payload) => {
    state.teamForm.name = payload.name;
    state.teamForm.badge = payload.badge;
  },
  SET_FUTURE_GAMES: (state, payload) => {
    state.futureGames = payload;
  },
};

const actions = {
  setTeamAverages: ({ commit }) => {
    service.getTeamAverages().then((response) => {
      commit("SET_TEAM_AVERAGES", response.data);
    });
  },
  setTeamScoreAndLosePoints: ({ commit }) => {
    service.getTeamScoreAndLosePoints().then((response) => {
      commit("SET_TEAM_SCORE_AND_LOSE_POINTS", response.data);
    });
  },
  setTeamForm: ({ commit }) => {
    service.getTeamForm().then((response) => {
      commit("SET_TEAM_FORM", response.data);
    });
  },
  setFutureGames: ({ commit }) => {
    service.getFutureGames().then((response) => {
      commit("SET_FUTURE_GAMES", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
