import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/Clubs/index";

const state = {
  editForm: {
    Id: null,
    Name: "",
    City: "",
    CoachId: null,
    ArenaId: null,
    Badge: "",
  },
  coaches: [],
  arenas: [],
};

const getters = {
  getField,
  getForm: (state) => {
    return state.editForm;
  },
  getCoaches: (state) => {
    return state.coaches;
  },
  getArenas: (state) => {
    return state.arenas;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.editForm.Id = null;
    state.editForm.Name = "";
    state.editForm.City = "";
    state.editForm.CoachId = null;
    state.editForm.ArenaId = null;
    state.editForm.Badge = "";
  },
  SET_COACHES: (state, payload) => {
    state.coaches = payload;
  },
  SET_ARENAS: (state, payload) => {
    state.arenas = payload;
  },
  SET_DETAILS: (state, payload) => {
    state.editForm.Id = payload.id;
    state.editForm.Name = payload.name;
    state.editForm.City = payload.city;
    state.editForm.CoachId = payload.coachId;
    state.editForm.ArenaId = payload.arenaId;
    state.editForm.Badge = payload.badge;
  },
};

const actions = {
  async editTeam({ state, commit, dispatch }) {
    try {
      await service.editTeam(state.editForm);
      dispatch("AdministrationTeamStore/setTeamsList", null, { root: true });
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
  setTeamDetails: ({ commit }, id) => {
    service.setTeamDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
