import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  editForm: {
    FirstName: "",
    LastName: "",
    NationalityId: null,
    BirthDate: null,
    LicenseExpirationDate: null,
  },
  nationalities: [],
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
    state.editForm.FirstName = "";
    state.editForm.LastName = "";
    state.editForm.NationalityId = null;
    state.editForm.BirthDate = null;
    state.editForm.LicenseExparationDate = null;
  },
  SET_DETAILS: (state, payload) => {
    state.editForm.FirstName = payload.firstName;
    state.editForm.LastName = payload.lastName;
    state.editForm.NationalityId = payload.nationalityId;
    state.editForm.BirthDate = payload.birthDate;
    state.editForm.LicenseExpirationDate = payload.licenseExpirationDate;
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
};

const actions = {
  async editReferee({ state, commit, dispatch }) {
    try {
      await service.editReferee(state.editForm);
      dispatch("AdministrationRefereeStore/setRefereesList", null, {
        root: true,
      });
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setRefereeDetails: ({ commit }, id) => {
    service.getRefereeDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
  setNationalities: ({ commit }) => {
    service.getNationalitiesToLookup().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
