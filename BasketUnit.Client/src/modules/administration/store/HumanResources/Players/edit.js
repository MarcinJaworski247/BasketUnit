import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        FirstName: '',
        LastName: '',
        TeamId: null,
        PositionId: null,
        BirthDate:  null,
        NationalityId: null,
        Avatar: '',
        PlayerNumber: null
    },
    teams: [],
    positions: [],
    players: [],
    nationalities: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getTeams: (state) => {
        return state.teams;
    },
    getPositions: (state) => {
        return state.positions;
    },
    getNationalities: (state) => {
        return state.nationalities;
    },
    getPlayersList: (state) => {
        return state.players;
    },
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.Id = null,
        state.editForm.FirstName = '',
        state.editForm.LastName = '',
        state.editForm.TeamId = null,
        state.editForm.PositionId = null,
        state.editForm.BirthDate = null,
        state.editForm.NationalityId = null,
        state.editForm.Avatar = '',
        state.editForm.PlayerNumber = null
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
    setDetails: (state, payload) => {
        debugger
        state.editForm.Id = payload.id,
        state.editForm.FirstName = payload.firstName,
        state.editForm.LastName = payload.lastName,
        state.editForm.TeamId = payload.teamId,
        state.editForm.PositionId = payload.positionId,
        state.editForm.BirthDate = payload.birthDate,
        state.editForm.NationalityId = payload.nationalityId,
        state.editForm.Avatar = payload.avatar,
        state.editForm.PlayerNumber = payload.playerNumber
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload
    },
}

const actions = {
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
    async editPlayer ({ state, commit, dispatch }) {
        debugger
        try {
            await service.editPlayer(state.editForm);
            dispatch("setPlayersList");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setPlayerDetails: ({ commit }, id) => {
        service.getPlayerDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    setNationalities: ({ commit }) => {
        service.getNationalitiesToLookup()
            .then(response => {
                commit("setNationalities", response.data);
            });
    },
    setPlayersList: ({ commit }) => {
        service.getPlayers()
            .then(response => {
                commit("setPlayersList", response.data);
            });
    },
}

export default { state, getters, mutations, actions, namespaced };