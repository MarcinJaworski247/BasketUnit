import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";
import router from "../../../router/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        TeamId: null,
        PositionId: null,
        BirthDate:  null,
        Nationality: '',
        Avatar: ''
    },
    teams: [],
    positions: [],
    players: [],
    idToDelete: null
}

const getters = {
    getField,
    getForm: (state) => {
        return state.addForm;
    },
    getTeams: (state) => {
        return state.teams;
    },
    getPositions: (state) => {
        return state.positions;
    },
    getPlayersList: (state) => {
        return state.players;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.FirstName = '',
        state.addForm.LastName = '',
        state.addForm.TeamId = null,
        state.addForm.PositionId = null,
        state.addForm.BirthDate = null,
        state.addForm.Nationality = '',
        state.addForm.Avatar = ''
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setPositions: (state, payload) => {
        state.positions = payload;
    },
    setPlayersList: (state, payload) => {
        state.players = payload;
    }
}

const actions = {
    addPlayer: ({ state }) => {
        service.addPlayer(state.addForm);
    },
    setTeams: ({ commit }) => {
        service.getTeamsToLookup()
            .then(response => {
                commit("setTeams", response.data);
            });
    },
    setPositions: ({ commit }) => {
        service.getPositionsToLookup()
            .then(response => {
                commit("setPositions", response.data);
            });
    },
    setPlayersList: ({ commit }) => {
        service.getPlayers()
            .then(response => {
                commit("setPlayersList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };