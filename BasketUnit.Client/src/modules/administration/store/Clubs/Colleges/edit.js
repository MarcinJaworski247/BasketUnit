import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/Clubs/index";

const state = {
  editForm: {
    Id: null,
    Name: "",
    City: "",
    Badge: "",
  },
};

const getters = {
  getField,
  getForm: (state) => {
    return state.editForm;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.editForm.Id = null;
    state.editForm.Name = "";
    state.editForm.City = "";
    state.editForm.Badge = "";
  },
  SET_DETAILS: (state, payload) => {
    state.editForm.Id = payload.id;
    state.editForm.Name = payload.name;
    state.editForm.City = payload.city;
    state.editForm.Badge = payload.badge;
  },
};

const actions = {
  async editCollege({ state, commit, dispatch }) {
    try {
      await service.editCollege(state.editForm);
      dispatch("AdministrationCollegeStore/setColleges", null, { root: true });
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setDetails: ({ commit }, id) => {
    service.getCollegeDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
