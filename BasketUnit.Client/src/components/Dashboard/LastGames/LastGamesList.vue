<template>
  <div class="last-games-row">
    <div class="row-header">Ostatnie mecze</div>
    <div class="flexxin">
      <div v-for="item in games" v-bind:key="item.id">
        <LastGame :game="item" />
      </div>
    </div>
  </div>
</template>

<script>
import LastGame from "@/components/Dashboard/LastGames/LastGame";

export default {
  name: "lastGamesList",
  props: {
    games: {
      type: Array,
      required: true,
    },
  },
  components: { LastGame },
};
</script>

<style scoped>
.row-header {
  font-size: 24px;
  color: #4d4d4d;
  margin-bottom: 10px;
}
.last-games-row {
  background: rgb(245, 245, 245);
  border-radius: 10px;
  padding: 10px;
  margin-bottom: 50px;
  margin-top: 0px;
  width: 100%;
  margin-right: 10px;
  box-shadow: 2px 2px #cecece;
}
.flexxin {
  display: flex;
}
</style>
