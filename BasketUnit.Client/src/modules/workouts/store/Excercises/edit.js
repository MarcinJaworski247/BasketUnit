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
    workoutTypes: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
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
    setWorkoutTypes: (state, payload) => {
        state.workoutTypes = payload;
    },
    setExcersiseDetails: (state, payload) => {
        state.editForm.Id = payload.id,
        state.editForm.Name = payload.name,
        state.editForm.Description = payload.description,
        state.editForm.WorkoutTypeId = payload.workoutTypeId
    }
}

const actions = {
    setWorkoutTypes: ({ commit }) => {
        service.getWorkoutTypesToLookup()
            .then(response => {
                commit("setWorkoutTypes", response.data);
            });
    },
    setExcersiseDetails: ({ commit }, id) => {
        service.getExcersiseDetails(id)
            .then(response => {
                commit("setExcersiseDetails", response.data);
            });
    },
    async editExcersise ({ commit, state, dispatch }) {
        try {
            await service.editExcersise(state.editForm);
            dispatch("WorkoutsExcercisesStore/setExcersisesList", null, { root: true });
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };