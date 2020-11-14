import { getField, updateField } from 'vuex-map-fields';
import service from "../../services/index.js";

const namespaced = true;

const state = {
    editForm: {
        Id: null,
        Name: '',
        Description: ''
    },
    workoutTypes: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getWorkoutTypesList: (state) => {
        return state.workoutTypes;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.Name = '',
        state.editForm.Description = ''
    },
    setWorkoutTypesList: (state, payload) => {
        state.workoutTypes = payload;
    },
    setWorkoutTypeDetails: (state, payload) => {
        state.editForm.Id = payload.Model.Id,
        state.editForm.Name = payload.Model.Name,
        state.editForm.Description = payload.Model.Description
    }
}

const actions = {
    setWorkoutTypesList: ({ commit }) => {
        service.getWorkoutTypes()
            .then(response => {
                commit("setWorkoutTypesList", response.data);
            });
    },
    setWorkoutTypeDetails: ({ commit }, id) => {
        service.setWorkoutTypeDetails(id)
            .then(response => {
                commit("setWorkoutTypeDetails", response.data);
            });
    },
    editWorkoutType: ({ state }) => {
        service.editWorkoutType(state.editForm);
    }
}

export default { state, getters, mutations, actions, namespaced };
