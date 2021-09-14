import { getField, updateField } from "vuex-map-fields";
import service from "../services/index.js";

const state = {
  editForm: {
    Id: null,
    FirstName: "",
    LastName: "",
    PlayerNumber: null,
    PositionId: null,
    BirthDate: null,
    NationalityId: "",
    Avatar: [],
  },
  playersList: [],
  firstLineupPlayers: [],
  positionsList: [],
  firstLineup: {
    pointGuard: {
      Id: null,
      FullName: "",
      Avatar: [],
      PlayerNumber: null,
    },
    shootingGuard: {
      Id: null,
      FullName: "",
      Avatar: [],
      PlayerNumber: null,
    },
    smallForward: {
      Id: null,
      FullName: "",
      Avatar: [],
      PlayerNumber: null,
    },
    powerForward: {
      Id: null,
      FullName: "",
      Avatar: [],
      PlayerNumber: null,
    },
    center: {
      Id: null,
      FullName: "",
      Avatar: [],
      PlayerNumber: null,
    },
  },
  firstLineupToSave: {
    pointGuardId: null,
    shootingGuardId: null,
    smallForwardId: null,
    powerForwardId: null,
    centerId: null,
  },
  pointGuards: [],
  shootingGuards: [],
  smallForwards: [],
  powerForwards: [],
  centers: [],
  nationalities: [],
};

const getters = {
  getField,
  getPlayersList: (state) => {
    return state.playersList;
  },
  getFirstLineupPlayers: (state) => {
    return state.firstLineupPlayers;
  },
  getPositionsToLookup: (state) => {
    return state.positionsList;
  },
  getPointGuards: (state) => {
    return state.pointGuards;
  },
  getShootingGuards: (state) => {
    return state.shootingGuards;
  },
  getSmallForwards: (state) => {
    return state.smallForwards;
  },
  getPowerForwards: (state) => {
    return state.powerForwards;
  },
  getCenters: (state) => {
    return state.centers;
  },
  getNationalities: (state) => {
    return state.nationalities;
  },
  getFirstLineupPointGuard: (state) => {
    return state.firstLineupPlayers.filter((player) => {
      return player.position === "PointGuard";
    });
  },
  getFirstLineupShootingGuard: (state) => {
    return state.firstLineupPlayers.filter((player) => {
      return player.position === "ShootingGuard";
    });
  },
  getFirstLineupSmallForward: (state) => {
    return state.firstLineupPlayers.filter((player) => {
      return player.position === "SmallForward";
    });
  },
  getFirstLineupPowerForward: (state) => {
    return state.firstLineupPlayers.filter((player) => {
      return player.position === "PowerForward";
    });
  },
  getFirstLineupCenter: (state) => {
    return state.firstLineupPlayers.filter((player) => {
      return player.position === "Center";
    });
  },
};

const mutations = {
  updateField,
  SET_PLAYERS_LIST: (state, payload) => {
    state.playersList = payload;
  },
  SET_FIRST_LINEUP_PLAYERS: (state, payload) => {
    payload.forEach((item) => {
      if (item.position === "PointGuard") {
        state.firstLineup.pointGuard.Id = item.id;
        state.firstLineup.pointGuard.FullName = item.fullName;
        state.firstLineup.pointGuard.PlayerNumber = item.playerNumber;
        state.firstLineup.pointGuard.Avatar = item.avatar;
      } else if (item.position === "ShootingGuard") {
        state.firstLineup.shootingGuard.Id = item.id;
        state.firstLineup.shootingGuard.FullName = item.fullName;
        state.firstLineup.shootingGuard.PlayerNumber = item.playerNumber;
        state.firstLineup.shootingGuard.Avatar = item.avatar;
      } else if (item.position === "SmallForward") {
        state.firstLineup.smallForward.Id = item.id;
        state.firstLineup.smallForward.FullName = item.fullName;
        state.firstLineup.smallForward.PlayerNumber = item.playerNumber;
        state.firstLineup.smallForward.Avatar = item.avatar;
      } else if (item.position === "PowerForward") {
        state.firstLineup.powerForward.Id = item.id;
        state.firstLineup.powerForward.FullName = item.fullName;
        state.firstLineup.powerForward.PlayerNumber = item.playerNumber;
        state.firstLineup.powerForward.Avatar = item.avatar;
      } else if (item.position === "Center") {
        state.firstLineup.center.Id = item.id;
        state.firstLineup.center.FullName = item.fullName;
        state.firstLineup.center.PlayerNumber = item.playerNumber;
        state.firstLineup.center.Avatar = item.avatar;
      }
    });
  },
  RESET_FORM: (state) => {
    (state.editForm.Id = null),
      (state.editForm.FirstName = ""),
      (state.editForm.LastName = ""),
      (state.editForm.PlayerNumber = null),
      (state.editForm.PositionId = null),
      (state.editForm.BirthDate = null),
      (state.editForm.NationalityId = null),
      (state.editForm.Avatar = []);
  },
  SET_DETAILS: (state, payload) => {
    (state.editForm.Id = payload.id),
      (state.editForm.FirstName = payload.firstName),
      (state.editForm.LastName = payload.lastName),
      (state.editForm.PlayerNumber = payload.playerNumber),
      (state.editForm.PositionId = payload.positionId),
      (state.editForm.BirthDate = payload.birthDate),
      (state.editForm.NationalityId = payload.nationalityId),
      (state.editForm.Avatar = payload.avatar);
  },
  SET_POSITIONS_TO_LOOKUP: (state, payload) => {
    state.positionsList = payload;
  },
  SET_POINT_GUARDS: (state, payload) => {
    state.pointGuards = payload;
  },
  SET_SHOOTING_GUARDS: (state, payload) => {
    state.shootingGuards = payload;
  },
  SET_SMALL_FORWARDS: (state, payload) => {
    state.smallForwards = payload;
  },
  SET_POWER_FORWARDS: (state, payload) => {
    state.powerForwards = payload;
  },
  SET_CENTERS: (state, payload) => {
    state.centers = payload;
  },
  SET_POINT_GUARD: (state, payload) => {
    state.firstLineup.pointGuard.FirstName = payload.Model.FirstName;
    state.firstLineup.pointGuard.LastName = payload.Model.LastName;
    state.firstLineup.pointGuard.Avatar = payload.Model.Avatar;
    state.firstLineup.pointGuard.Number = payload.Model.Number;
  },
  SET_SHOOTING_GUARD: (state, payload) => {
    state.firstLineup.shootingGuard.FirstName = payload.Model.FirstName;
    state.firstLineup.shootingGuard.LastName = payload.Model.LastName;
    state.firstLineup.shootingGuard.Avatar = payload.Model.Avatar;
    state.firstLineup.shootingGuard.Number = payload.Model.Number;
  },
  SET_SMALL_FORWARD: (state, payload) => {
    state.firstLineup.smallForward.FirstName = payload.Model.FirstName;
    state.firstLineup.smallForward.LastName = payload.Model.LastName;
    state.firstLineup.smallForward.Avatar = payload.Model.Avatar;
    state.firstLineup.smallForward.Number = payload.Model.Number;
  },
  SET_POWER_FORWARD: (state, payload) => {
    state.firstLineup.powerForward.FirstName = payload.Model.FirstName;
    state.firstLineup.powerForward.LastName = payload.Model.LastName;
    state.firstLineup.powerForward.Avatar = payload.Model.Avatar;
    state.firstLineup.powerForward.Number = payload.Model.Number;
  },
  SET_CENTER: (state, payload) => {
    state.firstLineup.center.FirstName = payload.Model.FirstName;
    state.firstLineup.center.LastName = payload.Model.LastName;
    state.firstLineup.center.Avatar = payload.Model.Avatar;
    state.firstLineup.center.Number = payload.Model.Number;
  },
  SET_NATIONALITIES: (state, payload) => {
    state.nationalities = payload;
  },
};

const actions = {
  setPlayersList: ({ commit }) => {
    service.getPlayersList().then((response) => {
      commit("SET_PLAYERS_LIST", response.data);
    });
  },
  setFirstLineupPlayers: ({ commit }) => {
    service.getFirstLineupPlayers().then((response) => {
      commit("SET_FIRST_LINEUP_PLAYERS", response.data);
    });
  },
  setPlayerDetails: ({ commit }, id) => {
    service.setPlayerDetails(id).then((response) => {
      commit("SET_DETAILS", response.data);
    });
  },
  editPlayer: ({ state }) => {
    service.editPlayer(state.editForm);
  },
  setPositionsToLookup: ({ commit }) => {
    service.getPositionsToLookup().then((response) => {
      commit("SET_POSITIONS_TO_LOOKUP", response.data);
    });
  },
  setPointGuards: ({ commit }) => {
    service.getPlayersByPosition(0).then((response) => {
      commit("SET_POINT_GUARDS", response.data);
    });
  },
  setShootingGuards: ({ commit }) => {
    service.getPlayersByPosition(1).then((response) => {
      commit("SET_SHOOTING_GUARDS", response.data);
    });
  },
  setSmallForwards: ({ commit }) => {
    service.getPlayersByPosition(2).then((response) => {
      commit("SET_SMALL_FORWARDS", response.data);
    });
  },
  setPowerForwards: ({ commit }) => {
    service.getPlayersByPosition(3).then((response) => {
      commit("SET_POWER_FORWARDS", response.data);
    });
  },
  setCenters: ({ commit }) => {
    service.getPlayersByPosition(4).then((response) => {
      commit("SET_CENTERS", response.data);
    });
  },
  saveFirstLineup: ({ state }) => {
    service.saveFirstLineup(
      state.firstLineupToSave.pointGuardId,
      state.firstLineupToSave.shootingGuardId,
      state.firstLineupToSave.smallForwardId,
      state.firstLineupToSave.powerForwardId,
      state.firstLineupToSave.centerId
    );
  },
  setNationalities: ({ commit }) => {
    service.getNationalitiesToLookup().then((response) => {
      commit("SET_NATIONALITIES", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced: true };
