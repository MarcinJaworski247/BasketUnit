<template>
  <div id="app">
    <div class="wrapper">
      <div class="sidebar">
        <div>
          <router-link :to="{ name: 'dashboard' }">
            <div class="sidebar-header">
              <i
                class="fas fa-basketball-ball mr-1 logo"
              ></i>
              <div>
                <h5>BASKET UNIT</h5>
              </div>
            </div>
          </router-link>
        </div>

        <!-- left nav bar -->
        <ul>
          <li>
            <router-link :to="{ name: 'team.lineup.index' }">
              <span>
                <i class="fas fa-users mr-1"></i>
                Skład
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'team.firstLineup.index' }">
              <span>
                <i class="fas fa-user-friends mr-1"></i>
                Pierwsza piątka
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'statistics.index' }">
              <span>
                <i class="far fa-chart-bar mr-1"></i>
                Statystyki
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'schedules.index' }">
              <span>
                <i class="fas fa-calendar-alt mr-1"></i>
                Kalendarz
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'workouts.index' }">
              <span>
                <i class="fas fa-dumbbell mr-1"></i>
                Treningi
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'games.index' }">
              <span>
                <i class="fas fa-basketball-ball mr-1"></i>
                Mecze
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'protocols.index' }">
              <span>
                <i class="fas fa-file-alt mr-1"></i>
                Protokoły
              </span>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'administration.index' }">
              <span>
                <i class="fas fa-cog mr-1"></i>
                Administracja
              </span>
            </router-link>
          </li>
        </ul>

        <!-- <div class="sidebar-footer">
          <i class="fab fa-facebook-f"></i>
          <i class="fab fa-facebook-f"></i>
          <i class="fab fa-facebook-f"></i>
        </div> -->

      </div>

      <!-- content -->
      <div class="main-content">
        
          <router-view />
        
      </div>

      <!-- widgets -->
      <div class="widgets-bar">
        <div class="future-games-widget">
          <div class="future-games-header">Nadchodzące mecze</div>
          <div v-for="item in getClosestGames" :key="item.startDate" class="future-games-item">
            <div class="future-games-teams">{{ item.homeTeam }} vs. {{ item.awayTeam }}</div>
            <div class="future-games-desc">Arena: <strong>{{ item.arena }}</strong></div>
            <div class="future-games-desc">Data: <strong>{{ item.startDate }}</strong></div>
          </div>
        </div>

        <div class="league-leaders-widget">
          <div class="league-leaders-header">Liderzy ligi</div>
          <div class="league-leaders-item">
            <div class="stat-header"><strong>Punkty</strong></div>
            <div class="stat-player-name">Kevin Durant, Nets</div>
            <div class="stat-avg">31.1</div>
          </div>
          <div class="league-leaders-item">
            <div class="stat-header"><strong>Asysty</strong></div>
            <div class="stat-player-name">Ben Simmons, 76ers</div>
            <div class="stat-avg">11.2</div>
          </div>
          <div class="league-leaders-item">
            <div class="stat-header"><strong>Zbiórki</strong></div>
            <div class="stat-player-name">Zion Williamson, Pelicans</div>
            <div class="stat-avg">12.4</div>
          </div>
          <div class="league-leaders-item">
            <div class="stat-header"><strong>Przechwyty</strong></div>
            <div class="stat-player-name">LeBron James, Lakers</div>
            <div class="stat-avg">3.6</div>
          </div>
          <div class="league-leaders-item">
            <div class="stat-header"><strong>Bloki</strong></div>
            <div class="stat-player-name">Anthony Davis, Lakers</div>
            <div class="stat-avg">2.4</div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapMutations } from "vuex";

export default {
  name: "App",
  computed: {
    ...mapGetters(["getLeaugueLeaders", "getClosestGames"]),
  },
  methods: {
    ...mapActions(["setLeagueaLeaders", "setClosestGames"]),
  },
  created() {
    //this.setLeagueaLeaders();
    this.setClosestGames();
  },
};
</script>

<style scoped>
*{
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  list-style: none;
  text-decoration: none;
}

body{
  background: rgb(238, 238, 238);
}

.wrapper{
  display: flex;
  position: relative;
}
.wrapper .sidebar{
  position: fixed;
  width: 200px;
  height: 100%;
  background: rgb(233, 233, 233);
  padding: 30px 0;
  text-decoration: none;
}

.wrapper .sidebar h5{
  color: rgb(31, 31, 131);
  text-align: center;
  margin-bottom: 30px;
  margin-top: 20px;
}

.wrapper .sidebar ul li{
  padding: 15px;
  font-size: 20px;
}

.wrapper .sidebar ul li a{
  color: rgb(31, 31, 131);
  display: block; 
}

.wrapper .sidebar ul li a .far .fas{
  width: 35px;
}

.wrapper .sidebar .far .fas{
  width: 4px;
}

.wrapper .sidebar ul li:hover{
  background: rgb(247, 248, 248);
  color: rgb(31, 31, 131);
  border-top-right-radius: 10px;
  border-bottom-right-radius: 10px;
}

.wrapper .sidebar ul li:hover a{
  color: rgb(31, 31, 131);
  text-decoration: none;
}

.wrapper .sidebar .sidebar-header:hover{
  text-decoration: none;
}

.wrapper .sidebar .sidebar-footer{
  position: absolute;
  bottom: 10px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
}

.wrapper .main-content{
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

.wrapper .widgets-bar{
  width: 300px;
  position: fixed;
  right: 0;
  padding: 30px 0;
  background: rgb(233, 233, 233);
  height: 100%;
}

.wrapper .sidebar .sidebar-header{
  text-align: center;
  border-bottom: 1px solid rgb(31, 31, 131);
  margin-bottom: 38px;
}

.wrapper .sidebar .logo{
  font-size: 82px;
  color: rgb(31, 31, 131);
}

.future-games-widget{
  border: 3px solid rgb(31, 31, 131);
  border-radius: 5px;
  width: 250px;
  margin: auto;
  padding: 10px;
  background: #fff;
}

.future-games-header{
  font-size: 18px;
  color: rgb(31, 31, 131);
  font-weight: 600;
  border-bottom: 1px solid rgb(31, 31, 131);
  margin-bottom: 10px;
}

.future-games-item{
  border-bottom: 1px solid rgb(31, 31, 131);
  margin-bottom: 10px;
}

.league-leaders-widget{
  border: 3px solid rgb(31, 31, 131);
  border-radius: 5px;
  width: 250px;
  margin: auto;
  padding: 10px;
  margin-top: 40px;
  background: #fff;
}

.league-leaders-header{
  font-size: 18px;
  color: rgb(31, 31, 131);
  font-weight: 600;
  border-bottom: 1px solid rgb(31, 31, 131);
  margin-bottom: 10px;
}

.league-leaders-item{
  border-bottom: 1px solid rgb(31, 31, 131);
  margin-bottom: 4px;
}
.future-games-teams{
  font-size: 16px;
  margin-bottom: 4px;
}
.future-games-desc{
  font-size: 14px;
}
.stat-header{
  font-size: 16px;
}
.stat-player-name{
  font-size: 16px;
}
.stat-avg{
  font-size: 16px;
  color: rgb(31, 31, 131);
}
</style>
