<template>
  <div style="display: flex">
    <div
      v-for="item in getFutureGames"
      v-bind:key="item.id"
      class="future-game"
    >
      <img
        style="width: 70px;  max-height: 70px;"
        v-bind:src="'data:image/jpeg;base64,' + item.badge"
      />
      <div class="future-game-desc">{{ item.date | formatDate }}</div>
      <div class="future-game-desc">{{ item.arena }}</div>
      <div
        class="future-game-desc"
        style="font-weight: 600; font-size: 18px; margin-top: 25px;"
      >
        Szanse na wygraną: {{ item.predictionResult.toFixed(2) }}
        <div v-if="item.predictionResult < 0.5" style="color: red;">
          P
        </div>
        <div v-else style="color: green;">W</div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";

const STORE = "StatisticsStore";

export default {
  name: "upcomingGamesPredictions",
  computed: {
    ...mapGetters(STORE, ["getFutureGames"]),
  },
  methods: {
    ...mapActions(STORE, ["setFutureGames"]),
  },
  mounted() {
    this.setFutureGames();
  },
};
</script>
<style scoped>
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
}
.centered-div {
  justify-content: center;
  display: flex;
}
.future-game-desc {
  font-weight: 400;
  font-size: 14px;
}
.flexxin {
  display: flex;
}
.future-games-row {
  background: rgb(245, 245, 245);
  border-radius: 10px;
  padding: 10px;
  margin-bottom: 50px;
  width: 100%;
  /* display: flex; */
  box-shadow: 2px 2px #cecece;
}
.futuregamewin {
  border: 3px solid green;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  padding-top: 10px;
  box-shadow: 2px 2px green;
}
.futuregamelose {
  border: 3px solid red;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  padding-top: 10px;
  box-shadow: 2px 2px red;
}
.future-game {
  border: 3px solid black;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 225px;
  width: 225px;
  padding-top: 10px;
  box-shadow: 2px 2px black;
}
.row-header {
  font-size: 24px;
  color: #4d4d4d;
  margin-bottom: 10px;
}
</style>
