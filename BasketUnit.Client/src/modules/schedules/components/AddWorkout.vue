<template>
    <form @submit.prevent="addWorkout">
        <DxValidationGroup :ref="`workoutValidationGroup`">
            <div class="form-group">
            <div class="row">
                <div class="col-6">
                    <label>Data od</label>
                    <DxDateBox v-model="WorkoutDateFrom" type="datetime">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxDateBox>
                </div>
                <div class="col-6">
                    <label>Data do</label>
                    <DxDateBox v-model="WorkoutDateTo" type="datetime">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxDateBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Trening</label>
                    <DxSelectBox 
                        v-model="ExcerciseId"
                        :data-source="getExcercises"
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
                    <label>Notatki</label>
                    <DxTextArea v-model="Notes"/>
                </div>
            </div>
            </div>
            <div class="popup-bottom">
            <DxButton
                text="Anuluj"
                type="default"
                styling-mode="outlined"
                @click="hideAddWorkoutPopup" />
            <DxButton
                text="Zapisz"
                :use-submit-behavior="true"
                type="default"
                class="ml-1"
                @click="addWorkoutMethod" />
            </div>
        </DxValidationGroup>
        </form>
</template>
<script>
import {
    DxButton,
    DxSelectBox,
    DxDateBox,
    DxTextArea
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "SchedulesStore";
export default {
    name: "gameAdd",
    created(){
        this.setExcercises();
    },
    data(){
        return{
        };
    },
    computed: {
        ...mapGetters(store, [
            "getExcercises"
        ]),
        ...mapFields(store, [
            "addWorkoutForm.WorkoutDateFrom",
            "addWorkoutForm.WorkoutDateTo",
            "addWorkoutForm.ExcerciseId",
            "addWorkoutForm.Notes"
        ]),
    },
    methods: {
        ...mapActions(store, [
            "setExcercises", 
            "addWorkout"
        ]),
        ...mapMutations(store, ["resetAddWorkoutForm"]),
        hideAddWorkoutPopup: function () {
            this.$emit("closeAdd");
            this.resetAddWorkoutForm();
        },
        addWorkoutMethod: function (e) {
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
        },
    },
    mounted() {
        
    },
    components: {
        DxButton,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup,
        DxSelectBox,
        DxDateBox,
        DxTextArea
    }
    
}
</script>