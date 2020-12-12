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
        PlayerNumber: null,
        Height: null,
        Weight: null,
        CollegeId: null
    },
    teams: [],
    positions: [],
    nationalities: [],
    colleges: []
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
    getColleges: (state) => {
        return state.colleges;
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
        state.editForm.Avatar = '',
        state.editForm.PlayerNumber = null,
        state.editForm.Height = null,
        state.editForm.Weight = null
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setPositions: (state, payload) => {
        state.positions = payload;
    },
    setDetails: (state, payload) => {
        state.editForm.Id = payload.id,
        state.editForm.FirstName = payload.firstName,
        state.editForm.LastName = payload.lastName,
        state.editForm.TeamId = payload.teamId,
        state.editForm.PositionId = payload.positionId,
        state.editForm.BirthDate = payload.birthDate,
        state.editForm.NationalityId = payload.nationalityId,
        state.editForm.Avatar = payload.avatar,
        state.editForm.PlayerNumber = payload.playerNumber,
        state.editForm.Height = payload.height,
        state.editForm.Weight = payload.weight,
        state.editForm.CollegeId = payload.collegeId
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload;
    },
    setColleges: (state, payload) => {
        state.colleges = payload;
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
    async editPlayer ({ state, commit, dispatch }) {
        try {
            await service.editPlayer(state.editForm);
            dispatch("AdministrationPlayerStore/setPlayersList", null, { root: true });
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
    setColleges: ({ commit }) => {
        service.getCollegesToLookup()
            .then(response => {
                commit("setColleges", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };