import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/Clubs/index";

const namespaced = true;

const state = {
    addForm: {
        Name: '',
        City: '',
        Badge: ''
    },
    colleges: [],
    idToDelete: null
}

const getters = {
    getField,
    getForm: (state)  => {
        return state.addForm;
    },
    getColleges: (state) => {
        return state.colleges;
    }
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.addForm.Name = '',
        state.addForm.City = '',
        state.addForm.Badge = ''
    },
    setColleges: (state, payload) => {
        state.colleges = payload;
    }
}

const actions = {
    async addCollege ({ state, dispatch, commit }) {
        try {
            await service.addCollege(state.addForm);
            dispatch("setColleges");
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setColleges: ({ commit }) => {
        service.getCollegesList()
            .then(response => {
                commit("setColleges", response.data);
            });
    },
    async deleteCollege ({ state, dispatch }) {
        try {
            await service.deleteCollege(state.idToDelete);
            dispatch("setColleges");
        } catch (err) {
            console.log(err);
        }
    }
}

export default { state, getters, mutations, actions, namespaced };