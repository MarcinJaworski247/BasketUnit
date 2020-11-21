import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    addForm: {
        FirstName: '',
        LastName: '',
        TeamId: null,
        PositionId: null,
        BirthDate:  null,
        NationalityId: null,
        Avatar: ''
    },
    teams: [],
    positions: [],
    players: [],
    idToDelete: null,
    nationalities: []
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
    },
    getNationalities: (state) => {
        return state.nationalities;
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
        state.addForm.NationalityId = null,
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
    },
    setNationalities: (State, payload) => {
        state.nationalities = payload;
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
    },
    setNationalities: ({ commit }) => {
        service.getNationalities()
            .then(response => {
                commit("setNationalities", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };