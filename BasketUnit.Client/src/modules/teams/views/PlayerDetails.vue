<template>
  <div class="content">
    <div class="printers">
      <div class="main-header">
        <h3 class="main-header-title">Karta zawodnika</h3>
      </div>
      <DxTabPanel
        :animation-enabled="true"
        :swipe-enabled="false"
        :items="tabs"
      >
        <template #title="{ data: tabs }">
          <span>
            <i :class="tabs.icon"></i>
            {{ tabs.title }}
          </span>
        </template>
        <template slot="tab1">
          <div class="container">
            <BioTab />
          </div>
        </template>
        <template slot="tab2">
          <div class="container">
            <StatsTab />
          </div>
        </template>
      </DxTabPanel>
    </div>
  </div>
</template>
<script>
// DevExtreme
import { DxTabPanel } from "devextreme-vue";

// components
import BioTab from "../components/Bio/PlayerBioTab";
import StatsTab from "../components/Stats/PlayerStatsTab";

export default {
  name: "playerDetails",
  data() {
    return {
      tabs: [
        {
          title: "Bio",
          icon: "fas fa-user-alt",
          template: "tab1",
        },
        {
          title: "Statystyki",
          icon: "fas fa-chart-pie",
          template: "tab2",
        },
      ],
    };
  },
  components: {
    DxTabPanel,
    BioTab,
    StatsTab,
  },
};
</script>
<style scoped>
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
}
</style>
