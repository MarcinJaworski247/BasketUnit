<template>
    <div class="content">
        <div class="printers">
            <div >
                <div style="text-align: center; font-size: 24px; font-weight: bold;" class="mt-4">
                    <div>
                        
                        <img v-if="HomeTeamBadge.length" style="width: 100px;" v-bind:src="'data:image/jpeg;base64,'+HomeTeamBadge"/>
                        {{ HomeTeam }}
                        {{ HomeTeamScore }}  :  {{ AwayTeamScore }}
                        {{ AwayTeam }}
                        <img v-if="AwayTeamBadge.length" style="width: 100px;" v-bind:src="'data:image/jpeg;base64,'+AwayTeamBadge"/>
                        
                    </div>
                    <div class="mt-4">
                        <h4>Data: {{ GameDate }}</h4>
                        <h4>Arena: {{ Arena }}</h4>
                        <h4>Sędziowie: {{ FirstReferee }},  {{ SecondReferee }}</h4>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-6">
                        <table>
                            <thead>
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
                                    <td>{{ stat.fullName }}</td>
                                    <td>{{ stat.points }}</td>
                                    <td>{{ stat.assists }}</td>
                                    <td>{{ stat.rebounds }}</td>
                                    <td>{{ stat.steals }}</td>
                                    <td>{{ stat.blocks }}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="col-6">
                        <table>
                            <thead>
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
                                    <td>{{ stat.fullName }}</td>            
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
                @click="function(){ $router.push({ name: 'games.index' }) }"/>
            </div>
        </div>
    </div>
</template>
<script>
import { 
    DxButton
} from 'devextreme-vue';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "GamesDetailsStore";
export default {
    name: "gameDetails",
    computed: {
        ...mapGetters(store, ["getGameDetails", "getGamePlayersStats", "getHomeTeamStats", "getAwayTeamStats"]),
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
        ])
    },
    methods: {
        ...mapActions(store, ["setGameDetails", "setGamePlayersStats"])
    },
    created() {
        this.setGameDetails()
            .then(()=>{
                this.setGamePlayersStats();
            });
    },
    components: {
        DxButton
    }
}
</script>