<template>
  <div v-bind:class="{ loseTile: !game.isWin, winTile: game.isWin }">
    <img
      style="width: 80px; max-height: 80px;"
      v-bind:src="'data:image/jpeg;base64,' + game.badge"
    />
    <div class="score">{{ game.score }}</div>
  </div>
</template>

<script>
export default {
  name: "lastGame",
  props: {
    game: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style scoped>
.winTile {
  border: 3px solid green;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  padding-top: 10px;
  box-shadow: 2px 2px rgb(0, 160, 0);
}
.loseTile {
  border: 3px solid red;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  padding-top: 10px;
  box-shadow: 2px 2px rgb(255, 92, 92);
}
.score {
  font-weight: 600;
  font-size: 24px;
}
</style>
