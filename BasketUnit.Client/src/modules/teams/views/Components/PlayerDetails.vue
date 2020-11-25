<template>
    <div class="content">
        <div class="printers">

            <div class="row">
                <div class="col-6">
                    <!-- informacje -->
                    <img v-bind:src="{Avatar}" />
                    {{ FirstName }} {{ LastName }}
                    {{ Position }}, #{{ PlayerNumber }}
                    Narodowość: {{ Nationality }}
                    Data urodzenia: {{ BirthDate }}

                </div>
                <div class="col-6">
                    <DxChart
                        class="chart"
                        :data-source="getDataToCharts"
                        title="Średnie statystyki na tle reszty zespołu">
                        <DxCommonSeriesSettings
                            argument-field="statType"
                            type="bar">
                            <DxLabel :visible="true">
                                <DxFormat
                                    :precision="0"
                                    type="fixedPOint"/>
                            </DxLabel>
                        </DxCommonSeriesSettings>
                        <DxSeries
                            value-field="playerAvg"
                            name="Zawodnik"/>
                        <DxSeries
                            value-field="restOfTeamAvg"
                            name="Reszta drużyny"/>
                        <DxLegend
                            vertical-alignment="bottom"
                            horizontal-alignment="center"
                        />
                    </DxChart>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <DxDataGrid
                        id="gridContainer"
                        :data-source="getLastGamesStats"
                        key-expr="id"
                        :allow-column-reordering="true"
                        :row-alternation-enabled="true"
                        class="main-datagrid">
                        <DxColumn
                            data-field="opponent"
                            alignment="left"
                            caption="Przeciwko"
                            data-type="string"/>
                        <DxColumn
                            data-field="gameDate"
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
    DxFormat,
    DxLegend
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
        ...mapGetters(store, ["getForm", "getLastGamesStats", "getDataToCharts"])
    },
    methods: {
        ...mapActions(store, ["setDetails", "setLastGamesStats", "setDataToCharts"])
    },
    mounted() {
        this.setDetails();
        this.setLastGamesStats();
        this.setDataToCharts();
    },
    components: {
        DxButton,
        DxDataGrid, 
        DxColumn,
        DxChart, 
        DxSeries,
        DxCommonSeriesSettings,
        DxLabel,
        DxFormat,
        DxLegend
    }
}
</script>

<style scoped>
.chart {
    height: 440px;
}
</style>