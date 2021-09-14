import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  editForm: {
    Id: null,
    Name: "",
    Flag: "",
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
    state.editForm.Flag = "";
  },
  SET_DETAILS: (state, payload) => {
    state.editForm.Id = payload.id;
    state.editForm.Name = payload.name;
    state.editForm.Flag = payload.flag;
  },
};

const actions = {
  setDetails: ({ commit }, id) => {
    service.getNationalityDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
  async editNationality({ commit, state, dispatch }) {
    try {
      await service.editNationality(state.editForm);
      dispatch("AdministrationNationalityStore/setNationalities", null, {
        root: true,
      });
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
};

export default { state, getters, mutations, actions, namespaced: true };
