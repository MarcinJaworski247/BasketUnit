<template>
  <div>
    <div class="future-games-teams">
      {{ game.homeTeam }} vs. {{ game.awayTeam }}
    </div>
    <div class="future-games-desc">
      Arena: <strong>{{ game.arena }}</strong>
    </div>
    <div class="future-games-desc">
      Data: <strong>{{ game.startDate | formatDate }}</strong>
    </div>
  </div>
</template>

<script>
export default {
  name: "upcomingGame",
  props: {
    game: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style scoped>
.future-games-teams {
  font-size: 16px;
  margin-bottom: 4px;
}
.future-games-desc {
  font-size: 14px;
}
</style>
