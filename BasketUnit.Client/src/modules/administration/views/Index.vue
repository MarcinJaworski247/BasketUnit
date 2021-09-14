<template>
  <div class="content">
    <div class="printers">
      <div class="main-header">
        <h3 class="main-header-title">Administracja</h3>
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
            <HumanResourcesTab />
          </div>
        </template>
        <template slot="tab2">
          <div class="container">
            <ClubsTab />
          </div>
        </template>
      </DxTabPanel>
    </div>
  </div>
</template>

<script>
import { DxTabPanel } from "devextreme-vue";
import HumanResourcesTab from "./HumanResources/Index";
import ClubsTab from "./Clubs/Index";
export default {
  name: "administration",
  data() {
    return {
      tabs: [
        {
          title: "Zasoby ludzkie",
          icon: "fas fa-users",
          template: "tab1",
        },
        {
          title: "Kluby",
          icon: "fas fa-basketball-ball",
          template: "tab2",
        },
      ],
    };
  },
  components: {
    DxTabPanel,
    HumanResourcesTab,
    ClubsTab,
  },
};
</script>
<style scoped>
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
}
</style>
