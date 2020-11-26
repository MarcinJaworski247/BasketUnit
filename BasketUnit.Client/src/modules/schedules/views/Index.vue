<template>
<div class="content">
    <div>
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
            class="main-tabpanel-button"
            @click="showAddGamePopup" />
    </div>
    <DxScheduler
        :data-source="getActivities"
        :current-date="currentDate"
        :views="views"
        :groups="groups"
        height="800"
        width="1200"
        :show-all-day-panel="true"
        :first-day-of-week="1"
        :start-day-hour="8"
        :end-day-hour="22"
        current-view="week"
        data-cell-template="dataCellTemplate">

        <DxResource
            :data-source="coaches"
            :allow-multiple="false"
            label="Trener"
            field-expr="CoachId" />

        <template #dataCellTemplate="{ getActivities: cellData }">
            <DataCell
                :cell-data="cellData" />
        </template>
    </DxScheduler>


    <!-- add game -->
    <DxPopup
        :visible.sync="addGameVisible"
        :drag-enabled="false"
        :show-title="true"
        title="Dodaj mecz"
        height="auto"
        width="280">
        <div class="row">
            <div class="col-6">
                <label>Data od</label>
                <DxDateBox v-model="GameDateFrom"/>
            </div>
            <div class="col-6">
                <label>Data do</label>
                <DxDateBox v-model="GameDateTo"/>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <label>Drużyna gospodarzy</label>
                <DxSelectBox v-model="HomeTeamId" :data-soruce="getTeams" value-expr="value" display-expr="text" />
            </div>
            <div class="col-6">
                <label>Drużyna gości</label>
                <DxSelectBox v-model="AwayTeamId" :data-soruce="getTeams" value-expr="value" display-expr="text" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <label>Arena</label>
                <DxSelectBox v-model="ArenaId" :data-soruce="getArenas" value-expr="value" display-expr="text" />
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <label>Arbiter 1</label>
                <DxSelectBox v-model="FirstRefereeId" :data-soruce="getReferees" value-expr="value" display-expr="text" />
            </div>
            <div class="col-6">
                <label>Arbiter 2</label>
                <DxSelectBox v-model="SecondRefereeId" :data-soruce="getReferees" value-expr="value" display-expr="text" />
            </div>
        </div>
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideAddGamePopup()" />
        <DxButton
            text="Zapisz"
            type="default"
            styling-mode="outlined"
            @click="addGameMethod()" />
    </DxPopup>

    <!-- add workout -->
    <DxPopup
        :visible.sync="addWorkoutVisible"
        :drag-enabled="false"
        :show-title="true"
        title="Dodaj trening"
        height="auto"
        width="280">
        <div class="row">
            <div class="col-6">
                <label>Data od</label>
                <DxDateBox v-model="WorkoutDateFrom"/>
            </div>
            <div class="col-6">
                <label>Data do</label>
                <DxDateBox v-model="WorkoutDateTo"/>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <label>Trening</label>
                <DxSelectBox v-model="WorkoutId" :data-soruce="getExcercises" value-expr="value" display-expr="text" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <DxTextArea v-model="Notes"/>
            </div>
        </div>
        
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideAddWorkoutPopup()" />
        <DxButton
            text="Zapisz"
            type="default"
            styling-mode="outlined"
            @click="addWorkoutMethod()" />
    </DxPopup>


</div>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxSelectBox,
    DxPopup,
    DxDateBox,
    DxTextArea
} from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { DxScheduler, DxResource } from 'devextreme-vue/scheduler';
import DataCell from '../components/DataCell';
//import ResourceCell from '../components/ResourceCell';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "SchedulesStore";
export default {
    name: "scheduler",
    data() {
        return {
            currentDate: new Date(),
            views: ['day', 'week'],
            groups: ['coachId'],
            addGameVisible: false,
            addWorkoutVisible: false
        };
    },
    computed: {
        ...mapGetters(store, ["getActivitiesToShow", "getExcercises", "getTeams", "getArenas", "getReferees"])
    },
    methods: {
        ...mapActions(store, ["setActivitiesToShow", "setExcercises", "setTeams", "setReferees", "setArenas"]),
        hideAddGamePopup() {
            this.addGameVisible = false;
        },
        addGameMethod() {
            this.addGame();
            this.addGameVisible = false;
        },
        showAddGamePopup() {
            this.addGameVisible = true;
        },

        hideAddGamePopup() {
            this.addWorkoutVisible = false;
        },
        addGameMethod() {
            this.addWorkout();
            this.addWorkoutVisible = false;
        },
        showAddGamePopup() {
            this.addWorkoutVisible = true;
        }
    },
    mounted() {
        this.setActivitiesToShow();
        this.setExcercises();
        this.setTeams();
        this.setReferees();
        this.setArenas();
    },
    components: {
        DxScheduler,
        DxResource,
        DataCell,
        DxTextBox,
        DxButton,
        DxSelectBox,
        DxPopup,
        DxDateBox,
        DxTextArea
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