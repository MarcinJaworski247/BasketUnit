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
         Position: '',
         College: '',
         CollegeBadge: [],
         NationalityFlag: [],
         Height: null,
         Weight: null,
         Injury: '',
         InjuredTo: null,
         IsInjured: false
    },
    lastGamesStats: [],
    chartData: [],
    injuries: [],
    injuriesAdd: {
        PlayerId: null,
        AddInjury: '',
        AddInjuredTo: null
    },
    playerAvgs: [],
    playerRecords: [],
    allPlayerGames: [],
    dataToSpiderWeb: []
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
    },
    getInjuries: (state) => {
        return state.injuries;
    },
    getPlayerAvgs: (state) => {
        debugger
        return state.playerAvgs;
    },
    getPlayerRecords: (state) => {
        return state.playerRecords;
    },
    getAllPlayerGames: (state) => {
        return state.allPlayerGames;
    },
    getDataToSpiderWeb: (state) => {
        return state.dataToSpiderWeb;
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
        state.detailsForm.Position = payload.position,
        state.detailsForm.NationalityFlag = payload.nationalityFlag,
        state.detailsForm.College = payload.college,
        state.detailsForm.CollegeBadge = payload.collegeBadge,
        state.detailsForm.Weight = payload.weight,
        state.detailsForm.Height = payload.height,
        state.detailsForm.InjuredTo = payload.injuredTo,
        state.detailsForm.Injury = payload.injury,
        state.detailsForm.IsInjured = payload.isInjured
    },
    setLastGamesStats: (state, payload) => {
        state.lastGamesStats = payload;
    },
    setDataToChart: (state, payload) => {
        state.chartData = payload;
    },
    setInjuries: (state, payload) => {
        state.injuries = payload;
    },
    resetInjuryAdd: (state) => {
        state.injuriesAdd.PlayerId = null;
        state.injuriesAdd.AddInjury = '';
        state.injuriesAdd.AddInjury = null;
    },
    setPlayerAvgs: (state, payload) => {
        state.playerAvgs = payload;
    },
    setPlayerRecords: (state, payload) => {
        state.playerRecords = payload;
    },
    setAllPlayerGames: (state, payload) => {
        state.allPlayerGames = payload;
    },
    setDataToSpiderWeb: (state, payload) => {
        state.dataToSpiderWeb = payload;
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
    },
    setInjuries: ({ commit }) => {
        service.getPlayerInjuries(router.currentRoute.params.playerId)
            .then(response => {
                commit("setInjuries", response.data);
            });
    },
    async addInjury ({ state, dispatch, commit }) {
        state.injuriesAdd.PlayerId = Number(router.currentRoute.params.playerId);
        try {
            await service.addInjury(state.injuriesAdd);
            dispatch("setInjuries");
            commit("resetInjuriesAdd");
        } catch (err) {
            console.log(err);
        }
    },
    setPlayerAvgs: ({ commit }) => {
        service.getPlayerAvgs(router.currentRoute.params.playerId)
            .then(response => {
                commit("setPlayerAvgs", response.data);
            });
    },
    setPlayerRecords: ({ commit }) => {
        service.getPlayerRecords(router.currentRoute.params.playerId)
            .then(response => {
                commit("setPlayerRecords", response.data);
            });
    },
    setAllPlayerGames: ({ commit }) => {
        service.getAllPlayerGames(router.currentRoute.params.playerId)
            .then(response => {
                commit("setAllPlayerGames", response.data);
            });
    },
    setDataToSpiderWeb: ({ commit }) => {
        service.getDataToSpiderWeb(router.currentRoute.params.playerId)
            .then(response => {
                commit("setDataToSpiderWeb", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
