<template>
  <div class="future-workouts-row">
    <div class="row-header">Nadchodzące treningi</div>
    <div class="flexxin">
      <div v-for="item in practices" v-bind:key="item.date">
        <UpcomingPractice :practice="item" />
      </div>
    </div>
  </div>
</template>
<script>
import UpcomingPractice from "@/components/Dashboard/UpcomingPractices/UpcomingPractice";

export default {
  name: "upcomingPracticesList",
  props: {
    practices: {
      type: Array,
      required: true,
    },
  },
  components: {
    UpcomingPractice,
  },
};
</script>
<style scoped>
.future-workouts-row {
  background: rgb(245, 245, 245);
  border-radius: 10px;
  padding: 10px;
  margin-bottom: 50px;
  width: 100%;
  /* display: flex; */
  box-shadow: 2px 2px #cecece;
}
.row-header {
  font-size: 24px;
  color: #4d4d4d;
  margin-bottom: 10px;
}
.flexxin {
  display: flex;
}
</style>
