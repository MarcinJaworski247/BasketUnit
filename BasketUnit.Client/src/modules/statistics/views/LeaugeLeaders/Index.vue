<template>
    <div class="content">
        <LeagueLeaderTile :data="getPointsLeaders">
        <LeagueLeaderTile :data="getAssistsLeaders">
        <LeagueLeaderTile :data="getReboundsLeaders">
        <LeagueLeaderTile :data="getBlocksLeaders">
        <LeagueLeaderTile :data="getStealsLeaders">
    </div>
</template>
<script>
import LeagueLeaderTile from "./Components/LeagueLeaderTile";
const store = "StatisticsLeagueLeadersStore";

export default {
    name: "leagueLeaders",
    data() {
        return {

        };
    },
    created() {
        this.setPointsLeaders();
        this.setAssistsLeaders();
        this.setReboundsLeaders();
        this.setBlocksLeaders();
        this.setStealsLeaders();
    },
    computed: {
        ...mapGetters(store, [
            "getPointsLeaders", 
            "getAssistsLeaders", 
            "getReboundsLeaders", 
            "getBlocksLeaders", 
            "getStealsLeaders"
        ])
    },
    methods: {
        ...mapActions(store, [
            "setPointsLeaders", 
            "setAssistsLeaders", 
            "setReboundsLeaders", 
            "setBlocksLeaders",
            "setStealsLeaders"
        ]),
    },
    mounted() {

    },
    components: {

    }
};
</script>