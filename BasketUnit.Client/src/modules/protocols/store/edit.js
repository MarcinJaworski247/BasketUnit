import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";
import router from "../../../router"
const namespaced = true;

const state = {
    gameStatistics: [],
    editForm: {
        Id: null,
        FullName: '',
        Points: null,
        Assists: null,
        Rebounds: null,
        Steals: null,
        Blocks: null,
        Fouls: null
    }
}

const getters = {
    getField,
    getGameStatistics: (state) => {
        return state.gameStatistics;
    },
    getForm: (state) => {
        return state.editForm;
    }
}

const mutations = {
    updateField,
    setGameStatistics: (state, payload) => {
        state.gameStatistics = payload;
    },
    setGamePlayerStatistics: (state, payload) => {
        state.editForm.Id = payload.id,
        state.editForm.PlayerId = payload.playerId,
        state.editForm.FullName = payload.fullName,
        state.editForm.Points = payload.points,
        state.editForm.Assists = payload.assists,
        state.editForm.Rebounds = payload.rebounds,
        state.editForm.Steals = payload.steals,
        state.editForm.Blocks = payload.blocks,
        state.editForm.Fouls = payload.fouls
    },
    resetForm: (state) => {
        state.editForm.Id = null
        state.editForm.PlayerId = null,
        state.editForm.FullName = '',
        state.editForm.Points = null,
        state.editForm.Assists = null,
        state.editForm.Rebounds = null,
        state.editForm.Steals = null,
        state.editForm.Blocks = null,
        state.editForm.Fouls = null
    }
}

const actions = {
    setGameStatistics: ({ commit }) => {
        service.getGameStatistics(router.currentRoute.params.gameId)
            .then(response => {
                commit("setGameStatistics", response.data);
            });
    },
    setGamePlayerStatistics: ({ commit}, id) => {
        service.getGamePlayerStatistics(id, router.currentRoute.params.gameId)
            .then(response => {
                commit("setGamePlayerStatistics", response.data);
            });
    },
    async saveGamePlayerStatistics ({ commit, dispatch, state }) {
        try {
            await service.saveGamePlayerStatistics(state.editForm);
            dispatch("setGamePlayerStatistics");
            commit("resetForm");
        } catch(err) {
            console.log(err);
        } 
    }
}

export default { state, getters, mutations, actions, namespaced };