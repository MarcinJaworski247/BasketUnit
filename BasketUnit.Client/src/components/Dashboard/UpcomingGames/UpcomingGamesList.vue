<template>
  <div class="future-games-row">
    <div class="row-header">Nadchodzące mecze</div>
    <div class="flexxin">
      <div v-for="item in games" v-bind:key="item.id">
        <UpcomingGame :game="item" />
      </div>
    </div>
  </div>
</template>

<script>
import UpcomingGame from "@/components/Dashboard/UpcomingGames/UpcomingGame";

export default {
  name: "upcomingGamesList",
  props: {
    games: {
      type: Array,
      required: true,
    },
  },
  components: {
    UpcomingGame,
  },
};
</script>

<style scoped>
.future-games-row {
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
