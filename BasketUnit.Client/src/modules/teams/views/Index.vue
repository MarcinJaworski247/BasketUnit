<template>
<div class="content">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Drużyna </h3>
    </div>

    <DxTabPanel
        min-height="800"
        width="1200"
        :animation-enabled=true
        :swipe-enabled=false
        :items="tabs">
        <template #title="{ data: tabs }">
            <span>
                <i :class="tabs.icon"></i>
                {{ tabs.title }}
            </span> 
        </template>
        <template slot="tab1">
            <div class="container">
                <LineupTab/>
            </div>
        </template>
        <template slot="tab2">
            <div class="container">
                <FirstLineupTab/>
            </div>
        </template>
    </DxTabPanel>
</div>
</template>
<script>
import 
{ 
    DxTabPanel
} from 'devextreme-vue';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "TeamStore";
import LineupTab from "./Components/LineupTab";
import FirstLineupTab from "./Components/FirstLineupTab";
export default {
    name: "teams",
    data() {
        return {
            tabs: [
                {
                    title: "Skład",
                    icon: "fas fa-users",
                    template: "tab1"
                },
                {
                    title: "Pierwsza piątka",
                    icon: "fas fa-users",
                    template: "tab2"
                }
            ]
        };
    },
    computed: {
        ...mapGetters(name, ["getPlayersList", "getFirstLineupPlayers"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setFirstLineupPlayers"])
    },
    components: {
        DxTabPanel,
        LineupTab,
        FirstLineupTab
    }
}
</script>