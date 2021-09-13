<template>
  <div class="injured-player">
    <img
      style="width: 80px;  max-height: 80px;"
      v-bind:src="'data:image/jpeg;base64,' + injuredPlayer.avatar"
    />
    <div class="player-name">{{ injuredPlayer.fullName }}</div>
    <div class="player-injury">{{ injuredPlayer.injury }}</div>
  </div>
</template>

<script>
export default {
  name: "injury",
  props: {
    injuredPlayer: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style scoped>
.injured-player {
  border: 3px solid #ff8000;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  box-shadow: 2px 2px #ffb368;
}
.player-name {
  font-weight: 600;
  font-size: 20px;
}
.player-injury {
  font-weight: 400;
  font-size: 16px;
}
</style>
