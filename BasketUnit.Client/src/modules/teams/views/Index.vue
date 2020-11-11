<template>
<div class="content">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Skład </h3>
    </div>

    <DxTabPanel
        :height="auto"
        animation-enabled="true"
        swipe-enabled="false"
        :items="tabs">
        <template #title="{ data: tabs }">
            <span>
                <i :class="tabs.icon"></i>
                {{ tabs.title }}
            </span> 
        </template>
        <template slot="tab1">
            <div class="container">
                <LineupTab :playersList="getPlayersList" />
            </div>
        </template>
        <template slot="tab2">
            <div class="container">
                <FirstLineupTab :playersList="getPlayersList" :firstLineup="getFirstLineupPlayers"/>
            </div>
        </template>
    </DxTabPanel>

    <div class="d-flex end-xs mt-5">
        <DxButton
            :use-submit-behavior="false"
            type="normal"
            styling-mode="outlined"
            text="Wróć"
            @click="function(){ $router.push({ name: 'workouts.index' }) }"/>
    </div>
</div>
</template>
<script>
import 
{ 
    DxButton,
    DxTabPanel
} from 'devextreme-vue';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamsStore";
import LineupTab from "./Components/LineupTab";
import FirstLineupTab from "./Components/FirstLineupTab";
export default {
    name: "teams",
    data() {
        return {
            tabs: [
                {
                    title: "Skład",
                    icon: "far fa-users",
                    template: "tab1"
                },
                {
                    title: "Pierwsza piątka",
                    icon: "far fa-users",
                    template: "tab2"
                }
            ]
        };
    },
    created(){

    },
    computed: {
        ...mapGetters(name, ["getPlayersList", "getFirstLineupPlayers"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setFirstLineupPlayers"])
    },
    mounted(){
        this.setPlayersList();
        this.setFirstLineupPlayers();
    },
    components: {
        DxButton,
        DxTabPanel,
        LineupTab,
        FirstLineupTab
    }
}
</script>