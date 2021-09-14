<template>
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
</template>
<script>
import { mapGetters, mapActions } from "vuex";

// DevExtreme
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

// store
const STORE = "StatisticsStore";

export default {
  name: "pointsLinearChart",
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
    ...mapGetters(STORE, ["getTeamScoreAndLosePoints"]),
  },
  methods: {
    ...mapActions(STORE, ["setTeamScoreAndLosePoints"]),
  },
  mounted() {
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
