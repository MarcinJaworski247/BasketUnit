<template>
    <form @submit.prevent="editExcersise">
        <DxValidationGroup :ref="`validationGroup`">

        <div class="form-group">
            <div class="row">
                <div class="col-6">
                    <label>Nazwa</label>
                    <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
                <div class="col-6">
                    <label>Rodzaj treningu</label>
                    <DxSelectBox 
                        v-model="WorkoutTypeId"
                        :data-source="getWorkoutTypes"
                        value-expr="value"
                        display-expr="text"
                        :search-enabled="false"
                        placeholder="">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxSelectBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Opis</label>
                    <DxTextArea v-model="Description"/>
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
    DxTextArea
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "WorkoutsExcercisesEditStore";

export default {
    name: "excersiseEdit",
    computed: {
        ...mapGetters(store, ["getForm", "getWorkoutTypes"]),
        ...mapFields(store, [
            "editForm.Id",
            "editForm.Name",
            "editForm.Description",
            "editForm.WorkoutTypeId"
        ])
    },
    methods: {
        ...mapActions(store, ["editExcersise", "setWorkoutTypes", "setExcersiseDetails"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeEdit");
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
        this.setWorkoutTypes();
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxSelectBox,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup,
        DxTextArea
    }
};
</script>