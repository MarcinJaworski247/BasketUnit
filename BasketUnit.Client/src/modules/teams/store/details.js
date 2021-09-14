import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";
import router from "@/router";

const state = {
  detailsForm: {
    Id: null,
    FirstName: "",
    LastName: "",
    BirthDate: null,
    Team: "",
    PlayerNumber: null,
    Avatar: [],
    Nationality: "",
    Position: "",
    College: "",
    CollegeBadge: [],
    NationalityFlag: [],
    Height: null,
    Weight: null,
    Injury: "",
    InjuredTo: null,
    IsInjured: false,
  },
  lastGamesStats: [],
  chartData: [],
  injuries: [],
  injuriesAdd: {
    PlayerId: null,
    AddInjury: "",
    AddInjuredTo: null,
  },
  playerAvgs: [],
  playerRecords: [],
  allPlayerGames: [],
  dataToSpiderWeb: [],
  playerCondition: null,
};

const getters = {
  getField,
  getForm: (state) => {
    return state.detailsForm;
  },
  getLastGamesStats: (state) => {
    return state.lastGamesStats;
  },
  getDataToCharts: (state) => {
    return state.chartData;
  },
  getInjuries: (state) => {
    return state.injuries;
  },
  getPlayerAvgs: (state) => {
    return state.playerAvgs;
  },
  getPlayerRecords: (state) => {
    return state.playerRecords;
  },
  getAllPlayerGames: (state) => {
    return state.allPlayerGames;
  },
  getDataToSpiderWeb: (state) => {
    return state.dataToSpiderWeb;
  },
  getPlayerCondition: (state) => {
    return state.playerCondition;
  },
};

const mutations = {
  updateField,
  SET_DETAILS: (state, payload) => {
    state.detailsForm.Id = payload.id;
    state.detailsForm.FirstName = payload.firstName;
    state.detailsForm.LastName = payload.lastName;
    state.detailsForm.BirthDate = payload.birthDate;
    state.detailsForm.Team = payload.team;
    state.detailsForm.PlayerNumber = payload.playerNumber;
    state.detailsForm.Avatar = payload.avatar;
    state.detailsForm.Nationality = payload.nationality;
    state.detailsForm.Position = payload.position;
    state.detailsForm.NationalityFlag = payload.nationalityFlag;
    state.detailsForm.College = payload.college;
    state.detailsForm.CollegeBadge = payload.collegeBadge;
    state.detailsForm.Weight = payload.weight;
    state.detailsForm.Height = payload.height;
    state.detailsForm.InjuredTo = payload.injuredTo;
    state.detailsForm.Injury = payload.injury;
    state.detailsForm.IsInjured = payload.isInjured;
  },
  SET_LAST_GAMES_STATS: (state, payload) => {
    state.lastGamesStats = payload;
  },
  SET_DATA_TO_CHART: (state, payload) => {
    state.chartData = payload;
  },
  SET_INJURIES: (state, payload) => {
    state.injuries = payload;
  },
  RESET_INJURY_ADD: (state) => {
    state.injuriesAdd.PlayerId = null;
    state.injuriesAdd.AddInjury = "";
    state.injuriesAdd.AddInjury = null;
  },
  SET_PLAYER_AVGS: (state, payload) => {
    state.playerAvgs = payload;
  },
  SET_PLAYER_RECORDS: (state, payload) => {
    state.playerRecords = payload;
  },
  SET_ALL_PLAYER_GAMES: (state, payload) => {
    state.allPlayerGames = payload;
  },
  SET_DATA_TO_SPIDER_WEB: (state, payload) => {
    state.dataToSpiderWeb = payload;
  },
  SET_PLAYER_CONDITION: (state, payload) => {
    state.playerCondition = payload;
  },
};

const actions = {
  setDetails: ({ commit }) => {
    service
      .getPlayerDetails(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_DETAILS", response.data);
      });
  },
  setLastGamesStats: ({ commit }) => {
    service
      .getLastGamesStats(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_LAST_GAMES_STATS", response.data);
      });
  },
  setDataToChart: ({ commit }) => {
    service
      .getDataToPlayerDetailsChart(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_DATA_TO_CHART", response.data);
      });
  },
  setInjuries: ({ commit }) => {
    service
      .getPlayerInjuries(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_INJURIES", response.data);
      });
  },
  async addInjury({ state, dispatch, commit }) {
    state.injuriesAdd.PlayerId = Number(router.currentRoute.params.playerId);
    try {
      await service.addInjury(state.injuriesAdd);
      dispatch("setInjuries");
      commit("RESET_INJURIES_ADD");
    } catch (err) {
      console.log(err);
    }
  },
  setPlayerAvgs: ({ commit }) => {
    service
      .getPlayerAvgs(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_PLAYER_AVGS", response.data);
      });
  },
  setPlayerRecords: ({ commit }) => {
    service
      .getPlayerRecords(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_PLAYER_RECORDS", response.data);
      });
  },
  setAllPlayerGames: ({ commit }) => {
    service
      .getAllPlayerGames(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_ALL_PLAYER_GAMES", response.data);
      });
  },
  setDataToSpiderWeb: ({ commit }) => {
    service
      .getDataToSpiderWeb(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_DATA_TO_SPIDER_WEB", response.data);
      });
  },
  setPlayerCondition: ({ commit }) => {
    service
      .getPlayerCondition(router.currentRoute.params.playerId)
      .then((response) => {
        commit("SET_PLAYER_CONDITION", response.data);
      });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
