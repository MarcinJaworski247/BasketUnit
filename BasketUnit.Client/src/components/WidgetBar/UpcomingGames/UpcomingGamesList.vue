<template>
  <div class="future-games-widget">
    <div class="future-games-header">Nadchodzące mecze</div>
    <div v-for="item in games" :key="item.startDate" class="future-games-item">
      <UpcomingGame :game="item" />
    </div>
  </div>
</template>

<script>
import UpcomingGame from "@/components/WidgetBar/UpcomingGames/UpcomingGame";

export default {
  name: "upcomingGamesList",
  props: {
    games: {
      type: Array,
      required: false,
    },
  },
  components: {
    UpcomingGame,
  },
};
</script>

<style scoped>
.future-games-widget {
  border: 3px solid #ff8000;
  border-radius: 5px;
  width: 250px;
  margin: auto;
  padding: 10px;
  background: #fff;
  box-shadow: 2px 2px #ffb368;
}

.future-games-header {
  font-size: 18px;
  color: #4d4d4d;
  font-weight: 600;
  border-bottom: 1px solid #ff8000;
  margin-bottom: 10px;
}

.future-games-item {
  border-bottom: 1px solid #ff8000;
  margin-bottom: 10px;
}
</style>
