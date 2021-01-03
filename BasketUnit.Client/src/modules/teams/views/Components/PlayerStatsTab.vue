<template>
  <div class="container">
    <div class="printers">
      <div class="row">
        <div class="col-12">
          <div class="player-tile">
            <img
              v-if="Avatar.length"
              style="width: 250px;"
              v-bind:src="'data:image/jpeg;base64,' + Avatar"
            />
            <h2>{{ FirstName }} {{ LastName }}</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-3">
          <h3 class="little-header">Średnie statystyki</h3>
          <div>
            <!-- średnie zdobycze -->
            <div
              v-for="item in getPlayerAvgs"
              v-bind:key="item.statType"
              class="stat-tile"
            >
              <span>{{ item.statType }}</span>
              <div class="avg">{{ Number(item.avg.toFixed(2)) }}</div>
            </div>
          </div>
        </div>
        <div class="col-9">
          <!-- dougnut chart -->
          <DxPieChart
            :data-source="getDataToSpiderWeb"
            type="doughnut"
            title=""
            palette="Harmony Light"
            id="pie"
          >
            <DxSeries argument-field="arg">
              <DxLabel :visible="true" format="decimal">
                <DxConnector :visible="true" />
              </DxLabel>
            </DxSeries>
            <DxLegend
              :margin="0"
              horizontal-alignment="right"
              vertical-alignment="top"
            />
          </DxPieChart>
        </div>
      </div>

      <!-- <div class="row mt-4"> -->
        
      <!-- </div> -->

      <div class="row mt-4">
        <h3 class="little-header">Średnie statystyki na tle reszty zespołu</h3>
        <div class="col-12">
          <!-- statystyki na tle drużyny -->
          <DxChart :data-source="getDataToCharts" title="" palette="Harmony Light">
            <DxCommonSeriesSettings argument-field="statType" type="bar">
              <DxLabel :visible="true">
                <DxFormat :precision="2" type="fixedPoint" />
              </DxLabel>
            </DxCommonSeriesSettings>
            <DxSeries value-field="playerAvg" name="Zawodnik" />
            <DxSeries value-field="restOfTeamAvg" name="Reszta drużyny" />
          </DxChart>
        </div>
      </div>

      <div class="row mt-4">
        <div class="col-3">
          <h3 class="little-header">Rekordy w sezonie</h3>
          <div>
            <!-- rekordy w sezonie -->
            <div
              v-for="item in getPlayerRecords"
              v-bind:key="item.statType"
              class="stat-tile"
            >
              <span>{{ item.statType }}</span>
              <div class="avg">{{ Number(item.score.toFixed(2)) }}</div>
            </div>
          </div>
        </div>
        
        <div class="col-9">
          <h3 class="little-header">Mecze zawodnika</h3>
          <!-- grid mecze zawodnika -->
          <DxDataGrid
            id="gridContainer"
            :data-source="getAllPlayerGames"
            key-expr="opponent"
            :allow-column-reordering="true"
            :row-alternation-enabled="true"
            class="main-datagrid"
          >
            <DxColumn
              data-field="opponent"
              alignment="left"
              caption="Przeciwko"
              data-type="string"
            />
            <DxColumn
              data-field="gameTime"
              alignment="center"
              caption="Data"
              data-type="date"
            />
            <DxColumn
              data-field="points"
              alignment="center"
              caption="Punkty"
              data-type="number"
            />
            <DxColumn
              data-field="assists"
              alignment="center"
              caption="Asysty"
              data-type="number"
            />
            <DxColumn
              data-field="rebounds"
              alignment="center"
              caption="Zbiórki"
              data-type="number"
            />
            <DxColumn
              data-field="steals"
              alignment="center"
              caption="Przechwyty"
              data-type="number"
            />
            <DxColumn
              data-field="blocks"
              alignment="center"
              caption="Bloki"
              data-type="number"
            />
            <DxColumn
              data-field="fouls"
              alignment="center"
              caption="Faule"
              data-type="number"
            />
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
              <DxButton
                @click="function() {$router.push({name: 'games.details',params: { gameId: data.data.gameId },});}"
                hint="Szczegóły"
                title="Szczegóły"
                icon="fas fa-chevron-right"
                class="datagrid-button"
                type="normal"
              />
            </div>
          </DxDataGrid>
        </div>
      </div>

      <!-- <div class="row mt-4"> -->
        
      <!-- </div> -->
    </div>
    <div class="d-flex end-xs mt-5 mb-4">
      <DxButton
        :use-submit-behavior="false"
        type="normal"
        styling-mode="outlined"
        text="Wróć"
        @click="function() {$router.push({ name: 'team.index' });}"/>
    </div>
  </div>
</template>
<script>
import {
  DxChart,
  DxSeries,
  DxCommonSeriesSettings,
  DxLabel,
  DxFormat,
} from "devextreme-vue/chart";
import { DxDataGrid, DxColumn } from "devextreme-vue/data-grid";
import DxPieChart, {
  DxLegend,
  //DxSeries,
  //DxTooltip,
  //DxFormat,
  //DxLabel,
  DxConnector,
  DxExport,
} from "devextreme-vue/pie-chart";
import { DxButton } from "devextreme-vue";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamPlayerDetailsStore";
export default {
  data() {
    return {
      sources: [
        {
          value: "avg",
          name: "",
        },
      ],
    };
  },
  computed: {
    ...mapGetters(store, [
      "getDataToCharts",
      "getPlayerAvgs",
      "getPlayerRecords",
      "getAllPlayerGames",
      "getDataToSpiderWeb",
    ]),
    ...mapFields(store, [
      "detailsForm.FirstName",
      "detailsForm.LastName",
      "detailsForm.Avatar",
    ]),
  },
  methods: {
    ...mapActions(store, [
      "setDataToChart",
      "setPlayerAvgs",
      "setPlayerRecords",
      "setAllPlayerGames",
      "setDataToSpiderWeb",
    ]),
  },
  mounted() {
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
    //DxPolarChart,
    //DxExport,
    //DxTooltip,
    DxPieChart,
    DxConnector,
    DxLegend,
    DxButton,
  },
};
</script>
<style scoped>
.flexxin {
  display: flex;
}
.stat-tile {
  border: 1px solid #4d4d4d;
  border-radius: 5px;
  width: 110px;
  height: 100px;
  margin-right: 10px;
  text-align: center;
  padding-top: 20px;
  margin-top: 10px;
}
.stat-tile span {
  font-weight: 600;
  font-size: 20px;
}
.stat-tile .avg {
  font-size: 32px;
  color: #ff8000;
}
.player-tile{
  margin-top: 32px;
}
.player-tile img{
  border: 1px solid #4d4d4d;;
  border-radius: 5px;
}
.little-header{
  color: #4d4d4d;
}
#pie{
  width: 800px;
}
</style>
