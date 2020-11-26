import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";
import router from "../../../router"

const namespaced = true;

const state = {
    detailsForm: {
         Id: null,
         FirstName: '',
         LastName: '',
         BirthDate: null,
         Team: '',
         PlayerNumber: null,
         Avatar: [],
         Nationality: '',
         Position: ''
    },
    lastGamesStats: [],
    chartData: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.detailsForm;
    },
    getLastGamesStats: (state) => {
        return state.lastGamesStats;
    },
    getDataToCharts: (state) => {
        return state.chartData;
    }
}

const mutations = {
    updateField,
    setDetails: (state,  payload) => {
        state.detailsForm.Id = payload.id,
        state.detailsForm.FirstName = payload.firstName,
        state.detailsForm.LastName = payload.lastName,
        state.detailsForm.BirthDate = payload.birthDate,
        state.detailsForm.Team = payload.team,
        state.detailsForm.PlayerNumber = payload.playerNumber,
        state.detailsForm.Avatar = payload.avatar,
        state.detailsForm.Nationality = payload.nationality,
        state.detailsForm.Position = payload.position
    },
    setLastGamesStats: (state, payload) => {
        state.lastGamesStats = payload;
    },
    setDataToChart: (state, payload) => {
        state.chartData = payload;
    }
}

const actions = {
    setDetails: ({ commit, rootState }) => {
        service.getPlayerDetails(router.currentRoute.params.playerId)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    setLastGamesStats: ({ commit, rootState }) => {
        service.getLastGamesStats(router.currentRoute.params.playerId)
            .then(response => {
                commit("setLastGamesStats", response.data);
            });
    },
    setDataToChart: ({ commit, rootState }) => {
        service.getDataToPlayerDetailsChart(router.currentRoute.params.playerId)
            .then(response => {
                commit("setDataToChart", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
