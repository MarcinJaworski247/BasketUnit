import { getField, updateField } from "vuex-map-fields";
import service from "../../../services/HumanResources/index";

const state = {
  editForm: {
    Id: null,
    FirstName: "",
    LastName: "",
    TeamId: null,
    PositionId: null,
    BirthDate: null,
    NationalityId: null,
    Avatar: "",
    PlayerNumber: null,
    Height: null,
    Weight: null,
    CollegeId: null,
  },
  teams: [],
  positions: [],
  nationalities: [],
  colleges: [],
};

const getters = {
  getField,
  getForm: (state) => {
    return state.editForm;
  },
  getTeams: (state) => {
    return state.teams;
  },
  getPositions: (state) => {
    return state.positions;
  },
  getNationalities: (state) => {
    return state.nationalities;
  },
  getColleges: (state) => {
    return state.colleges;
  },
};

const mutations = {
  updateField,
  RESET_FORM: (state) => {
    state.editForm.Id = null;
    state.editForm.FirstName = "";
    state.editForm.LastName = "";
    state.editForm.TeamId = null;
    state.editForm.PositionId = null;
    state.editForm.BirthDate = null;
    state.editForm.NationalityId = null;
    state.editForm.Avatar = "";
    state.editForm.PlayerNumber = null;
    state.editForm.Height = null;
    state.editForm.Weight = null;
  },
  SET_TEAMS: (state, payload) => {
    state.teams = payload;
  },
  SET_POSITIONS: (state, payload) => {
    state.positions = payload;
  },
  SET_DETAILS: (state, payload) => {
    state.editForm.Id = payload.id;
    state.editForm.FirstName = payload.firstName;
    state.editForm.LastName = payload.lastName;
    state.editForm.TeamId = payload.teamId;
    state.editForm.PositionId = payload.positionId;
    state.editForm.BirthDate = payload.birthDate;
    state.editForm.NationalityId = payload.nationalityId;
    state.editForm.Avatar = payload.avatar;
    state.editForm.PlayerNumber = payload.playerNumber;
    state.editForm.Height = payload.height;
    state.editForm.Weight = payload.weight;
    state.editForm.CollegeId = payload.collegeId;
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
  SET_COLLEGES: (state, payload) => {
    state.colleges = payload;
  },
};

const actions = {
  setTeams: ({ commit }) => {
    service.getTeamsToLookup().then((response) => {
      commit("SET_TEAMS", response.data);
    });
  },
  setPositions: ({ commit }) => {
    service.getPositionsToLookup().then((response) => {
      commit("SET_POSITIONS", response.data);
    });
  },
  async editPlayer({ state, commit, dispatch }) {
    try {
      await service.editPlayer(state.editForm);
      dispatch("AdministrationPlayerStore/setPlayersList", null, {
        root: true,
      });
      commit("RESET_FORM");
    } catch (err) {
      console.log(err);
    }
  },
  setPlayerDetails: ({ commit }, id) => {
    service.getPlayerDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
  setNationalities: ({ commit }) => {
    service.getNationalitiesToLookup().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
  setColleges: ({ commit }) => {
    service.getCollegesToLookup().then((response) => {
      commit("SET_COLLEGES", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
