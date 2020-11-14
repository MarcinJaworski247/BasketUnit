<template>
    <DxChart
        id="chart"
        :data-source="getTeamStats"
        :title="chartTitle">
        <DxCommonSeriesSettings
            argument-field="state"
            type="stackedbar" />
        <DxValueAxis>
            <DxTitle text="" />
        </DxValueAxis>
        <DxSeries
            value-field="wholeTeamPoints"
            name="Punkty od początku"
            stack="player" />
        <DxSeries
            value-field="lastTeamPoints"
            name="Punkty (ostatnie 5 meczy)"
            stack="player" />
        <DxSeries
            value-field="futureTeamPoints"
            name="Punkty prognozowane"
            stack="player" />
        <DxSeries
            value-field="wholeTeamAssists"
            name="Asysty od początku"
            stack="player" />
        <DxSeries
            value-field="lastTeamAssists"
            name="Asysty (ostatnie 5 meczy)"
            stack="player" />
            <DxSeries
            value-field="futureTeamAssists"
            name="Asysty prognozowane"
            stack="player" />
        <DxSeries
            value-field="wholeTeamRebounds"
            name="Zbiórki od początku"
            stack="player" />
        <DxSeries
            value-field="lastTeamRebounds"
            name="Zbiórki (ostatnie 5 meczy)"
            stack="player" />
            <DxSeries
            value-field="futureTeamRebounds"
            name="Zbiórki prognozowane"
            stack="player" />
    </DxChart>
</template>
<script>
import {
  DxChart,
  DxSeries,
  DxCommonSeriesSettings,
  DxValueAxis,
  DxTitle,
} from 'devextreme-vue/chart';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamStatisticsStore";
export default {
    name: "statisticTeamTab",
    data() {
        return {
            chartTitle: 'Statystyki drużyny'
        };
    },
    computed:  {
        ...mapGetters(store, ["getTeamStats"])
    },
    methods: {
        ...mapActions(store, ["setTeamStats"])
    },
    mounted() {
        this.setTeamStats();
    },
    components: {
        DxChart,
    DxSeries,
    DxCommonSeriesSettings,
    DxValueAxis,
    DxTitle
    }
}
</script>
<style>
#chart {
    height: 440px;
}
</style>