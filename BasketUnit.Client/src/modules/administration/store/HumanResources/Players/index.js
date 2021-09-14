import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  addForm: {
    FirstName: "",
    LastName: "",
    TeamId: null,
    PositionId: null,
    BirthDate: null,
    NationalityId: null,
    Avatar: "",
    PlayerNumber: null,
    Height: null,
    Weight: null,
    CollegeId: null,
  },
  teams: [],
  positions: [],
  players: [],
  idToDelete: null,
  nationalities: [],
  colleges: [],
};

const getters = {
  getField,
  getForm: (state) => {
    return state.addForm;
  },
  getTeams: (state) => {
    return state.teams;
  },
  getPositions: (state) => {
    return state.positions;
  },
  getPlayersList: (state) => {
    return state.players;
  },
  getNationalities: (state) => {
    return state.nationalities;
  },
  getColleges: (state) => {
    return state.colleges;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.addForm.FirstName = "";
    state.addForm.LastName = "";
    state.addForm.TeamId = null;
    state.addForm.PositionId = null;
    state.addForm.BirthDate = null;
    state.addForm.NationalityId = null;
    state.addForm.Avatar = "";
    state.addForm.PlayerNumber = null;
    state.addForm.Height = null;
    state.addForm.Weight = null;
    state.addForm.CollegeId = null;
  },
  SET_TEAMS: (state, payload) => {
    state.teams = payload;
  },
  SET_POSITIONS: (state, payload) => {
    state.positions = payload;
  },
  SET_PLAYERS_LIST: (state, payload) => {
    state.players = payload;
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
  SET_COLLEGES: (state, payload) => {
    state.colleges = payload;
  },
};

const actions = {
  async addPlayer({ state, dispatch, commit }) {
    try {
      await service.addPlayer(state.addForm);
      dispatch("SET_PLAYERS_LIST");
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setTeams: ({ commit }) => {
    service.getTeamsToLookup().then((response) => {
      commit("SET_TEAMS", response.data);
    });
  },
  setPositions: ({ commit }) => {
    service.getPositionsToLookup().then((response) => {
      commit("setPositions", response.data);
    });
  },
  setPlayersList: ({ commit }) => {
    service.getPlayers().then((response) => {
      commit("SET_PLAYERS_LIST", response.data);
    });
  },
  setNationalities: ({ commit }) => {
    service.getNationalitiesToLookup().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
  async deletePlayer({ state, dispatch }) {
    try {
      await service.deletePlayer(state.idToDelete);
      dispatch("SET_PLAYERS_LIST");
    } catch (err) {
      console.log(err);
    }
  },
  setColleges: ({ commit }) => {
    service.getCollegesToLookup().then((response) => {
      commit("SET_COLLEGES", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
