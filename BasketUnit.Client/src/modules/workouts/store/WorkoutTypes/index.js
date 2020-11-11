import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/index.js";

const namespaced = true;

const state = {
    addForm: {
        Name: '',
        Description: ''
    },
    workoutTypes: [],
    idToDelete: null
}

const getters = {
    getField,
    getForm: (state) => {
        return state.addForm;
    },
    getWorkoutTypesList: (state) => {
        return state.workoutTypes;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.Name = '',
        state.addForm.Description = ''
    },
    setWorkoutTypesList: (state, payload) => {
        state.workoutTypes = payload;
    }
}

const actions = {
    addWorkoutType: ({ state }) => {
        service.addWorkoutType(state.addForm);
    },
    setWorkoutTypesList: ({ commit }) => {
        service.getWorkoutTypes()
            .then(response => {
                commit("setWorkoutTypesList", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };