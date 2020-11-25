import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";

const namespaced = true;

const state = {
    detailsForm: {
         Id: null,
         FirstName: '',
         LastName: '',
         BirthDate: null,
         Team: '',
         Number: null,
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
        state.detailsForm.Number = payload.number,
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
        service.getPlayerDetails(rootState.route.params.playerId)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    setLastGamesStats: ({ commit, rootState }) => {
        service.getLastGamesStats(rootState.route.params.playerId)
            .then(response => {
                commit("setLastGamesStats", response.data);
            });
    },
    setDataToChart: ({ commit, rootState }) => {
        service.getDataToPlayerDetailsChart(rootState.route.params.playerId)
            .then(response => {
                commit("setDataToChart", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
