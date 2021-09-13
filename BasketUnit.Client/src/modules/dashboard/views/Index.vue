<template>
  <div class="content">
    <div style="display: flex;">
      <LastGamesList :games="getLastGames" />
      <UpcomingGamesList :games="getFutureGames" />
    </div>

    <div style="display: flex;">
      <InjuriesList :injuredPlayers="getInjuredPlayers" />
      <UpcomingPracticesList :practices="getFutureWorkouts" />
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

// store
const STORE = "DashboardStore";

// components
import LastGamesList from "@/components/Dashboard/LastGames/LastGamesList";
import UpcomingGamesList from "@/components/Dashboard/UpcomingGames/UpcomingGamesList";
import InjuriesList from "@/components/Dashboard/Injuries/InjuriesList";
import UpcomingPracticesList from "@/components/Dashboard/UpcomingPractices/UpcomingPracticesList";

export default {
  name: "dashboard",
  computed: {
    ...mapGetters(STORE, [
      "getLastGames",
      "getFutureGames",
      "getInjuredPlayers",
      "getFutureWorkouts",
    ]),
  },
  methods: {
    ...mapActions(STORE, [
      "setLastGames",
      "setFutureGames",
      "setInjuredPlayers",
      "setFutureWorkouts",
    ]),
  },
  created() {
    this.setLastGames();
    this.setFutureGames();
    this.setInjuredPlayers();
    this.setFutureWorkouts();
  },
  components: {
    LastGamesList,
    UpcomingGamesList,
    InjuriesList,
    UpcomingPracticesList,
  },
};
</script>
