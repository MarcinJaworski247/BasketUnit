<template>
  <div class="content">
    <div class="printers">
      <div class="main-header">
        <h3 class="main-header-title">Skład</h3>
      </div>
      <div class="flexxin">
        <div v-for="player in getPlayersList" v-bind:key="player.id">
          <router-link
            class="datagrid-btn"
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
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamStore";

export default {
  name: "lineup",
  computed: {
    ...mapGetters(store, [
      "getPlayersList",
      "getPositionsToLookup",
      "getNationalities",
    ]),
  },
  methods: {
    ...mapActions(store, [
      "setPlayersList",
      "setDetails",
      "setPositionsToLookup",
      "setNationalities",
    ]),
  },
  mounted() {
    this.setPlayersList();
    this.setNationalities();
    this.setPositionsToLookup();
  },
};
</script>

<style scoped>
.tile {
  border: 2px solid rgb(31, 31, 131);
  border-radius: 10px;
  height: 250px;
  width: 250px;
  margin-right: 10px;
  text-align: center;
  background: #fff;
  margin-top: 10px;
}
.flexxin {
  display: flex;
  flex-wrap: wrap;
}
.player-name {
  font-size: 20px;
  color: rgb(31, 31, 131);
}
.player-desc {
  font-size: 18px;
  color: rgb(31, 31, 131);
}
.main-header-title {
  color: rgb(31, 31, 131);
  font-size: 32px;
}
</style>
