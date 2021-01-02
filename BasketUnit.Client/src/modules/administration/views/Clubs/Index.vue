<template>
  <div class="content">
    <div class="printers">
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
            <TeamsTab />
          </div>
        </template>
        <template slot="tab2">
          <div class="container">
            <ArenasTab />
          </div>
        </template>
        <template slot="tab3">
          <div class="container">
            <CollegesTab />
          </div>
        </template>
      </DxTabPanel>
    </div>
  </div>
</template>

<script>
import { DxTabPanel } from "devextreme-vue";
import TeamsTab from "./Teams/Index";
import ArenasTab from "./Arenas/Index";
import CollegesTab from "./Colleges/Index";
export default {
  name: "clubs",
  data() {
    return {
      tabs: [
        {
          title: "Drużyny",
          icon: "fas fa-basketball-ball",
          template: "tab1",
        },
        {
          title: "Areny",
          icon: "fas fa-warehouse",
          template: "tab2",
        },
        {
          title: "Uniwersytety",
          icon: "fas fa-basketball-ball",
          template: "tab3",
        },
      ],
    };
  },
  components: {
    TeamsTab,
    ArenasTab,
    CollegesTab,
    DxTabPanel,
  },
};
</script>
<style scoped>
.main-header-title{
  color: rgb(31, 31, 131);
  font-size: 32px;
}
</style>