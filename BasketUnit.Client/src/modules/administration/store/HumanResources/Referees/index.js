import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  addForm: {
    FirstName: "",
    LastName: "",
    NationalityId: null,
    BirthDate: null,
    LicenseExpirationDate: null,
  },
  referees: [],
  idToDelete: null,
  nationalities: [],
};

const getters = {
  getField,
  getForm: (state) => {
    return state.addForm;
  },
  getRefereesList: (state) => {
    return state.referees;
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
    state.addForm.NationalitId = null;
    state.addForm.BirthDate = null;
    state.addForm.LicenseExpirationDate = null;
  },
  SET_REFEREES_LIST: (state, payload) => {
    state.referees = payload;
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
};

const actions = {
  async addReferee({ state, dispatch, commit }) {
    try {
      await service.addReferee(state.addForm);
      dispatch("SET_REFEREES_LIST");
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setRefereesList: ({ commit }) => {
    service.getReferees().then((response) => {
      commit("SET_REFEREES_LIST", response.data);
    });
  },
  setNationalities: ({ commit }) => {
    service.getNationalitiesToLookup().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
  async deleteReferee({ state, dispatch }) {
    try {
      await service.deleteReferee(state.idToDelete);
      dispatch("SET_REFEREES_LIST");
    } catch (err) {
      console.log(err);
    }
  },
};

export default { state, getters, mutations, actions, namespaced: true };
