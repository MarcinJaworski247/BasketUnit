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
        Avatar: ''
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
    }
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
        state.editForm.Avatar = ''
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
        state.editForm.Id = payload.Model.Id,
        state.editForm.FirstName = payload.Model.FirstName,
        state.editForm.LastName = payload.Model.LastName,
        state.editForm.TeamId = payload.Model.TeamId,
        state.editForm.PositionId = payload.Model.PositionId,
        state.editForm.BirthDate = payload.Model.BirthDate,
        state.editForm.NationalityId = payload.Model.NationalityId,
        state.editForm.Avatar = payload.Model.Avatar
    },
    setNationalities: (state, payload) = {
        state.nationalities = payload;
    }
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
    editPlayer: ({ state }) => {
        service.editPlayer(state.editForm);
    },
    setPlayerDetails: ({ commit }, id) => {
        service.setPlayerDetails(id)
            .then(response => {
                commit("setDetails", response.data);
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