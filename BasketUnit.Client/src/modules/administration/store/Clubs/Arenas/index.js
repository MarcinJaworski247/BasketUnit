import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/Clubs/index";

const state = {
  addForm: {
    Name: "",
    Address: "",
    Capacity: null,
  },
  arenas: [],
  idToDelete: null,
};

const getters = {
  getField,
  getForm: (state) => {
    return state.addForm;
  },
  getArenasList: (state) => {
    return state.arenas;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.addForm.Name = "";
    state.addForm.Address = "";
    state.addForm.Capacity = null;
  },
  SET_ARENAS_LIST: (state, payload) => {
    state.arenas = payload;
  },
};

const actions = {
  async addArena({ state, dispatch, commit }) {
    try {
      await service.addArena(state.addForm);
      dispatch("SET_ARENAS_LIST");
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setArenasList: ({ commit }) => {
    service.getArenas().then((response) => {
      commit("SET_ARENAS_LIST", response.data);
    });
  },
  async deleteArena({ state, dispatch }) {
    try {
      await service.deleteArena(state.idToDelete);
      dispatch("SET_ARENAS_LIST");
    } catch (err) {
      console.log(err);
    }
  },
};

export default { state, getters, mutations, actions, namespaced: true };
