<template>
  <div class="content">
    <div class="printers">
      <div>
        <div>
          <div class="teams">
            <div>
              <img
                v-if="HomeTeamBadge.length"
                style="width: 150px;"
                v-bind:src="'data:image/jpeg;base64,' + HomeTeamBadge"
              />
              <span class="team-name">{{ HomeTeam }}</span>
              <span class="score">{{ HomeTeamScore }} : {{ AwayTeamScore }}</span>
              <span class="team-name">{{ AwayTeam }}</span>
              <img
                v-if="AwayTeamBadge.length"
                style="width: 150px;"
                v-bind:src="'data:image/jpeg;base64,' + AwayTeamBadge"
              />
            <div class="mt-4 info">
              <h4>Data: {{ GameDate | formatDate }}</h4>
              <h4>Arena: {{ Arena }}</h4>
              <h4>Sędziowie: {{ FirstReferee }}, {{ SecondReferee }}</h4>
            </div>
            </div>
          </div>
        </div>
        <div class="mt-4 flexxin">
          <div class="left-div">
            <table class="table">
              <thead class="table-header">
                <tr>
                  <th>Zawodnik</th>
                  <th>Punkty</th>
                  <th>Asysty</th>
                  <th>Zbiórki</th>
                  <th>Przechwyty</th>
                  <th>Bloki</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="stat in getHomeTeamStats" v-bind:key="stat.fullName">
                  <td class="player-name">{{ stat.fullName }}</td>
                  <td>{{ stat.points }}</td>
                  <td>{{ stat.assists }}</td>
                  <td>{{ stat.rebounds }}</td>
                  <td>{{ stat.steals }}</td>
                  <td>{{ stat.blocks }}</td>
                </tr>
              </tbody>
            </table>
          </div>
          <div class="right-div">
            <table class="table">
              <thead class="table-header">
                <tr>
                  <th>Bloki</th>
                  <th>Przechwyty</th>
                  <th>Zbiórki</th>
                  <th>Asysty</th>
                  <th>Punkty</th>
                  <th>Zawodnik</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="stat in getAwayTeamStats" v-bind:key="stat.fullName">
                  <td>{{ stat.blocks }}</td>
                  <td>{{ stat.steals }}</td>
                  <td>{{ stat.rebounds }}</td>
                  <td>{{ stat.assists }}</td>
                  <td>{{ stat.points }}</td>
                  <td class="player-name">{{ stat.fullName }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div class="d-flex end-xs mt-5 mb-4">
        <DxButton
          :use-submit-behavior="false"
          type="normal"
          styling-mode="outlined"
          text="Wróć"
          @click="function() { $router.push({ name: 'games.index' }); }"/>
      </div>
    </div>
  </div>
</template>
<script>
import { DxButton } from "devextreme-vue";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "GamesDetailsStore";
export default {
  name: "gameDetails",
  computed: {
    ...mapGetters(store, [
      "getGameDetails",
      "getGamePlayersStats",
      "getHomeTeamStats",
      "getAwayTeamStats",
    ]),
    ...mapFields(store, [
      "detailsForm.HomeTeam",
      "detailsForm.AwayTeam",
      "detailsForm.HomeTeamBadge",
      "detailsForm.AwayTeamBadge",
      "detailsForm.GameDate",
      "detailsForm.HomeTeamScore",
      "detailsForm.AwayTeamScore",
      "detailsForm.Arena",
      "detailsForm.FirstReferee",
      "detailsForm.SecondReferee",
    ]),
  },
  methods: {
    ...mapActions(store, ["setGameDetails", "setGamePlayersStats"]),
  },
  created() {
    this.setGameDetails().then(() => {
      this.setGamePlayersStats();
    });
  },
  components: {
    DxButton,
  },
};
</script>
<style scoped>
.main-header-title{
  color: rgb(31, 31, 131);
  font-size: 32px;
}
.teams{
  display: flex;
  justify-content: center;
}
.left-div{
  align-content: flex-start;
}
.right-div{
  align-content: flex-end;
}
.flexxin{
  display: flex;
  flex-grow: 1;
  justify-content: space-between;
}
.score{
  font-size: 24px;
  font-weight: 800;
  color: #4d4d4d;
  margin-right: 40px;
  margin-left: 40px;
}
.team-name{
  font-size: 24px; 
  margin-right: 20px;
  margin-left: 20px;
}
.info{
  text-align: center;
}
.player-name{
  color: #4d4d4d;
}
tr:hover {background-color:#fde2a6;}
tr:nth-child(even) {background-color: #f7f7f7;}
table{
  text-align: center;
}
</style>