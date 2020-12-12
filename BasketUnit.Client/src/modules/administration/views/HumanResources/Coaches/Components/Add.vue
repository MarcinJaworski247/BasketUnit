<template>
    <form @submit.prevent="addCoach">
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
                    <label>Nazwisko</label>
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
                            :search-enabled="true"
                            placeholder="">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxSelectBox>
                </div>
                <div class="col-6">
                    <label>Lata doświadczenia</label>
                    <DxNumberBox v-model="ExperienceYears">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxNumberBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Data urodzenia</label>
                    <DxDateBox v-model="BirthDate">
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
    DxSelectBox,
    DxDateBox,
    DxNumberBox
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationCoachStore";

export default {
    name: "coachAdd",
    computed: {
        ...mapGetters(store, ["getForm", "getTeams", "getNationalities"]),
        ...mapFields(store, [
            "addForm.FirstName",
            "addForm.LastName",
            "addForm.TeamId",
            "addForm.BirthDate",
            "addForm.NationalityId",
            "addForm.ExperienceYears"
        ])
    },
    methods: {
        ...mapActions(store, ["addCoach", "setTeams", "setNationalities"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeAdd");
            this.resetForm();
        },
        closePopupOnSave: function (e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                this.$emit("closeAdd");
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
        this.setTeams();
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
        DxSelectBox,
        DxDateBox,
        DxNumberBox
    }
};
</script>