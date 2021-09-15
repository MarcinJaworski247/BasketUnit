<template>
  <div class="content">
    <div class="printers">
      <div class="main-header">
        <h3 class="main-header-title">Skład</h3>
      </div>
      <div class="flexxin">
        <div v-for="player in getPlayersList" v-bind:key="player.id">
          <PlayerTile :player="player" />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";

// store
const STORE = "TeamStore";

// components
import PlayerTile from "../components/PlayerTile";

export default {
  name: "lineup",
  computed: {
    ...mapGetters(STORE, ["getPlayersList"]),
  },
  methods: {
    ...mapActions(STORE, ["setPlayersList"]),
  },
  mounted() {
    this.setPlayersList();
  },
  components: {
    PlayerTile,
  },
};
</script>

<style scoped>
.flexxin {
  display: flex;
  flex-wrap: wrap;
}
.player-name {
  font-size: 20px;
  color: #4d4d4d;
  border-top: 1px solid #4d4d4d;
  margin-top: 10px;
  line-height: 50px;
}
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
}
</style>
