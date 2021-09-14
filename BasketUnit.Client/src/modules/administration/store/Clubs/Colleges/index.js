import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/Clubs/index";

const state = {
  addForm: {
    Name: "",
    City: "",
    Badge: "",
  },
  colleges: [],
  idToDelete: null,
};

const getters = {
  getField,
  getForm: (state) => {
    return state.addForm;
  },
  getColleges: (state) => {
    return state.colleges;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    (state.addForm.Name = ""),
      (state.addForm.City = ""),
      (state.addForm.Badge = "");
  },
  SET_COLLEGES: (state, payload) => {
    state.colleges = payload;
  },
};

const actions = {
  async addCollege({ state, dispatch, commit }) {
    try {
      await service.addCollege(state.addForm);
      dispatch("SET_COLLEGES");
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setColleges: ({ commit }) => {
    service.getCollegesList().then((response) => {
      commit("SET_COLLEGES", response.data);
    });
  },
  async deleteCollege({ state, dispatch }) {
    try {
      await service.deleteCollege(state.idToDelete);
      dispatch("SET_COLLEGES");
    } catch (err) {
      console.log(err);
    }
  },
};

export default { state, getters, mutations, actions, namespaced: true };
