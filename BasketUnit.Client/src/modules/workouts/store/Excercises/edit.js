import { getField, updateField } from 'vuex-map-fields';
import service from "../../services/index.js";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        Name: '',
        Description: '',
        WorkoutTypeId: null
    },
    excersises: [],
    workoutTypes: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getExcersisesList: (state) => {
        return state.excersises;
    },
    getWorkoutTypes: (state) => {
        return state.workoutTypes;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.Name = '',
        state.editForm.Description = '',
        state.editForm.WorkoutTypeId = null
    },
    setExcersisesList: (state, paylaod) => {
        state.excersises = paylaod;
    },
    setWorkoutTypes: (state, payload) => {
        state.workoutTypes = payload;
    },
    setExcersiseDetails: (state, payload) => {
        state.editForm.Id = payload.Model.Id,
        state.editForm.Name = payload.Model.Name,
        state.editForm.Description = payload.Model.Description,
        state.editForm.WorkoutTypeId = payload.Model.WorkoutTypeId
    }
}

const actions = {
    setExcersisesList: ({ commit }) => {
        service.getExcersises()
            .then(response => {
                commit("setExcersisesList", response.data);
            });
    },
    setWorkoutTypes: ({ commit }) => {
        service.getWorkoutTypesToLookup()
            .then(response => {
                commit("setWorkoutTypes", response.data);
            });
    },
    setExcersiseDetails: ({ commit }, id) => {
        service.setExcersiseDetails(id)
            .then(response => {
                commit("setExcersiseDetails", response.data);
            });
    },
    editExcersise: ({ state }) => {
        service.editExcersise(state.editForm);
    }
}

export default { state, getters, mutations, actions, namespaced };
