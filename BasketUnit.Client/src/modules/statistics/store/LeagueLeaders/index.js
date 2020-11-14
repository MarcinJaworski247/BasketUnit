import { getField, updateField } from 'vuex-map-fields';
import service from "../../services/LeagueLeaders/index.js";

const namespaced = true;

const state = {
    pointsLeaders: [],
    assistsLeaders: [],
    reboundsLeaders: [],
    blocksLeaders: [],
    stealsLeaders: [],
    // pointsLeaders: [
    //     {
    //         statisticsTitle: '',
    //         fullName: '',
    //         avarage: '',
    //         statisticsType: '',
    //         avatar: '',
    //         team: '',
    //         position: ''
    //     }
    // ]
}

const getters = {
    getField,
    getPointsLeaders: (state) => {
        return state.pointsLeaders;
    },
    getAssistsLeaders: (state) => {
        return state.assistsLeaders;
    },
    getReboundsLeaders: (state) => {
        return state.reboundsLeaders;
    },
    getBlocksLeaders: (state) => {
        return state.blocksLeaders;
    },
    getStealsLeaders: (state) => {
        return state.stealsLeaders;
    }
}

const mutations = {
    updateField,
    setPointsLeaders: (state, payload) => {
        state.pointsLeaders = payload;
    },
    setAssistsLeaders: (state, payload) => {
        state.assistsLeaders = payload;
    },
    setReboundsLeaders: (state, payload) => {
        state.reboundsLeaders = payload;
    },
    setBlocksLeaders: (state, payload) => {
        state.blocksLeaders = payload;
    },
    setStealsLeaders: (state, payload) => {
        state.stealsLeaders = payload;
    }
}

const actions = {
    setPointsLeaders: ({ commit }) => {
        service.getPointsLeaders()
            .then(response => {
                commit("setPointsLeaders", response.data);
            });
    },
    setAssistLeaders: ({ commit }) => {
        service.getAssistsLeaders()
            .then(response => {
                commit("setAssistsLeaders", response.data);
            });
    },
    setReboundsLeaders: ({ commit }) => {
        service.getReboundsLeaders()
            .then(response => {
                commit("setReboundsLeaders", response.data);
            });
    },
    setBlocksLeaders: ({ commit }) => {
        service.getBlocksLeaders()
            .then(response => {
                commit("setBlocksLeaders", response.data);
            });
    },
    setStealsLeaders: ({ commit }) => {
        service.getStealsLeaders()
            .then(response => {
                commit("setStealsLeaders", response.data);
            });
    },
}

export default { state, getters, mutations, actions, namespaced };