<template>
    <div>
        <div>data.StatisticsTitle</div>
        <div v-for="player in data" :key="player.Id">
            <div>{{player.FullName}}, {{player.Position}}, {{player.Team}}</div>
            <div>{{player.Avarage}}</div>
        </div>
    </div>
</template>
<script>
export default {
    name: "leagueLeaderTile",
    props: {
        data: Array
    }
}
</script>