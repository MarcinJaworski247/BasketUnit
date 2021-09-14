import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";

const state = {
  pointGuards: [],
  shootingGuards: [],
  smallForwards: [],
  powerForwards: [],
  centers: [],
  playersList: [],
  editForm: {
    pointGuardId: null,
    shootingGuardId: null,
    smallForwardId: null,
    powerForwardId: null,
    centerId: null,
  },
  firstLineupPlayers: [],
};

const getters = {
  getField,
  getPlayersList: (state) => {
    return state.playersList;
  },
  getPointGuards: (state) => {
    return state.pointGuards;
  },
  getShootingGuards: (state) => {
    return state.shootingGuards;
  },
  getSmallForwards: (state) => {
    return state.smallForwards;
  },
  getPowerForwards: (state) => {
    return state.powerForwards;
  },
  getCenters: (state) => {
    return state.centers;
  },
  getForm: (state) => {
    return state.editForm;
  },
  getFirstLineupPlayers: (state) => {
    return state.firstLineupPlayers;
  },
};

const mutations = {
  updateField,
  SET_POINT_GUARDS: (state, payload) => {
    state.pointGuards = payload;
  },
  SET_SHOOTING_GUARDS: (state, payload) => {
    state.shootingGuards = payload;
  },
  SET_SMALL_FORWARDS: (state, payload) => {
    state.smallForwards = payload;
  },
  SET_POWER_FORWARDS: (state, payload) => {
    state.powerForwards = payload;
  },
  SET_CENTERS: (state, payload) => {
    state.centers = payload;
  },
  SET_PLAYERS_LIST: (state, payload) => {
    state.playersList = payload;
  },
  SET_EDIT_FORM: (state, payload) => {
    state.editForm.pointGuardId = payload.pointGuardId;
    state.editForm.shootingGuardId = payload.shootingGuardId;
    state.editForm.smallForwardId = payload.smallForwardId;
    state.editForm.powerForwardId = payload.powerForwardId;
    state.editForm.centerId = payload.centerId;
  },
  SET_FIRST_LINEUP_PLAYERS: (state, payload) => {
    state.firstLineupPlayers = payload;
  },
};

const actions = {
  setPointGuards: ({ commit }) => {
    service.getPlayersByPosition(0).then((response) => {
      commit("SET_POINT_GUARDS", response.data);
    });
  },
  setShootingGuards: ({ commit }) => {
    service.getPlayersByPosition(1).then((response) => {
      commit("SET_SHOOTING_GUARDS", response.data);
    });
  },
  setSmallForwards: ({ commit }) => {
    service.getPlayersByPosition(2).then((response) => {
      commit("SET_SMALL_FORWARDS", response.data);
    });
  },
  setPowerForwards: ({ commit }) => {
    service.getPlayersByPosition(3).then((response) => {
      commit("SET_POWER_FORWARDS", response.data);
    });
  },
  setCenters: ({ commit }) => {
    service.getPlayersByPosition(4).then((response) => {
      commit("SET_CENTERS", response.data);
    });
  },
  setPlayersList: ({ commit }) => {
    service.getPlayersList().then((response) => {
      commit("SET_PLAYERS_LIST", response.data);
    });
  },
  setEditForm: ({ commit }) => {
    service.getEditForm().then((response) => {
      commit("SET_EDIT_FORM", response.data);
    });
  },
  async saveFirstLineup({ state, dispatch }) {
    try {
      await service.saveFirstLineup(state.editForm);
      dispatch("SET_FIRST_LINEUP_PLAYERS");
    } catch (err) {
      console.log(err);
    }
  },
  setFirstLineupPlayers: ({ commit }) => {
    service.getFirstLineupPlayers().then((response) => {
      commit("SET_FIRST_LINEUP_PLAYERS", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
