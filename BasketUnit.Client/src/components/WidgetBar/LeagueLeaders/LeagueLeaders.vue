<template>
  <div class="league-leaders-widget">
    <div class="league-leaders-header">Liderzy ligi</div>

    <LeagueLeader title="Punkty" :player="pointsLeader" />
    <LeagueLeader title="Asysty" :player="assistsLeader" />
    <LeagueLeader title="Zbiórki" :player="reboundsLeader" />
    <LeagueLeader title="Przechwyty" :player="stealsLeader" />
    <LeagueLeader title="Bloki" :player="blocksLeader" />
  </div>
</template>
<script>
import LeagueLeader from "@/components/WidgetBar/LeagueLeaders/LeagueLeader";

export default {
  name: "leagueLeaders",
  props: {
    pointsLeader: {
      type: Object,
      required: true,
    },
    assistsLeader: {
      type: Object,
      required: true,
    },
    reboundsLeader: {
      type: Object,
      required: true,
    },
    stealsLeader: {
      type: Object,
      required: true,
    },
    blocksLeader: {
      type: Object,
      required: true,
    },
  },
  components: {
    LeagueLeader,
  },
};
</script>
<style scoped>
.league-leaders-widget {
  border: 3px solid #ff8000;
  border-radius: 5px;
  width: 250px;
  margin: auto;
  padding: 10px;
  margin-top: 40px;
  background: #fff;
  box-shadow: 2px 2px #ffb368;
}
.league-leaders-header {
  font-size: 18px;
  color: #4d4d4d;
  font-weight: 600;
  border-bottom: 1px solid #ff8000;
  margin-bottom: 10px;
}
</style>
