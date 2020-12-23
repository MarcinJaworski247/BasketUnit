<template>
    <div class="container">
        <div class="printers">
            
            <div class="row">
                <div class="col-6"><!-- średnie zdobycze -->
                    <div v-for="item in getPlayerAvgs" v-bind:key="item.statType">
                        <span>{{ item.statType }}}</span>
                        <span>{{ item.avg }}}</span>
                    </div>
                </div>
                <div class="col-6">
                    <!-- spider web chart -->
                    <DxPolarChart
                        :data-source="getDataToSpiderWeb"
                        :use-spider-web="true"
                    >
                        <DxCommonSeriesSettings type="line"/>
                        <DxSeries
                            v-for="item in sources"
                            :key="item.value"
                            :value-field="item.value"
                            :name="item.name"
                            />
                        <DxTooltip :enabled="true"/>
                    </DxPolarChart>
                </div>
            </div>
            
            
            <div class="row">
                <!-- statystyki na tle drużyny -->
                <DxChart
                    :data-source="getDataToCharts"
                    title="Średnie statystyki  na tle reszty zespołu"
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

            <div class="row">
                <!-- rekordy w sezonie -->
                <div v-for="item in getPlayerRecords" v-bind:key="item.statType">
                    <span>{{ item.statType }}}</span>
                    <span>{{ item.score }}}</span>
                </div>
            </div>
            
            <div class="row">
                <!-- grid mecze zawodnika -->
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
                    <DxColumn 
                        data-field="gameId"
                        alignment="center"
                        caption=""
                        cell-template="actionsCellTemplate"
                        :allow-search="false"
                        :allow-filtering="false"
                        width="100"
                    />
                    <div slot="actionsCellTemplate" slot-scope="{ data }">
                        <DxButton @click="function(){ $router.push({ name: 'games.details', params: { gameId: data.data.gameId } }) }" hint="Szczegóły" title="Szczegóły" icon="fas fa-chevron-right" class="datagrid-button" type="normal" />
                    </div>
                </DxDataGrid>
            </div>
        </div>
    </div>
</template>
<script>
import { 
    DxChart, 
    DxSeries,
    DxCommonSeriesSettings,
    DxLabel,
    DxFormat
} from 'devextreme-vue/chart';
import {
    DxDataGrid, 
    DxColumn,
} from 'devextreme-vue/data-grid'
import {
  DxPolarChart,
  DxCommonSeriesSettings,
  DxSeries,
  DxExport,
  DxTooltip
} from 'devextreme-vue/polar-chart';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamPlayerDetailsStore";
export default {
    data(){
        return {
            sources: [
                {
                    value: 'avg',
                    name: 'xyz test'
                }
            ]
        };
    },
    computed: {
        ...mapGetters(store, ["getDataToCharts", "getPlayerAvgs", "getPlayerRecords", "getAllPlayerGames", "getDataToSpiderWeb"]),
    },
    methods: {
        ...mapActions(store, ["setDataToChart", "setPlayerAvgs", "setPlayerRecords", "setAllPlayerGames", "setDataToSpiderWeb"]),
    },
    mounted(){
        this.setDataToChart();
        this.setPlayerRecords();
        this.setAllPlayerGames();
        this.setPlayerAvgs();
        this.setDataToSpiderWeb();
    },
    components: {
        DxChart, 
        DxSeries,
        DxCommonSeriesSettings,
        DxLabel,
        DxFormat,
        DxDataGrid, 
        DxColumn,
        DxPolarChart,
        DxCommonSeriesSettings,
        DxSeries,
        DxExport,
        DxTooltip
    }
}
</script>