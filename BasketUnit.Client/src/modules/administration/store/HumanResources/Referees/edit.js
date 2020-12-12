import { getField, updateField } from 'vuex-map-fields';
import service from "../../../services/HumanResources/index";

const namespaced = true;

const state = {
    editForm: {
        FirstName: '',
        LastName: '',
        NationalityId: null,
        BirthDate: null,
        LicenseExpirationDate: null
    },
    nationalities: []
}

const getters = {
    getField,
    getForm: (state) => {
        return state.editForm;
    },
    getNationalities: (state) => {
        return state.nationalities;
    },
}

const mutations = {
    updateField,
    resetForm: (state) => {
        state.editForm.FirstName = '',
        state.editForm.LastName = '',
        state.editForm.NationalityId = null,
        state.editForm.BirthDate = null,
        state.editForm.LicenseExparationDate = null
    },
    setDetails: (state, payload) => {
        state.editForm.FirstName = payload.firstName,
        state.editForm.LastName = payload.lastName,
        state.editForm.NationalityId = payload.nationalityId,
        state.editForm.BirthDate = payload.birthDate,
        state.editForm.LicenseExpirationDate = payload.licenseExpirationDate
    },
    setNationalities: (state, payload) => {
        state.nationalities = payload
    },
}

const actions = {
    async editReferee ({ state, commit, dispatch }) {
        try {
            await service.editReferee(state.editForm);
            dispatch("AdministrationRefereeStore/setRefereesList", null, { root: true });
            commit("resetForm");
        } catch (err) {
            console.log(err);
        }
    },
    setRefereeDetails: ({ commit }, id) => {
        service.getRefereeDetails(id)
            .then(response => {
                commit("setDetails", response.data);
            });
    },
    setNationalities: ({ commit }) => {
        service.getNationalitiesToLookup()
            .then(response => {
                commit("setNationalities", response.data);
            });
    }
}

export default { state, getters, mutations, actions, namespaced };