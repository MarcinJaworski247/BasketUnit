<template>
    <DxScheduler
        :data-source="getActivities"
        :current-date="currentDate"
        :views="views"
        :groups="groups"
        :height="600"
        :show-all-day-panel="true"
        :first-day-of-week="1"
        :start-day-hour="8"
        :end-day-hour="22"
        current-view="month"
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
</template>
<script>
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
            groups: ['coachId']
        };
    },
    computed: {
        ...mapGetters(store, ["getActivities"])
    },
    methods: {
        ...mapActions(store, ["setActivities"])
    },
    mounted() {
        this.setActivities();
    },
    components: {
        DxScheduler,
        DxResource,
        DataCell,
        //ResourceCell
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