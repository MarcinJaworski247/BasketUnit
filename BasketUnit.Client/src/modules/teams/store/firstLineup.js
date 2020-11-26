import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";

const namespaced = true;
const state = {
    pointGuards: [],
    shootingGuards: [],
    smallForwards: [],
    powerForwards: [],
    centers: [],
    playersList: [],
    editForm: {
        pointGuardId: null,
        shootingGuardId: null,
        smallForwardId: null,
        powerForwardId: null,
        centerId: null
    },
    firstLineupPlayers: []
}

const getters = {
    getField,
    getPlayersList: (state) => {
        return state.playersList;
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
    getForm: (state) => {
        return state.editForm;
    },
    getFirstLineupPlayers: (state) => {
        return state.firstLineupPlayers;
    }
}

const mutations = {
    updateField,
    setPointGuards: (state, payload) => {
        state.pointGuards = payload;
    },
    setShootingGuards: (state, payload) => {
        state.shootingGuards = payload;
    },
    setSmallForwards: (state, payload) => {
        state.smallForwards = payload;
    },
    setPowerForwards: (state, payload) => {
        state.powerForwards = payload;
    },
    setCenters: (state, payload) => {
        state.centers = payload;
    },
    setPlayersList: (state, payload) => {
        state.playersList = payload;
    },
    setEditForm: (state, payload) => {
        state.editForm.pointGuardId = payload.pointGuardId;
        state.editForm.shootingGuardId = payload.shootingGuardId;
        state.editForm.smallForwardId = payload.smallForwardId;
        state.editForm.powerForwardId = payload.powerForwardId;
        state.editForm.centerId = payload.centerId;
    },
    setFirstLineupPlayers: (state, payload) => {
        state.firstLineupPlayers = payload;
    }
}

const actions = {
    setPointGuards: ({ commit }) => {
        service.getPlayersByPosition(0)
            .then(response => {
                commit("setPointGuards", response.data);
            });
    },
    setShootingGuards: ({ commit }) => {
        service.getPlayersByPosition(1)
            .then(response => {
                commit("setShootingGuards", response.data);
            });
    },
    setSmallForwards: ({ commit }) => {
        service.getPlayersByPosition(2)
            .then(response => {
                commit("setSmallForwards", response.data);
            });
    },
    setPowerForwards: ({ commit }) => {
        service.getPlayersByPosition(3)
            .then(response => {
                commit("setPowerForwards", response.data);
            });
    },
    setCenters: ({ commit }) => {
        service.getPlayersByPosition(4)
            .then(response => {
                commit("setCenters", response.data);
            });
    },
    setPlayersList: ({ commit }) => {
        service.getPlayersList()
            .then(response => {
                commit("setPlayersList", response.data);
            });
    },
    setEditForm: ({ commit }) => {
        service.getEditForm()
            .then(response => {
                commit("setEditForm", response.data);
            });
    },
    async saveFirstLineup ({ state }) {
        debugger
        await service.saveFirstLineup(state.editForm);            
    },
    setFirstLineupPlayers: ({ commit }) => {
        service.getFirstLineupPlayers()
            .then(response => {
                commit("setFirstLineupPlayers", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };