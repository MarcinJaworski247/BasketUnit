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
        state.editForm.Id = payload.id,
        state.editForm.Name = payload.name,
        state.editForm.Description = payload.description
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
        service.getWorkoutTypeDetails(id)
            .then(response => {
                commit("setWorkoutTypeDetails", response.data);
            });
    },
    async editWorkoutType ({ commit, state, dispatch }) {
        try {
            await service.editWorkoutType(state.editForm);
            dispatch("setWorkoutTypesList");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };
