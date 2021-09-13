<template>
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
          <i class="fas fa-chart-line mr-1"></i>
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
</template>

<style scoped>
h5 a:hover {
  text-decoration: none;
}
ul li {
  padding: 15px;
  font-size: 20px;
}
ul li a {
  color: #4d4d4d;
  display: block;
}
ul li a .far .fas {
  width: 35px;
}
.far .fas {
  width: 4px;
}
ul li:hover {
  background: rgb(247, 248, 248);
  color: #ff8000;
  border-top-right-radius: 10px;
  border-bottom-right-radius: 10px;
}
ul li:hover a {
  color: #ff8000;
  text-decoration: none;
}
</style>
