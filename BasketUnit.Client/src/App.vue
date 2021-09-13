<template>
  <div id="app">
    <div class="wrapper">
      <div class="sidebar">
        <!-- SideNav header -->
        <router-link :to="{ name: 'dashboard' }">
          <div class="sidebar-header">
            <i class="fas fa-basketball-ball mr-1 logo"></i>
            <div>
              <h5>BASKET UNIT</h5>
            </div>
          </div>
        </router-link>

        <!-- Left NavBar -->
        <NavBar />
      </div>

      <!-- Content -->
      <div class="main-content">
        <router-view />
      </div>

      <!-- WidgetBar -->
      <div class="widgets-bar">
        <UpcomingGamesList :games="getClosestGames" />

        <LeagueLeaders
          :pointsLeader="pointsLeader"
          :assistsLeader="assistsLeader"
          :reboundsLeader="reboundsLeader"
          :stealsLeader="stealsLeader"
          :blocksLeader="blocksLeader"
        />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

// components
import UpcomingGamesList from "@/components/WidgetBar/UpcomingGames/UpcomingGamesList";
import NavBar from "@/components/NavBar/NavBar";
import LeagueLeaders from "@/components/WidgetBar/LeagueLeaders/LeagueLeaders";

export default {
  name: "App",
  data() {
    return {
      pointsLeader: {
        fullName: "Kevin Durant",
        team: "Nets",
        avg: 31.1,
      },
      assistsLeader: {
        fullName: "Ben Simmons",
        team: "Lakers",
        avg: 11.2,
      },
      reboundsLeader: {
        fullName: "Zion Williamson",
        team: "Pelicans",
        avg: 12.4,
      },
      stealsLeader: {
        fullName: "LeBron James",
        team: "Pelicans",
        avg: 2.6,
      },
      blocksLeader: {
        fullName: "Anthony Davis",
        team: "Lakers",
        avg: 2.4,
      },
    };
  },
  computed: {
    ...mapGetters(["getClosestGames"]),
  },
  methods: {
    ...mapActions(["setClosestGames"]),
  },
  created() {
    this.setClosestGames();
  },
  components: {
    UpcomingGamesList,
    NavBar,
    LeagueLeaders,
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  list-style: none;
  text-decoration: none;
}
body {
  background: rgb(238, 238, 238);
}
.wrapper {
  display: flex;
  position: relative;
}
.wrapper .sidebar {
  position: fixed;
  width: 200px;
  height: 100%;
  background: rgb(245, 245, 245);
  padding: 30px 0;
  text-decoration: none;
  margin-left: 10px;
  margin-top: 10px;
  border-top-right-radius: 15px;
  border-top-left-radius: 15px;
}
.wrapper .sidebar h5 {
  color: #ff8000;
  text-align: center;
  margin-bottom: 30px;
  margin-top: 20px;
}
.wrapper .sidebar h5 a:hover {
  text-decoration: none;
}
.wrapper .sidebar .sidebar-header:hover {
  text-decoration: none;
}
.wrapper .main-content {
  width: 100%;
  margin-left: 200px;
  margin-right: 300px;
  /* background: rgb(238, 238, 238); */
  /* display: flex; */
  height: 100%;
  padding-left: 100px;
  padding-top: 50px;
  padding-right: 100px;
  padding-bottom: 50px;
}
.wrapper .widgets-bar {
  width: 300px;
  position: fixed;
  right: 0;
  padding: 30px 0;
  background: rgb(245, 245, 245);
  height: 100%;
  margin-left: 10px;
  margin-top: 10px;
  border-top-right-radius: 15px;
  border-top-left-radius: 15px;
}
.wrapper .sidebar .sidebar-header {
  text-align: center;
  border-bottom: 1px solid #4d4d4d;
  margin-bottom: 38px;
}
.wrapper .sidebar .logo {
  font-size: 82px;
  color: #ff8000;
}
</style>
