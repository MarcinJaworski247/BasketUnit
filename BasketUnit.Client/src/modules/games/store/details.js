import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";
import router from "@/router";

const state = {
  playersStats: [],
  detailsForm: {
    HomeTeam: "",
    AwayTeam: "",
    HomeTeamBadge: "",
    AwayTeamBadge: "",
    GameDate: null,
    HomeTeamScore: null,
    AwayTeamScore: null,
    Arena: "",
    FirstReferee: "",
    SecondReferee: "",
  },
};

const getters = {
  getField,
  getGamePlayersStats: (state) => state.playersStats,
  getGameDetails: (state) => state.detailsForm,
  getHomeTeamStats: (state) =>
    state.playersStats.filter(
      (stat) => stat.team === state.detailsForm.HomeTeam
    ),
  getAwayTeamStats: (state) =>
    state.playersStats.filter(
      (stat) => stat.team === state.detailsForm.AwayTeam
    ),
};

const mutations = {
  updateField,
  SET_GAME_PLAYER_STATS: (state, payload) => {
    state.playersStats = payload;
  },
  SET_GAME_DETAILS: (state, payload) => {
    state.detailsForm.HomeTeam = payload.homeTeam;
    state.detailsForm.AwayTeam = payload.awayTeam;
    state.detailsForm.HomeTeamBadge = payload.homeTeamBadge;
    state.detailsForm.AwayTeamBadge = payload.awayTeamBadge;
    state.detailsForm.GameDate = payload.gameDate;
    state.detailsForm.HomeTeamScore = payload.homeTeamScore;
    state.detailsForm.AwayTeamScore = payload.awayTeamScore;
    state.detailsForm.Arena = payload.arena;
    state.detailsForm.FirstReferee = payload.firstReferee;
    state.detailsForm.SecondReferee = payload.secondReferee;
  },
};

const actions = {
  setGamePlayersStats: ({ commit, rootState }) => {
    service
      .getGamePlayersStats(router.currentRoute.params.gameId)
      .then((response) => {
        commit("SET_GAME_PLAYER_STATS", response.data);
      });
  },
  setGameDetails: ({ commit, rootState }) => {
    service
      .getGameDetails(router.currentRoute.params.gameId)
      .then((response) => {
        commit("SET_GAME_DETAILS", response.data);
      });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
