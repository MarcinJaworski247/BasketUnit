<template>
    <div class="content">
        <div class="printers ml-4">
            <div class="main-header mt-4 mb-2">
                <h3 class="main-header-title">
                    Statystyki
                </h3>
            </div>
            <div class="mt-4">
                <router-link :to="{ name: 'statistics.teamStatistics.index' }">
                    <div class="tile">
                        <div class="tile-image">
                            <span class="fas fa-users"></span>
                        </div>
                        <div class="tile-name">
                            <span>STATYSTYKI DRUŻYN</span>
                        </div>
                    </div>
                </router-link>
                <router-link :to="{ name: 'statistics.leagueLeaders.index' }">
                    <div class="tile">
                        <div class="tile-image">
                            <span class="fas fa-users"></span>
                        </div>
                        <div class="tile-name">
                            <span>LIDERZY LIGI</span>
                        </div>
                    </div>
                </router-link>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style scoped>
.tile{
    width: 160px;
    height: 160px;
    border: 1px solid black;
    margin-right: 16px;
    border-radius: 2px;
    float: left;
}
.tile:hover{
    color: darkgrey;
    border-color: darkgrey;
    cursor: pointer;
}
.tile-image{
    padding-top: 5px;
    margin-left: auto;
    margin-right: auto;
    width: 60px;
    height: 60px;
    font-size: 48px;
}
.tile-name{
    margin-top: 16px;
    margin-left: auto;
    margin-right: auto;
    size: 16px;
    font-weight: 700;
    text-align: center;
}

</style>