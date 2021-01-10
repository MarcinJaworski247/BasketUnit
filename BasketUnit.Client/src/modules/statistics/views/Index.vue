<template>
  <div class="content">
    <div class="main-header">
      <h3 class="main-header-title">Statystyki drużyny</h3>
    </div>
    <div class="printers">
      <div class="mt-4">
        <div class="centered-div">
          <!-- herb, nazwa druzyny -->
          <img
            v-if="badge.length"
            style="width: 150px;"
            v-bind:src="'data:image/jpeg;base64,' + badge"
          />
        </div>
        
          <h3 class="centered-div mb-4">{{ name }}</h3>
      </div>
      <!-- wykres słupkowy - średnie punkty, asysty itd. -->
      <div class="row">
        <div class="col-6">
          <DxChart
            :data-source="getTeamAverages"
            title="Średnie statystyki  zespołu"
            palette="Harmony Light"
          >
            <DxCommonSeriesSettings argument-field="statType" type="bar">
              <DxLabel :visible="true">
                <DxFormat :precision="2" type="fixedPoint" />
              </DxLabel>
            </DxCommonSeriesSettings>
            <DxSeries value-field="avg" name=" " />
          </DxChart>
        </div>
        <div class="col-6">
        <!-- wykres spline - zdobyte i stracone punkty na przestrzeni meczów -->
        <DxChart
          :data-source="getTeamScoreAndLosePoints"
          palette="Harmony Light"
          title="Punkty zdobyte i stracone na przestrzeni meczów"
          class="mt-4"
        >
          <DxCommonSeriesSettings type="spline" argument-field="opponentName" />
          <DxCommonAxisSettings>
            <DxGrid :visible="true" />
          </DxCommonAxisSettings>
          <DxSeries
            v-for="item in sources"
            :key="item.value"
            :value-field="item.value"
            :name="item.name"
          />
          <DxMargin :bottom="20" />
          <DxArgumentAxis :allow-decimals="false" :axis-division-factor="60">
            <DxLabel>
              <DxFormat type="decimal" />
            </DxLabel>
          </DxArgumentAxis>
          <DxLegend vertical-alignment="top" horizontal-alignment="right" />
          <DxTooltip :enabled="true" />
        </DxChart>
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <div class="future-games-row">
              <div class="row-header">Przewidywania nadchodzących meczów</div>
              <div class="flexxin">
                  <!-- <div v-for="item in getFutureGames" v-bind:key="item.id" v-bind:class="{futuregamelose : !item.predictionResult, futuregamewin : item.predictionResult}"> -->
                  <div v-for="item in getFutureGames" v-bind:key="item.id" class="future-game">
                      <img style="width: 70px;  max-height: 70px;" v-bind:src="'data:image/jpeg;base64,' + item.badge"/>
                      <div class="future-game-desc">{{ item.date | formatDate }}</div>
                      <div class="future-game-desc">{{ item.arena }}</div>
                      <div class="future-game-desc" style="font-weight: 600; font-size: 18px; margin-top: 25px;">Szanse na wygraną: {{ item.predictionResult.toFixed(2) }}
                        <div v-if="item.predictionResult < 0.5" style="color: red;">P</div>
                        <div v-else style="color: green;">W</div>

                      </div>
                      <!-- <div v-if="item.predictionResult" class="future-game-desc">Zwycięstwo</div>
                      <div v-else class="future-game-desc">Porażka</div> -->
                  </div>
              </div>
          </div>
        </div>
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
  DxFormat,
  DxArgumentAxis,
  DxCommonAxisSettings,
  DxGrid,
  DxLegend,
  DxMargin,
  DxTooltip,
} from "devextreme-vue/chart";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";

const store = "StatisticsStore";

export default {
  name: "statistics",
  data() {
    return {
      sources: [
        {
          value: "teamScore",
          name: "Punkty zdobyte",
        },
        {
          value: "opponentScore",
          name: "Punkty stracone",
        },
      ],
    };
  },
  computed: {
    ...mapGetters(store, [
      "getTeamForm",
      "getTeamAverages",
      "getTeamScoreAndLosePoints",
      "getFutureGames"
    ]),
    ...mapFields(store, ["teamForm.name", "teamForm.badge"]),
  },
  methods: {
    ...mapActions(store, [
      "setTeamForm",
      "setTeamAverages",
      "setTeamScoreAndLosePoints",
      "setFutureGames"
    ]),
  },
  mounted() {
    this.setTeamForm();
    this.setTeamAverages();
    this.setTeamScoreAndLosePoints();
    this.setFutureGames();
  },
  components: {
    DxChart,
    DxSeries,
    DxCommonSeriesSettings,
    DxLabel,
    DxFormat,
    DxArgumentAxis,
    DxCommonAxisSettings,
    DxGrid,
    DxLegend,
    DxMargin,
    DxTooltip,
  },
};
</script>
<style scoped>
.main-header-title{
  color: #4d4d4d;;
  font-size: 32px;
}
.centered-div{
  justify-content: center;
  display: flex;
}
.future-game-desc{
    font-weight: 400;
    font-size: 14px;
}
.flexxin{
    display: flex;
}
.future-games-row{
    background: rgb(245, 245, 245);
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 50px;
    width: 100%;
    /* display: flex; */
    box-shadow: 2px 2px #cecece;
}
.futuregamewin{
    border: 3px solid green;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    padding-top: 10px;
    box-shadow: 2px 2px green;
}
.futuregamelose{
    border: 3px solid red;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    padding-top: 10px;
    box-shadow: 2px 2px red;
}
.future-game{
    border: 3px solid black;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 225px;
    width: 225px;
    padding-top: 10px;
    box-shadow: 2px 2px black;
}
.row-header{
    font-size: 24px;
    color: #4d4d4d;
    margin-bottom: 10px;
}
</style>
