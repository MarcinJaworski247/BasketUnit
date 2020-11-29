<template>
<div class="content">
    <div class="mb-1">
        <DxButton 
            :use-submit-behavior="false"
            type="default"
            text="Dodaj trening"
            class="main-tabpanel-button"
            @click="showAddWorkoutPopup" />
        <DxButton 
            :use-submit-behavior="false"
            type="default"
            text="Dodaj mecz"
            class="ml-2 main-tabpanel-button"
            @click="showAddGamePopup" />
    </div>
    <DxScheduler
        :data-source="getActivitiesToShow"
        :current-date="currentDate"
        :views="views"
        height="1000"
        :show-all-day-panel="true"
        :first-day-of-week="1"
        :start-day-hour="8"
        :end-day-hour="22"
        current-view="week"
        appointment-template="AppointmentTemplateSlot"
        appointment-tooltip-template="AppointmentTooltipTemplateSlot"
        :on-content-ready="onContentReady">

        <template #AppointmentTemplateSlot="{ data }">
            <AppointmentTemplate
            :scheduler="scheduler"
            :template-model="data"
            />
        </template>

        <template #AppointmentTooltipTemplateSlot="{ data }">
            <AppointmentTooltipTemplate
            :scheduler="scheduler"
            :template-tooltip-model="data"
            />
        </template>

        <!-- <DxResource
            :data-source="coaches"
            :allow-multiple="false"
            label="Trener"
            field-expr="CoachId" />

        <template #dataCellTemplate="{ getActivitiesToShow: cellData }">
            <DataCell
                :cell-data="cellData" />
        </template> -->
    </DxScheduler>


    <!-- add game -->
    <DxPopup
        :visible.sync="addGameVisible"
        :drag-enabled="false"
        :show-title="true"
        height="auto"
        width="auto">
        <div slot="titleTemplate">
            <h3 class="popup-title-text">Dodaj mecz</h3>
        </div>
        <AddGame @closeAdd="hideAddGamePopup"></AddGame>
    </DxPopup>

    <!-- add workout -->
    <DxPopup
        :visible.sync="addWorkoutVisible"
        :drag-enabled="false"
        :show-title="true"
        height="auto"
        width="auto">
        <div slot="titleTemplate">
            <h3 class="popup-title-text">Dodaj trening</h3>
        </div>
        <AddWorkout @closeAdd="hideAddWorkoutPopup"></AddWorkout>
    </DxPopup>


</div>
</template>
<script>
import {
    //DxTextBox,
    DxButton,
    // DxSelectBox,
    DxPopup,
    // DxDateBox,
    // DxTextArea
} from 'devextreme-vue';
import { 
    DxScheduler, 
    //DxResource 
} from 'devextreme-vue/scheduler';
// import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
// import { DxValidationGroup } from "devextreme-vue/validation-group";
//import DataCell from '../components/DataCell';
import AppointmentTemplate from '../components/AppointmentTemplate.vue';
import AppointmentTooltipTemplate from '../components/AppointmentTooltipTemplate.vue';
import AddGame from '../components/AddGame.vue';
import AddWorkout from '../components/AddWorkout.vue';
//import ResourceCell from '../components/ResourceCell';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "SchedulesStore";
export default {
    name: "scheduler",
    data() {
        return {
            currentDate: new Date(),
            views: ['day', 'week', 'month'],
            //groups: ['coachId'],
            addGameVisible: false,
            addWorkoutVisible: false,
            scheduler: null,
        };
    },
    computed: {
        ...mapGetters(store, [
            "getActivitiesToShow", 
            // "getExcercises", 
            // "getTeams", 
            // "getArenas", 
            // "getReferees"
        ]),
        // ...mapFields(store, [
        //     "addGameForm.GameDateFrom",
        //     "addGameForm.GameDateTo",
        //     "addGameForm.HomeTeamId",
        //     "addGameForm.AwayTeamId",
        //     "addGameForm.ArenaId",
        //     "addGameForm.FirstRefereeId",
        //     "addGameForm.SecondRefereeId",
        //     "addWorkoutForm.WorkoutDateFrom",
        //     "addWorkoutForm.WorkoutDateTo",
        //     "addWorkoutForm.ExcerciseId",
        //     "addWorkoutForm.Notes"
        // ])
    },
    methods: {
        ...mapActions(store, [
            "setActivitiesToShow", 
            // "setExcercises", 
            // "setTeams", 
            // "setReferees", 
            // "setArenas", 
            // "addGame", 
            // "addWorkout"
        ]),
        hideAddGamePopup() {
            this.addGameVisible = false;
        },
        addGameMethod(e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                //this.addGame();
                this.showSuccessNotify();
                this.addGameVisible = false;
            }            
        },
        showAddGamePopup() {
            this.addGameVisible = true;
        },

        hideAddWorkoutPopup() {
            this.addWorkoutVisible = false;
        },
        addWorkoutMethod(e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                //this.addWorkout();
                this.showSuccessNotify();
                this.addWorkoutVisible = false;
            }            
        },
        showAddWorkoutPopup() {
            this.addWorkoutVisible = true;
        },
        onContentReady(e) {
            this.scheduler = e.component;
        }
    },
    mounted() {
        this.setActivitiesToShow();
        // this.setExcercises();
        // this.setTeams();
        // this.setReferees();
        // this.setArenas();
    },
    components: {
        DxScheduler,
        //DxResource,
        //DataCell,
        //DxTextBox,
        DxButton,
        //DxSelectBox,
        DxPopup,
        // DxDateBox,
        // DxTextArea,
        // DxValidator,
        // DxRequiredRule,
        // DxValidationGroup,
        AddGame,
        AddWorkout,
        AppointmentTemplate,
        AppointmentTooltipTemplate
    }
};
</script>
<style>
.dx-scheduler-date-table-other-month.dx-scheduler-date-table-cell {
    opacity: 1;
    color: rgba(0, 0, 0, 0.3);
}

.dx-scheduler-date-table-cell, .dx-template-wrapper {
    position: relative;
    height: 100%;
}

.dx-scheduler-date-table-cell .dx-template-wrapper {
    position: absolute;
    width: 100%;
    height: 100%;
}

</style>