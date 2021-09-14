import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/Clubs/index";

const state = {
  editForm: {
    Id: null,
    Name: "",
    Address: "",
    Capacity: null,
  },
  idToDelete: null,
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
    (state.editForm.Name = ""),
      (state.editForm.Address = ""),
      (state.editForm.Capacity = null);
  },
  SET_DETAILS: (state, payload) => {
    state.editForm.Id = payload.id;
    (state.editForm.Name = payload.name),
      (state.editForm.Address = payload.address),
      (state.editForm.Capacity = payload.capacity);
  },
};

const actions = {
  async editArena({ state, commit, dispatch }) {
    try {
      await service.editArena(state.editForm);
      dispatch("AdministrationArenaStore/setArenasList", null, { root: true });
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setArenaDetails: ({ commit }, id) => {
    service.setArenaDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
