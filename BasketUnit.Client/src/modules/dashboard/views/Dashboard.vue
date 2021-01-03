<template>
    <div class="content">
        <div class="printers">
            <div style="display: flex;">
                <div class="last-games-row">
                    <div class="row-header">Ostatnie mecze</div>
                    <div class="flexxin">
                        <div v-for="item in getLastGames" v-bind:key="item.id"  v-bind:class="{loseTile : !item.isWin, winTile : item.isWin}">
                            <img style="width: 80px; max-height: 80px;" v-bind:src="'data:image/jpeg;base64,' + item.badge"/>
                            <div class="score">{{ item.score }}</div>
                        </div>
                    </div>
                </div>

                <div class="future-games-row">
                    <div class="row-header">Nadchodzące mecze</div>
                    <div class="flexxin">
                        <div v-for="item in getFutureGames" v-bind:key="item.id" class="future-game">
                            <img style="width: 70px;  max-height: 70px;" v-bind:src="'data:image/jpeg;base64,' + item.badge"/>
                            <div class="future-game-desc">{{ item.date }}</div>
                            <div class="future-game-desc">{{ item.arena }}</div>
                        </div>
                    </div>
                </div>
            </div>

            <div style="display: flex;">
                <div class="injured-players-row">
                    <div class="row-header">Kontuzje</div>
                    <div class="flexxin">
                        <div v-for="item in getInjuredPlayers" v-bind:key="item.id" class="injured-player">
                            <img style="width: 80px;  max-height: 80px;" v-bind:src="'data:image/jpeg;base64,' + item.avatar"/>
                            <div class="player-name">{{ item.fullName }}</div>
                            <div class="player-injury">{{ item.injury }}</div>
                        </div>
                    </div>
                </div>

                <div class="future-workouts-row">
                    <div class="row-header">Nadchodzące treningi</div>
                    <div class="flexxin">
                        <div v-for="item in getFutureWorkouts" v-bind:key="item.date" class="future-workout">
                            <div class="workout-icon"><i class="fas fa-running"></i></div>
                            <div class="workout-name">{{ item.workout }}</div>
                            <div class="workout-date">{{ item.date }}</div>
                        </div>
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
.winTile{
    border: 3px solid green;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    padding-top: 10px;
    box-shadow: 2px 2px rgb(0, 160, 0);
}
.loseTile{
    border: 3px solid red;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    padding-top: 10px;
    box-shadow: 2px 2px rgb(255, 92, 92);
}
.injured-player{
    border: 3px solid #ff8000;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    box-shadow: 2px 2px #ffb368;
}
.future-workout{
    border: 3px solid #ff8000;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    box-shadow: 2px 2px #ffb368;
}
.future-game{
    border: 3px solid #ff8000;
    border-radius: 10px;
    background: #fff;
    text-align: center;
    margin-right: 20px;
    height: 150px;
    width: 150px;
    padding-top: 10px;
    box-shadow: 2px 2px #ffb368;
}
.last-games-row{
    background: rgb(245, 245, 245);
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 50px;
    margin-top: 0px;
    width: 100%;
    margin-right: 10px;
    /* display: flex; */
    box-shadow: 2px 2px #cecece;
}
.future-games-row{
    background: rgb(245, 245, 245);
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 50px;
    width: 100%;
    /* display: flex; */
    box-shadow: 2px 2px #cecece;
}
.injured-players-row{
    background: rgb(245, 245, 245);
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 50px;
    width: 100%;
    margin-right: 10px;
    /* display: flex; */
    box-shadow: 2px 2px #cecece;
}
.future-workouts-row{
    background: rgb(245, 245, 245);
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 50px;
    width: 100%;
    /* display: flex; */
    box-shadow: 2px 2px #cecece;
}
.row-header{
    font-size: 24px;
    color: #4d4d4d;
    margin-bottom: 10px;
}
.workout-icon{
    font-size: 42px;
}
.score{
    font-weight: 600;
    font-size: 24px;
}
.player-name{
    font-weight: 600;
    font-size: 20px;
}
.player-injury{
    font-weight: 400;
    font-size: 16px;
}
.workout-name{
    font-weight: 600;
    font-size: 20px;
}
.workout-date{
    font-weight: 400;
    font-size: 16px;
}
.future-game-desc{
    font-weight: 400;
    font-size: 14px;
}
.flexxin{
    display: flex;
}
</style>