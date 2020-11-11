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
    firstLineupPlayers: []
}

const getters = {
    getField,
    getPlayersList: (state) => {
        return state.playersList;
    },
    getFirstLineupPlayers: (state) => {
        return state.firstLineupPlayers;
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
    } 
}

export default { state, getters, mutations, actions, namespaced };