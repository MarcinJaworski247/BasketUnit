<template>
  <router-link
    :to="{
      name: 'team.player.details',
      params: { playerId: player.id },
    }"
  >
    <div class="tile">
      <img
        v-if="player.avatar.length"
        style="width: 170px; max-height: 170px;"
        v-bind:src="'data:image/jpeg;base64,' + player.avatar"
      />
      <img
        v-else
        style="width: 80px;"
        v-bind:src="
          'https://cdn4.iconfinder.com/data/icons/small-n-flat/24/user-alt-512.png'
        "
      />
      <div class="player-name">{{ player.fullName }}</div>
      <div class="player-desc">
        {{ player.position }} | #{{ player.playerNumber }}
      </div>
    </div>
  </router-link>
</template>
<script>
export default {
  name: "playerTile",
  props: {
    player: {
      type: Object,
      required: true,
    },
  },
};
</script>
<style scoped>
.little-header {
  color: #4d4d4d;
}
.tile {
  border: 2px solid #4d4d4d;
  border-radius: 10px;
  height: 250px;
  width: 250px;
  margin-right: 10px;
  text-align: center;
  background: #fff;
  margin-top: 10px;
  margin-bottom: 10px;
  box-shadow: 2px 2px #cecece;
}
.tile:hover {
  border-color: #ff8000;
  text-decoration: none;
  box-shadow: 2px 2px #ffb368;
}
.player-name {
  font-size: 20px;
  color: #4d4d4d;
  border-top: 1px solid #4d4d4d;
  margin-top: 10px;
  line-height: 50px;
}

.player-desc {
  font-size: 18px;
  color: #4d4d4d;
}
</style>
