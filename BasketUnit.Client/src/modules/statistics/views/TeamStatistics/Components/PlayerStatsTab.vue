<template>
<div class="container">
    <DxChart
        id="chart"
        :data-source="getPlayersStats"
        :title="chartTitle">
        <DxCommonSeriesSettings
            argument-field="state"
            type="stackedbar" />
        <DxValueAxis>
            <DxTitle text="" />
        </DxValueAxis>
        <DxSeries
            value-field="wholePoints"
            name="Punkty od początku"
            stack="player" />
        <DxSeries
            value-field="lastPoints"
            name="Punkty (ostatnie 5 meczów)"
            stack="player" />
        <DxSeries
            value-field="futurePoints"
            name="Punkty prognozowane"
            stack="player" />
        <DxSeries
            value-field="wholeAssists"
            name="Asysty od początku"
            stack="player" />
        <DxSeries
            value-field="lastAssists"
            name="Asysty (ostatnie 5 meczów)"
            stack="player" />
            <DxSeries
            value-field="futureAssists"
            name="Asysty prognozowane"
            stack="player" />
        <DxSeries
            value-field="wholeRebounds"
            name="Zbiórki od początku"
            stack="player" />
        <DxSeries
            value-field="lastRebounds"
            name="Zbiórki (ostatnie 5 meczów)"
            stack="player" />
            <DxSeries
            value-field="futureRebounds"
            name="Zbiórki prognozowane"
            stack="player" />
    </DxChart>
    <div>
        <DxSelectBox
            :data-source="getPlayers"
            v-model="SelectedPlayer.Id"
            value-expr="Value"
            text-expr="Text" 
            placeholder="Zawodnik"/>
    </div>
</div>
</template>
<script>
import {
  DxChart,
  DxSeries,
  DxCommonSeriesSettings,
  DxValueAxis,
  DxTitle,
  DxSelectBox
} from 'devextreme-vue/chart';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamStatisticsStore";
export default {
    name: "statisticPlayerTab",
    data() {
        return {
            chartTitle: 'Statystyki zawodnika: '
        };
    },
    computed: {
        ...mapGetters(name, ["getPlayers", "getPlayersStats"])
    },
    methods: {
        ...mapActions(store, ["setPlayers", "setPlayersStats"])
    },
    mounted() {
        this.setPlayers();
        this.setPlayersStats();
    },
    components: {
        DxChart,
        DxSeries,
        DxCommonSeriesSettings,
        DxValueAxis,
        DxTitle,
        DxSelectBox
    }
}
</script>
<style>
#chart {
    height: 440px;
}
</style>