<template>
  <div class="content">
    <div class="main-header">
      <h3 class="main-header-title">Statystyki drużyny</h3>
    </div>
    <div class="printers">
      <div class="mt-4">
        <TeamInfo />
      </div>
      <div class="row">
        <div class="col-6">
          <TeamAveragesBarChart />
        </div>
        <div class="col-6">
          <PointsLinearChart />
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <div class="future-games-row">
            <div class="row-header">Przewidywania nadchodzących meczów</div>
            <div>
              <UpcomingGamesPrecitions />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import TeamAveragesBarChart from "../components/TeamAveragesBarChart.vue";
import PointsLinearChart from "../components/PointsLinearChart.vue";
import UpcomingGamesPrecitions from "../components/UpcomingGamesPredictions.vue";
import TeamInfo from "../components/TeamInfo.vue";

export default {
  name: "statistics",
  components: {
    TeamAveragesBarChart,
    PointsLinearChart,
    UpcomingGamesPrecitions,
    TeamInfo,
  },
};
</script>
<style scoped>
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
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
