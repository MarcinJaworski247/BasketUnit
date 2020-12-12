<template>
    <form @submit.prevent="editReferee">
        <DxValidationGroup :ref="`validationGroup`">
        <div class="form-group">
            <div class="row">
                <div class="col-6">
                    <label>Imię</label>
                    <DxTextBox v-model="FirstName">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
                <div class="col-6">
                    <label>Naziwsko</label>
                    <DxTextBox v-model="LastName">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Narodowość</label>
                    <DxSelectBox 
                        v-model="NationalityId"
                        :data-source="getNationalities"
                        value-expr="value"
                        display-expr="text"
                        :search-enabled="false"
                        placeholder="">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxSelectBox>
                </div>
                <div class="col-6">
                    <label>Data urodzenia</label>
                    <DxDateBox v-model="BirthDate">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxDateBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Data wygaśnięcia licencji</label>
                    <DxDateBox v-model="LicenseExpirationDate">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxDateBox>
                </div>
            </div>
        </div>

        <div class="popup-bottom">
            <DxButton 
                :use-submit-behavior="false"
                styling-mode="outlined"
                type="normal"
                text="Anuluj"
                @click="closePopup" />
            <DxButton 
                :use-submit-behavior="true"
                type="default"
                class="ml-1"
                text="Zapisz"
                @click="closePopupOnSave" />
        </div>
        </DxValidationGroup>
    </form>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxDateBox,
    DxSelectBox
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationEditRefereeStore";

export default {
    name: "refereeEdit",
    computed: {
        ...mapGetters(store, ["getForm", "getNationalities"]),
        ...mapFields(store, [
            "editForm.Id",
            "editForm.FirstName",
            "editForm.LastName",
            "editForm.BirthDate",
            "editForm.NationalityId",
            "editForm.LicenseExpirationDate"
        ])
    },
    methods: {
        ...mapActions(store, ["editReferee", "setNationalities"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeEdit");
            this.resetForm();
        },
        closePopupOnSave: function (e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                this.$emit("closeEdit");
                this.showSuccessNotify();
            }
        },
        showSuccessNotify() {
            this.$nextTick(() => {
                notify("Zapisano", "success", 500);
            });
        }  
    },
    mounted(){
        this.setNationalities();
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup,
        DxDateBox,
        DxSelectBox
    }
};
</script>