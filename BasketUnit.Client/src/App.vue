<template>
  <div id="app">
    <div style="display: flex;">
    <div class="vertical-nav bg-white ml-1">
      <div class="py-4 px-3 mb-1 ">
        <router-link :to="{ name: 'dashboard' }">
          <div class="media d-flex align-items-center"><i class="fas fa-basketball-ball mr-1" style="font-size: 42px;"></i>
            <div class="media-body">
              <h5 class="m-1">BASKET UNIT</h5>
            </div>
          </div>
        </router-link>
      </div>

      <div class="py-4 px-3 mb-4 bg-light">
        <div class="media d-flex align-items-center">
            <!-- <img v-bind:src="userData.UserAvatar" width="65" class="mr-3 rounded-circle img-thumbnail shadow-sm"> -->
          <div class="media-body">
            <!-- <h6 class="m-0">{{ userData.FullName }}</h6> -->
            <!-- <p class="font-weight-light text-muted mb-0">{{ userData.Function }}</p> -->
            <span><i class="fas fa-sign-out-alt"></i></span>
          </div>
        </div>
      </div>

      <!-- <p class="text-gray font-weight-bold text-uppercase px-3 small pb-4 mb-0">Main</p> -->

      <ul class="nav flex-column bg-white mb-0">
        <li class="nav-item">
          <router-link :to="{ name: 'team.lineup' }" class="nav-link">
          <span class="nav-link text-dark mb-2">
              <i class="fas fa-users mr-1"></i>
              Skład 
          </span>
          </router-link>
        </li>
        <li class="nav-item">
          <router-link :to="{ name: 'team.firstLineup' }" class="nav-link">
          <span class="nav-link text-dark mb-2">
              <i class="fas fa-users mr-1"></i>
              Pierwsza piątka 
          </span>
          </router-link>
        </li>
        <!-- <li class="nav-item mb-3">
          <router-link :to="{ name: 'statistics.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-chart-bar mr-1"></i>
              Statystyki
          </span>
          </router-link>
        </li> -->
        <li class="nav-item mb-3">
          <router-link :to="{ name: 'schedules.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-calendar-alt mr-1"></i>
              Kalendarz
          </span>
          </router-link>
        </li>
        <li class="nav-item mb-3">
          <router-link :to="{ name: 'workouts.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-dumbbell mr-1"></i>
              Treningi
            </span>
            </router-link>
        </li>
        <li class="nav-item mb-3">
          <router-link :to="{ name: 'games.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-basketball-ball mr-1"></i>
              Mecze
            </span>
            </router-link>
        </li>
        <li class="nav-item mb-3">
          <router-link :to="{ name: 'protocols.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-file-alt mr-1"></i>
              Protokoły
            </span>
            </router-link>
        </li>
        <!-- <li class="nav-item mb-3">
          <router-link :to="{ name: 'administration.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-flag mr-1"></i>
              Protokoły
            </span>
            </router-link>
        </li> -->
        <li class="nav-item mb-3">
          <router-link :to="{ name: 'administration.index' }" class="nav-link">
            <span class="text-dark">
                <i class="fas fa-cog mr-1"></i>
                Administracja
              </span>
          </router-link>
        </li>
      </ul>
        <!-- <div>
          <div>
            <img v-bind:src="userData.TeamBadge" width="65">
          </div>
          <span>{{ userData.TeamName }}</span>
        </div>   -->
    </div>
    <div class="container mt-4 pl-2 pr-2" style="width: auto;">
      <router-view />
    </div>
    <div style="justify-content: flex-end;">
      <div style="width: 175px; height: 400px; margin-right: 50px; border: 2px solid rgba(104, 103, 102, 0.096) ; border-radius: 3px; margin-top: 100px; ">
        <div style="margin-top: 10px; text-align: center; font-weight: bold; color: blue">Nadchodzące mecze</div>
        <div v-for="item in getClosestGames" :key="item.startDate" style="border-bottom: 1px solid rgba(104, 103, 102, 0.096)" class="mt-3">
          <strong>{{item.homeTeam}} vs. {{item.awayTeam}}</strong>
          <div>Arena: {{item.arena}}</div>
          <div>Data: {{item.startDate}}</div>
        </div>
      </div>
      <div style="width: 175px; height: 375px; margin-right: 50px; border: 2px solid rgba(104, 103, 102, 0.096) ; margin-top: 50px; border-radius: 3px;">
        <div style="margin-top: 10px; text-align: center; font-weight: bold; color: blue;">Liderzy ligi</div>
        <!-- <div v-for="item in getLeaugueLeaders" :key="item.statType">
          <strong>{{item.statType}}</strong>
          {{item.fullNamePlayer}}
          {{item.team}}
          {{item.score}}
        </div> -->
        <div  class="mt-3 ml-1" style="border-bottom: 1px solid rgba(104, 103, 102, 0.096)">
          <div><strong>Punkty</strong></div>
          <div>Kevin Durant, Nets</div>
          <div>31.1 </div>
        </div>
        <div class="mt-1 ml-1" style="border-bottom: 1px solid rgba(104, 103, 102, 0.096)">
          <div><strong>Asysty</strong></div>
          <div>Ben Simmons, 76ers</div>
          <div>11.2 </div>
        </div>
        <div class="mt-1 ml-1" style="border-bottom: 1px solid rgba(104, 103, 102, 0.096)">
          <div><strong>Zbiórki</strong></div>
          <div>Zion Williamson, Pelicans</div>
          <div>12.4 </div>
        </div>
        <div class="mt-1 ml-1" style="border-bottom: 1px solid rgba(104, 103, 102, 0.096)">
          <div><strong>Przechwyty</strong></div>
          <div>LeBron James, Lakers</div>
          <div>3.6 </div>
        </div>
        <div class="mt-1 ml-1" style="border-bottom: 1px solid rgba(104, 103, 102, 0.096)">
          <div><strong>Bloki</strong></div>
          <div>Anthony Davis, Lakers</div>
          <div>2.4 </div>
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
  name: 'App',
  computed: {
    ...mapGetters(["getLeaugueLeaders", "getClosestGames"])
  },
  methods: {
    ...mapActions(["setLeagueaLeaders", "setClosestGames"])
  },
  created(){
    this.setLeagueaLeaders();
    this.setClosestGames();
  }
};
</script>

<style scoped>

.vertical-nav {
  min-width: 200px;
  width: 200px;
  height: 100vh;
  position: fixed;
  top: 0;
  left: 0;
  box-shadow: 3px 3px 10px rgba(104, 103, 102, 0.096);
  transition: all 0.4s;
  font-size: 16px;
}

</style>
