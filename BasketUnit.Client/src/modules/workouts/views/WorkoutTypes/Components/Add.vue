<template>
    <form @submit.prevent="addWorkoutType">
        <DxValidationGroup :ref="`validationGroup`">

        <div class="form-group">
            <div class="row">
                <div class="col-12">
                    <label>Nazwa</label>
                    <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
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
    DxTextArea
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import { mapGetters, mapActions, mapMutations } from "vuex";
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
const store = "WorkoutsTypesStore";

export default {
    name: "workoutTypeAdd",
    created(){

    },
    data(){
        return {

        };
    },
    computed: {
        ...mapGetters(store, ["getForm"]),
        ...mapFields(store, [
            "addForm.Name",
            "addForm.Description"
        ])
    },
    methods: {
        ...mapActions(store, ["addWorkoutType"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeAdd");
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
        DxTextArea
    }
};
</script>
<style scoped>

</style>