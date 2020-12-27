<template>
<div class="content">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Skład </h3>
    </div>
    <div class="printers mt-4 mb-2">
        <div v-for="player in getPlayersList" v-bind:key="player.id">
            <router-link
                class="datagrid-btn"
                :to="{ name: 'team.player.details', params: { playerId: player.id } }">
                <div class="tile">
                    <img v-if="player.avatar.length" style="width: 120px; margin: auto; display: block;" v-bind:src="'data:image/jpeg;base64,' + player.avatar"/>
                    <img v-else style="width: 80px; margin: auto; display: block;" v-bind:src="'https://cdn4.iconfinder.com/data/icons/small-n-flat/24/user-alt-512.png'"/>
                    <div>{{ player.fullName }}</div>
                    <div>{{player.position}} | #{{player.playerNumber}}</div>
                </div>
            </router-link>
        </div>
    </div>
</div>
</template>
<script>
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamStore";

export default {
    name: "lineup",
    computed: {
        ...mapGetters(store, ["getPlayersList", "getPositionsToLookup", "getNationalities"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setDetails", "setPositionsToLookup", "setNationalities"])
    },
    mounted() {
        this.setPlayersList();
        this.setNationalities();
        this.setPositionsToLookup();
    }
}
</script>

<style scoped>
.tile{
    width: 150px;
    height: 150px;
    border: 1px solid black;
    border-radius: 2px;
    margin-left: 8px;
    margin-top: 8px;
}
</style>