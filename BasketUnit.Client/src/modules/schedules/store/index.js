import { getField, updateField } from 'vuex-map-fields';
import service from "../services/index";

const namespaced = true;

const state = {
    activitiesToShow: [],
    teams: [],
    excersices: [],
    arenas: [],
    referees: [],
    addGameForm: {
        GameDateFrom: null,
        GameDateTo: null,
        HomeTeamId: null,
        AwayTeamId: null,
        ArenaId: null,
        FirstRefereeId: null,
        SecondRefereeId: null
    },
    addWorkoutForm: {
        WorkoutDateFrom: null,
        WorkoutDateTo: null,
        ExcerciseId: null,
        Notes: ''
    }
}

const getters = {
    getField,
    getActivitiesToShow: (state) => {
        return state.activitiesToShow;
    },
    getExcercises: (state) => {
        debugger
        return state.excersices;
    },
    getTeams: (state) => {
        return state.teams;
    },
    getArenas: (state) => {
        return state.arenas;
    },
    getReferees: (state) => {
        return state.referees;
    }
}

const mutations = {
    updateField,
    setActivitiesToShow: (state, payload) => {
        state.activitiesToShow = payload;
    },
    setExcercises: (state, payload) => {
        debugger
        state.excersices = payload;
    },
    setTeams: (state, payload) => {
        state.teams = payload;
    },
    setReferees: (state, payload) => {
        state.referees = payload;
    },
    setArenas: (state, payload) => {
        state.arenas = payload;
    },
    resetAddGameForm: (state) => {
        state.addGameForm.GameDateFrom = null;
        state.addGameForm.GameDateTo = null;
        state.addGameForm.HomeTeamId = null;
        state.addGameForm.AwayTeamId = null;
        state.addGameForm.ArenaId = null;
        state.addGameForm.FirstRefereeId = null;
        state.addGameForm.SecondRefereeId = null;
    },
    resetAddWorkoutForm: (state) => {
        state.addWorkoutForm.WorkoutDateFrom = null;
        state.addWorkoutForm.WorkoutDateTo = null;
        state.addWorkoutForm.ExcerciseId = null;
        state.addWorkoutForm.Notes = '';
    }
}

const actions = {
    setActivitiesToShow: ({ commit }) => {
        service.getActivitiesToShow()
            .then(response => {
                commit("setActivitiesToShow", response.data)
            });
    },
    setExcercises: ({ commit }) => {
        debugger
        service.getExcercisesToLookup()
            .then(response => {
                commit("setExcercises", response.data);
            })
    },
    setTeams: ({ commit }) => {
        service.getTeamsToLookup()
            .then(response => {
                commit("setTeams", response.data)
            });
    },
    setReferees: ({ commit }) => {
        service.getRefereesToLookup()
            .then(response => {
                commit("setReferees", response.data)
            });
    },
    setArenas: ({ commit }) => {
        service.getArenasToLookup()
            .then(response => {
                commit("setArenas", response.data)
            });
    },
    async addGame ({ commit, state, dispatch }) {
        try {
            await service.addGame(state.addGameForm);
            dispatch("setActivitiesToShow");
            commit("resetAddGameForm");
        } catch (err) {
            console.log(err);
        }
    },
    async addWorkout ({ commit, state, dispatch }) {
        try {
            await service.addWorkout(state.addWorkoutForm);
            dispatch("setActivitiesToShow");
            commit("resetAddWorkoutForm");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };