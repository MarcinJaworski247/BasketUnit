<template>
  <div class="future-game">
    <img
      style="width: 70px;  max-height: 70px;"
      v-bind:src="'data:image/jpeg;base64,' + game.badge"
    />
    <div class="future-game-desc">{{ game.date | formatDate }}</div>
    <div class="future-game-desc">{{ game.arena }}</div>
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
.future-game {
  border: 3px solid #ff8000;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  padding-top: 10px;
  box-shadow: 2px 2px #ffb368;
}
.future-game-desc {
  font-weight: 400;
  font-size: 14px;
}
</style>
