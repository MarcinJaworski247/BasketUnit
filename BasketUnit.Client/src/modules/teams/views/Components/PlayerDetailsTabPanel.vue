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
import { DxTabPanel } from "devextreme-vue";
import BioTab from "./PlayerBioTab";
import StatsTab from "./PlayerStatsTab";
export default {
  name: "administration",
  data() {
    return {
      tabs: [
        {
          title: "Bio",
          icon: "fas fa-users",
          template: "tab1",
        },
        {
          title: "Statystyki",
          icon: "fas fa-users",
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
.main-header-title{
  color: rgb(31, 31, 131);
  font-size: 32px;
}
</style>