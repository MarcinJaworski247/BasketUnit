<template>
    <div class="content">
        <div class="printers">
            <div class="row">
                <div class="row">
                    <span>Ostatnie mecze</span>
                    <div v-for="item in getLastGames" v-bind:key="item.id" class="col-3" v-bind:class="{loseTile : !item.isWin, winTile : item.isWin}">
                        <img style="height: 300px;" v-bind:src="'data:image/jpeg;base64,' + item.badge"/>
                        <span>{{ item.score }}</span>
                    </div>
                </div>
                <div class="row">
                    <span>Nadchodzące mecze</span>
                    <div v-for="item in getFutureGames" v-bind:key="item.id" class="col-3">
                        <img style="height: 300px;" v-bind:src="'data:image/jpeg;base64,' + item.badge"/>
                        <span>{{ item.date }}</span>
                        <span>{{ item.arena }}</span>
                    </div>
                </div>
                <div class="row">
                    <span>Kontuzje</span>
                    <div v-for="item in getInjuredPlayers" v-bind:key="item.id" class="col-4">
                        <img style="height: 300px;" v-bind:src="'data:image/jpeg;base64,' + item.avatar"/>
                        <span>{{ item.fullName }}</span>
                        <span>{{ item.injury }}</span>
                    </div>
                </div>
                <!-- <div class="row">
                    <span>Statystyki drużyny</span>
                </div>
                <div class="row">
                    <span>Tabela ligowa</span>
                </div> -->
                <div class="row">
                    <span>Nadchodzące treningi</span>
                    <div v-for="item in getFutureWorkouts" v-bind:key="item.startDate" class="col-4">
                        
                        <span>{{ item.workout }}</span>
                        <span>{{ item.startDate }}</span>
                    </div>
                </div> 
            </div>
        </div>
    </div>
</template>

<script>
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "DashboardStore";

export default {
    name: "dashboard",
    computed: {
        ...mapGetters(store, [
            "getLastGames", 
            "getFutureGames", 
            "getInjuredPlayers", 
            //"getTeamStats",
            "getFutureWorkouts"
        ])
    },
    methods: {
        ...mapActions(store, [
            "setLastGames", 
            "setFutureGames", 
            "setInjuredPlayers", 
            //"setTeamStats",
            "setFutureWorkouts"
        ])
    },
    created() {
        this.setLastGames();
        this.setFutureGames();
        this.setInjuredPlayers();
        //this.setTeamStats();
        this.setFutureWorkouts();
    }
}
</script>
<style type="scss" scoped>
.last-games-tile{
    width: 300px;
    height: 100px;
    border: 1px solid black;
    border-radius: 2px;
    margin-top: 24px;
}
.future-games-tile{
    width: 300px;
    height: 100px;
    border: 1px solid black;
    border-radius: 2px;
    margin-top: 24px;
}
.injured-players-tile{
    width: 150px;
    height: 100px;
    border: 1px solid black;
    border-radius: 2px;
    margin-top: 24px;
}
.team-statistics-tile{
    width: 450px;
    height: 200px;
    border: 1px solid black;
    border-radius: 2px;
    margin-top: 24px;
}
.league-table-tile{
    width: 450px;
    height: 200px;
    border: 1px solid black;
    border-radius: 2px;
    margin-top: 24px;
}
.winTile{
    border-color: green;
}
.loseTile{
    border-color: red;
}
</style>