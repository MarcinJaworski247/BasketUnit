import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";
import router from "../../../router/index";

const namespaced = true;

const state = {
    detailsForm: {
        Id: null,
        FirstName: '',
        LastName: '',
        TeamId: null,
        PositionId: null,
        BirthDate:  null,
        Nationality: '',
        PlayerAvatar: '',
        TeamName: '',
        TeamBadge: ''
    },
    lastPlayerStatistics: [],
    avarageStatsToChart: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.detailsForm;
    },
    getLastPlayerStatistics: (state) => {
        return state.lastPlayerStatistics;
    },
    getAvarageStatsToChart: (state) => {
        return state.avarageStatsToChart;
    }
}

const mutations = {
    updateField,
    setDetails: (state, payload) => {
        state.detailsForm.Id = payload.Model.Id;
        // to do
    },
    setLastPlayerStatistics: (state, payload) => {
        state.lastPlayerStatistics = payload;
    },
    setAvarageStatsToChart: (state, payload) => {
        state.avarageStatsToChart = payload;
    }
}

const actions = {
    setDetails: ({ commit }) => {
        service.getPlayerDataToDetails(rootState.route.params.playerId)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    // to do
}

export default { state, getters, mutations, actions, namespaced };