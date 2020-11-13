import { BIconPause } from 'bootstrap-vue';
import { addLocale } from 'core-js';
import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index.js";

const namespaced = true;

const state = {
    players: [],
    playersStats: [
        {
            Id: null,
            FullName: '',
            Position: '',
            WholePoints: null,
            LastPoints: null,
            FuturePoints: null,
            WholeAssists: null,
            LastAssists: null,
            FutureAssists: null,
            WholeRebounds: null,
            LastRebounds: null,
            FutureRebounds: null
        }
    ],
    selectedPlayer: {
        Id: null,
        FullName: '',
        Position: ''
    },
    teamStats: [
        {
            WholeTeamPoints: null,
            LastTeamPoints: null,
            FutureTeamPoints: null,
            WholeTeamAssists: null,
            LastTeamAssists: null,
            FutureTeamAssists: null,
            WholeTeamRebounds: null,
            LastTeamRebounds: null,
            FutureTeamRebounds: null
        }
    ]
}

const getters = {
    getField,
    getPlayers: (state) => {
        return state.players;
    },
    getPlayersStats: (state) => {
        return state.playersStats.filter(() => {
            return state.playerStats.Id == selectedPlayer.Id;
        })
    },
    getSelectedPlayer: (state) => {
        return state.selectedPlayer;
    },
    getTeamStats: (state) => {
        return state.teamStats;
    }
}

const mutations = {
    updateField,
    setPlayers: (state, payload) => {
        state.players = payload;
    },
    setPlayersStats: (state, payload) => {
        state.playersStats = payload;
    },
    setSelectedPlayer: (state, payload) => {
        state.selectedPlayer = payload;
    },
    setTeamStats: (state, payload) => {
        state.teamStats = payload;
    }
}

const acions = {
    setSelectedPlayer: ({ commit }, data) => {
        commit("setSelectedPlayer", data);
    },
    setPlayers: ({ commit }) => {
        service.getPlayers()
            .then(response => {
                commit("setPlayers", response.data);
            });
    },
    setPlayersStats: ({ commit }) => {
        service.getPlayersStasts()
            .then(response => {
                commit("setPlayersStats", response.data);
            })
    },
    setTeamStats: ({ commit }) => {
        service.getTeamStats()
            .then(response => {
                commit("getTeamStats", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };
