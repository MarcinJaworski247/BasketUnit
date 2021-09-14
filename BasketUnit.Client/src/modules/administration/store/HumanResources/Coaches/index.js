import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  addForm: {
    FirstName: "",
    LastName: "",
    TeamId: null,
    BirthDate: null,
    NationalityId: null,
    ExperienceYears: null,
  },
  teams: [],
  coaches: [],
  idToDelete: null,
  nationalities: [],
};

const getters = {
  getField,
  getForm: (state) => {
    return state.addForm;
  },
  getTeams: (state) => {
    return state.teams;
  },
  getCoachesList: (state) => {
    return state.coaches;
  },
  getNationalities: (state) => {
    return state.nationalities;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.addForm.FirstName = "";
    state.addForm.LastName = "";
    state.addForm.TeamId = null;
    state.addForm.BirthDate = null;
    state.addForm.NationalityId = null;
    state.addForm.ExperienceYears = null;
  },
  SET_TEAMS: (state, payload) => {
    state.teams = payload;
  },
  SET_COACHES_LIST: (state, payload) => {
    state.coaches = payload;
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
};

const actions = {
  async addCoach({ state, dispatch, commit }) {
    try {
      await service.addCoach(state.addForm);
      dispatch("SET_COACHES_LIST");
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
  setCoachesList: ({ commit }) => {
    service.getCoaches().then((response) => {
      commit("SET_COACHES_LIST", response.data);
    });
  },
  setNationalities: ({ commit }) => {
    service.getNationalitiesToLookup().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
