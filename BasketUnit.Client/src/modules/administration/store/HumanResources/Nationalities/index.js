import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  addForm: {
    Name: "",
    Flag: "",
  },
  nationalities: [],
  idToDelete: null,
};

const getters = {
  getField,
  getForm: (state) => {
    return state.editForm;
  },
  getNationalities: (state) => {
    return state.nationalities;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.addForm.Name = "";
    state.addForm.Flag = "";
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
};

const actions = {
  setNationalities: ({ commit }) => {
    service.getNationalitiesList().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
  setDetails: ({ commit }, id) => {
    service.getNationalityDetails(id).then((response) => {
      commit("setDetails", response.data);
    });
  },
  async addNationality({ commit, state, dispatch }) {
    try {
      await service.addNationality(state.addForm);
      dispatch("SET_NATIONALITIES");
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  async deleteNationality({ state, dispatch }) {
    try {
      await service.deleteNationality(state.idToDelete);
      dispatch("SET_NATIONALITIES");
    } catch (err) {
      console.log(err);
    }
  },
};

export default { state, getters, mutations, actions, namespaced: true };
