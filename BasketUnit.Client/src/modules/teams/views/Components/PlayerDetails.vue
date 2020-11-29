<template>
    <div class="content">
        <div class="printers">

            <div class="row mt-4" style="border: 1px solid black;">
                <div class="col-4">
                    <!-- informacje -->
                    <img style="width: 250px; border: 1px solid black; margin-top: 10px;" v-bind:src="'data:image/jpeg;base64,'+Avatar" />
                    <div class="row mt-2 ml-2"><h2>{{ FirstName }} {{ LastName }}</h2></div>
                    <div class="row mt-2 ml-2"><h4>{{ Position + " " }}</h4> <h4> #{{ PlayerNumber }}</h4></div>
                    <div class="row mt-2 ml-2"><h4>Narodowość: </h4> <h4 style="font-weight: normal;">{{ " " + Nationality }}</h4></div>
                    <div class="row mt-2 ml-2"><h4>Data urodzenia:</h4> <h4 style="font-weight: normal">{{ BirthDate }}</h4></div>

                </div>
                <div class="col-8">
                    <div class="mb-4">
                    <DxChart
                        class="chart"
                        :data-source="getDataToCharts"
                        title="Średnie statystyki  na tle reszty zespołu"
                        width="auto"
                        height="auto"
                        >
                        <DxCommonSeriesSettings
                            argument-field="statType"
                            type="bar">
                            <DxLabel :visible="true">
                                <DxFormat
                                    :precision="2"
                                    type="fixedPOint"/>
                            </DxLabel>
                        </DxCommonSeriesSettings>
                        <DxSeries
                            value-field="playerAvg"
                            name="Zawodnik"/>
                        <DxSeries
                            value-field="restOfTeamAvg"
                            name="Reszta drużyny"/>
                    </DxChart>
                    </div>
                </div>
            </div>
            <div class="row mt-4" style="border: 1px solid black;">
                <div class="col-12 mb-2">
                <h3 class="mt-2">Statystyki z ostatnich meczów </h3>
                    <DxDataGrid
                        id="gridContainer"
                        :data-source="getLastGamesStats"
                        key-expr="opponent"
                        :allow-column-reordering="true"
                        :row-alternation-enabled="true"
                        class="main-datagrid">
                        <DxColumn
                            data-field="opponent"
                            alignment="left"
                            caption="Przeciwko"
                            data-type="string"/>
                        <DxColumn
                            data-field="gameTime"
                            alignment="center"
                            caption="Data"
                            data-type="date"/>
                        <DxColumn
                            data-field="points"
                            alignment="center"
                            caption="Punkty"
                            data-type="number"/>
                        <DxColumn
                            data-field="assists"
                            alignment="center"
                            caption="Asysty"
                            data-type="number"/>
                        <DxColumn
                            data-field="rebounds"
                            alignment="center"
                            caption="Zbiórki"
                            data-type="number"/>
                        <DxColumn
                            data-field="steals"
                            alignment="center"
                            caption="Przechwyty"
                            data-type="number"/>
                        <DxColumn
                            data-field="blocks"
                            alignment="center"
                            caption="Bloki"
                            data-type="number"/>
                        <DxColumn
                            data-field="fouls"
                            alignment="center"
                            caption="Faule"
                            data-type="number"/>

                    </DxDataGrid>
                </div>
            </div>

        </div>
        <div class="d-flex end-xs mt-5">
        <DxButton
            :use-submit-behavior="false"
            type="normal"
            styling-mode="outlined"
            text="Wróć"
            @click="function(){ $router.push({ name: 'team.index' }) }"/>
        </div>
    </div>
</template>

<script>
import { 
    DxButton
} from 'devextreme-vue';
import {
    DxDataGrid, 
    DxColumn,
} from 'devextreme-vue/data-grid'
import { 
    DxChart, 
    DxSeries,
    DxCommonSeriesSettings,
    DxLabel,
    DxFormat
} from 'devextreme-vue/chart';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamPlayerDetailsStore";
export default {
    name: "playerDetails",
    data() {
        return {

        };
    },
    created() {

    },
    computed: {
        ...mapGetters(store, ["getForm", "getLastGamesStats", "getDataToCharts"]),
        ...mapFields(store, [
            "detailsForm.Id",
            "detailsForm.FirstName",
            "detailsForm.LastName",
            "detailsForm.BirthDate",
            "detailsForm.Team",
            "detailsForm.PlayerNumber",
            "detailsForm.Avatar",
            "detailsForm.Nationality",
            "detailsForm.Position"
        ])
    },
    methods: {
        ...mapActions(store, ["setDetails", "setLastGamesStats", "setDataToChart"])
    },
    mounted() {
        this.setDetails();
        this.setLastGamesStats();
        this.setDataToChart();
    },
    components: {
        DxButton,
        DxDataGrid, 
        DxColumn,
        DxChart, 
        DxSeries,
        DxCommonSeriesSettings,
        DxLabel,
        DxFormat
    }
}
</script>

<style scoped>
.chart {
    height: 440px;
}
</style>