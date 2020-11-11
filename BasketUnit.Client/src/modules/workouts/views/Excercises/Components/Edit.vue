<template>
    <form @submit.prevent="editExcersise">
        <DxValidationGroup :ref="`validationGroup`">
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Nazwa</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxTextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Opis</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="Description">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxTextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group row">
                    <label class="col-xs-12">Rodzaj treningu</label>
                    <div class="col-xs-12">
                        <DxSelectBox 
                            v-model="WorkoutTypeId"
                            :data-source="getWorkoutTypes"
                            value-expr="Value"
                            display-expr="Text"
                            :search-enabled="false"
                            placeholder=""/>
                    </div>
                </div>
            </div>
        </div>
        <div class="popup-bottom">
            <DxButton 
                :use-submit-behavior="false"
                styling-mode="text"
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
    DxValidator,
    DxNumberBox,
    DxSelectBox
} from 'devextreme-vue';
import { DxRequiredRule } from "devextreme-vue/validator";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "WorkoutExcersiseEditStore";

export default {
    name: "excersiseEdit",
    created(){

    },
    data(){
        return {

        };
    },
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
        ...mapActions(store, ["editExcersise", "setWorkoutTypes", "setDetails"]),
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
        this.setWorkoutTypes();
        this.setDetails();
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxValidator,
        DxNumberBox,
        DxRequiredRule,
        DxSelectBox
    }
};
</script>
<style scoped>

</style>