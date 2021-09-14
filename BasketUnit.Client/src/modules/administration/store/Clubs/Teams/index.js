import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/Clubs/index";

const state = {
  addForm: {
    Name: "",
    City: "",
    CoachId: null,
    ArenaId: null,
    Badge: "",
  },
  coaches: [],
  arenas: [],
  teams: [],
  idToDelete: null,
};

const getters = {
  getField,
  getForm: (state) => {
    return state.addForm;
  },
  getCoaches: (state) => {
    return state.coaches;
  },
  getArenas: (state) => {
    return state.arenas;
  },
  getTeamsList: (state) => {
    return state.teams;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.addForm.Name = "";
    state.addForm.City = "";
    state.addForm.CoachId = null;
    state.addForm.ArenaId = null;
    state.addForm.Badge = "";
  },
  SET_COACHES: (state, payload) => {
    state.coaches = payload;
  },
  SET_ARENAS: (state, payload) => {
    state.arenas = payload;
  },
  SET_TEAMS_LIST: (state, payload) => {
    state.teams = payload;
  },
};

const actions = {
  async addTeam({ state, dispatch, commit }) {
    try {
      await service.addTeam(state.addForm);
      dispatch("SET_TEAMS_LIST");
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setCoaches: ({ commit }) => {
    service.getCoachesToLookup().then((response) => {
      commit("SET_COACHES", response.data);
    });
  },
  setArenas: ({ commit }) => {
    service.getArenasToLookup().then((response) => {
      commit("SET_ARENAS", response.data);
    });
  },
  setTeamsList: ({ commit }) => {
    service.getTeams().then((response) => {
      commit("SET_TEAMS_LIST", response.data);
    });
  },
  async deleteTeam({ state, dispatch }) {
    try {
      await service.deleteTeam(state.idToDelete);
      dispatch("SET_TEAMS_LIST");
    } catch (err) {
      console.log(err);
    }
  },
};

export default { state, getters, mutations, actions, namespaced: true };
