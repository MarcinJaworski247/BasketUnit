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
    ]),
    ...mapFields(store, ["teamForm.name", "teamForm.badge"]),
  },
  methods: {
    ...mapActions(store, [
      "setTeamForm",
      "setTeamAverages",
      "setTeamScoreAndLosePoints",
    ]),
  },
  mounted() {
    this.setTeamForm();
    this.setTeamAverages();
    this.setTeamScoreAndLosePoints();
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
</style>
