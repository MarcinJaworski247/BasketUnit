<template>
  <div class="league-leaders-item">
    <div class="stat-header">
      <strong>{{ title }}</strong>
    </div>
    <div class="stat-player-name">{{ player.fullName }}, {{ player.team }}</div>
    <div class="stat-avg">{{ player.avg }}</div>
  </div>
</template>
<script>
export default {
  props: {
    title: {
      type: String,
      required: false,
      default: "",
    },
    player: {
      type: Object,
      required: true,
    },
  },
};
</script>
<style scoped>
.league-leaders-item {
  border-bottom: 1px solid #ff8000;
  margin-bottom: 4px;
}
.stat-header {
  font-size: 16px;
}
.stat-player-name {
  font-size: 16px;
}
.stat-avg {
  font-size: 16px;
  color: #4d4d4d;
}
</style>
