import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        FirstName: '',
        LastName: '',
        PlayerNumber: null,
        PositionId: null,
        BirthDate:  null,
        Nationality: '',
        Avatar: ''
    },
    playersList: [],
    firstLineupPayers: [],
    positionsList: [],
    firstLineup : {
        pointGuard: {
            FirstName: '',
            LastName: '',
            Avatar: [],
            Number: null
        },
        shootingGuard: {
            FirstName: '',
            LastName: '',
            Avatar: [],
            Number: null
        },
        smallForward: {
            FirstName: '',
            LastName: '',
            Avatar: [],
            Number: null
        },
        powerForward: {
            FirstName: '',
            LastName: '',
            Avatar: [],
            Number: null
        },
        center: {
            FirstName: '',
            LastName: '',
            Avatar: [],
            Number: null
        }
    },
    firstLineupToSave: {
        pointGuardId: null,
        shootingGuardId: null,
        smallForwardId: null,
        powerForwardId: null,
        centerId: null
    },
    pointGuards: [],
    shootingGuard: [],
    smallForwards: [],
    powerForwards: [],
    centers: []
}

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
    }
}

const mutations = {
    updateField,
    setPlayersList: (state, payload) => {
        state.playersList = payload;
    },
    setFirstLineupPlayers: (state, payload) => {
        state.firstLineupPlayers = payload;
    },
    resetForm: (state) => {
        state.editForm.Id = null,
        state.editForm.FirstName = '',
        state.editForm.LastName = '',
        state.editForm.PlayerNumber = null,
        state.editForm.PositionId = null,
        state.editForm.BirthDate = null,
        state.editForm.Nationality = '',
        state.editForm.Avatar = ''
    },
    setDetails: (state, payload) => {
        state.editForm.Id = payload.Model.Id,
        state.editForm.FirstName = payload.Model.FirstName,
        state.editForm.LastName = payload.Model.LastName,
        state.editForm.PlayerNumber = payload.Model.PlayerNumber,
        state.editForm.PositionId = payload.Model.PositionId,
        state.editForm.BirthDate = payload.Model.BirthDate,
        state.editForm.Nationality = payload.Model.Nationality,
        state.editForm.Avatar = payload.Model.Avatar
    },
    setPositionsToLookup: (state, payload) => {
        state.positionsList = payload;
    },
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
    setPointGuard: (state, payload) => {
        state.firstLineup.pointGuard.FirstName = payload.Model.FirstName;
        state.firstLineup.pointGuard.LastName = payload.Model.LastName;
        state.firstLineup.pointGuard.Avatar = payload.Model.Avatar;
        state.firstLineup.pointGuard.Number = payload.Model.Number;
    },
    setShootingGuard: (state, payload) => {
        state.firstLineup.shootingGuard.FirstName = payload.Model.FirstName;
        state.firstLineup.shootingGuard.LastName = payload.Model.LastName;
        state.firstLineup.shootingGuard.Avatar = payload.Model.Avatar;
        state.firstLineup.shootingGuard.Number = payload.Model.Number;
    },
    setSmallForward: (state, payload) => {
        state.firstLineup.smallForward.FirstName = payload.Model.FirstName;
        state.firstLineup.smallForward.LastName = payload.Model.LastName;
        state.firstLineup.smallForward.Avatar = payload.Model.Avatar;
        state.firstLineup.smallForward.Number = payload.Model.Number;
    },
    setPowerForward: (state, payload) => {
        state.firstLineup.powerForward.FirstName = payload.Model.FirstName;
        state.firstLineup.powerForward.LastName = payload.Model.LastName;
        state.firstLineup.powerForward.Avatar = payload.Model.Avatar;
        state.firstLineup.powerForward.Number = payload.Model.Number;
    },
    setCenter: (state, payload) => {
        state.firstLineup.center.FirstName = payload.Model.FirstName;
        state.firstLineup.center.LastName = payload.Model.LastName;
        state.firstLineup.center.Avatar = payload.Model.Avatar;
        state.firstLineup.center.Number = payload.Model.Number;
    }
}

const actions = {
    setPlayersList: ({ commit }) => {
        service.getPlayersList()
            .then(response => {
                commit("setPlayersList", response.data);
            });
    },
    setFirstLineupPlayers: ({ commit }) => {
        service.getFirstLineupPlayers()
            .then(response => {
                commit("setFirstLineupPlayers", response.data);
            });
    },
    setPlayerDetails: ({ commit }, id) => {
        service.setPlayerDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    editPlayer: ({ state }) => {
        service.editPlayer(state.editForm);
    },
    setPositionsToLookup: ({ commit }) => {
        service.getPositionsToLookup()
            .then(response => {
                commit("setPositionsToLookup", response.data);
            });
    },
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
    saveFirstLineup:({ state }) => {
        service.saveFirstLineup(
            state.firstLineupToSave.pointGuardId, 
            state.firstLineupToSave.shootingGuardId,
            state.firstLineupToSave.smallForwardId,
            state.firstLineupToSave.powerForwardId,
            state.firstLineupToSave.centerId
            );
    },
    setFirstLineup: ({ commit }) => {
        service.getFirstLineupPlayer(0)
            .then(response => {
                commit("setPointGuard", response.data);
            });
        service.getFirstLineupPlayer(1)
            .then(response => {
                commit("setShootingGuard", response.data);
            });
        service.getFirstLineupPlayer(2)
            .then(response => {
                commit("setSmallForward", response.data);
            });
        service.getFirstLineupPlayer(3)
            .then(response => {
                commit("setPowerForward", response.data);
            });
        service.getFirstLineupPlayer(4)
            .then(response => {
                commit("setCenter", response.data);
            });
    }

}

export default { state, getters, mutations, actions, namespaced };