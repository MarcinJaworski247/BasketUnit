import { getField, updateField } from 'vuex-map-fields';
import service from "../../services/index.js";

const namespaced = true;

const state = {
    addForm: {
        Name: '',
        Description: '',
        WorkoutTypeId: null
    },
    excersises: [],
    workoutTypes: [],
    idToDelete: null
}

const getters = {
    getField,
    getForm: (state) => {
        return state.addForm;
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
        state.addForm.Name = '',
        state.addForm.Description = '',
        state.addForm.WorkoutTypeId = null
    },
    setExcersisesList: (state, paylaod) => {
        state.excersises = paylaod;
    },
    setWorkoutTypes: (state, payload) => {
        state.workoutTypes = payload;
    }
}

const actions = {
    async addExcersise ({ state, dispatch, commit }) {
        try {
            await service.addExcersise(state.addForm)
            dispatch("setExcersisesList")
            commit("resetForm");
        } catch (err) {
            console.log(err)
        }
    },
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
    async deleteExcercise ({ state, dispatch }) {
        try {
            await service.deleteExcercise(state.idToDelete);
            dispatch("setExcersisesList");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };