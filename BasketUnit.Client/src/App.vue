<template>
  <div id="app">
    <div class="vertical-nav bg-white ml-1">
      <div class="py-4 px-3 mb-1 ">
        <div class="media d-flex align-items-center"><i class="fas fa-basketball-ball mr-1" style="font-size: 42px;"></i>
          <div class="media-body">
            <h5 class="m-1">BASKETUNIT</h5>
          </div>
        </div>
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
          <router-link :to="{ name: 'team.index' }" class="nav-link">
          <span class="nav-link text-dark mb-2">
              <i class="fas fa-users mr-1"></i>
              Drużyna 
          </span>
          </router-link>
        </li>
        <li class="nav-item mb-3">
          <router-link :to="{ name: 'statistics.index' }" class="nav-link">
          <span class="nav-link text-dark">
              <i class="fas fa-chart-bar mr-1"></i>
              Statystyki
          </span>
          </router-link>
        </li>
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
    <div class="container mt-3 pl-2">
      <router-view />
    </div>
    <div>
      <!-- <IncomingTermsComponent/>
      <LeagueLeadersComponent/> -->
    </div>
  </div>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import IncomingTermsComponent from "./components/IncomingTermsComponent.vue"
import LeagueLeadersComponent from "./components/LeagueLeadersComponent.vue"
import store from "./store";
export default {
  name: 'App'
};
</script>

<style>

.vertical-nav {
  min-width: 200px;
  width: 200px;
  height: 100vh;
  position: fixed;
  top: 0;
  left: 0;
  box-shadow: 3px 3px 10px rgba(243, 125, 70, 0.671);
  transition: all 0.4s;
  font-size: 16px;
}

</style>
