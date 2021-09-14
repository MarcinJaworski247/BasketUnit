<template>
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
</template>
<script>
import {
  DxChart,
  DxSeries,
  DxCommonSeriesSettings,
  DxLabel,
  DxFormat,
} from "devextreme-vue/chart";
import { mapGetters, mapActions } from "vuex";

const store = "StatisticsStore";

export default {
  name: "teamAveragesBarChart",
  computed: {
    ...mapGetters(store, ["getTeamAverages"]),
  },
  methods: {
    ...mapActions(store, ["setTeamAverages"]),
  },
  mounted() {
    this.setTeamAverages();
  },
  components: {
    DxChart,
    DxSeries,
    DxCommonSeriesSettings,
    DxLabel,
    DxFormat,
  },
};
</script>
