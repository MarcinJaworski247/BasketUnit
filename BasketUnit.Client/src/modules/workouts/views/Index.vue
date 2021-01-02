<template>
  <div class="content">
    <div class="main-header">
      <h3 class="main-header-title">Treningi</h3>
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
          <WorkoutTypesTab />
        </div>
      </template>
      <template slot="tab2">
        <div class="container">
          <ExcercisesTab />
        </div>
      </template>
    </DxTabPanel>
  </div>
</template>

<script>
import { DxTabPanel } from "devextreme-vue";
import WorkoutTypesTab from "./WorkoutTypes/Index";
import ExcercisesTab from "./Excercises/Index";
export default {
  name: "workouts",
  data() {
    return {
      tabs: [
        {
          title: "Rodzaje treningów",
          icon: "fas fa-dumbbell",
          template: "tab1",
        },
        {
          title: "Ćwiczenia",
          icon: "fas fa-running",
          template: "tab2",
        },
      ],
    };
  },
  components: {
    DxTabPanel,
    WorkoutTypesTab,
    ExcercisesTab,
  },
};
</script>
<style scoped>
.main-header-title{
  color: rgb(31, 31, 131);
  font-size: 32px;
}
</style>