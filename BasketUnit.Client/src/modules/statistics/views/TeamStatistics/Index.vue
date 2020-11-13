<template>
    <div class="content">
        <div class="main-header mt-1 mb-2">
            <h3 class="main-header-title">Statystyki</h3>
        </div>
        <DxTabPanel
            :height="auto"
            enimation-enabled="true"
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
                    <PlayerStatsTab/>
                </div>
            </template>
            <template slot="tab2">
                <div class="container">
                    <TeamStatsTab/>
                </div>
            </template>
        </DxTabPanel>

        <div class="d-flex end-xs mt-5">
            <DxButton 
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function() { $router.push({ name: 'dashboard' }) }"/>
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
import PlayerStatsTab from "./Components/PlayerStatsTab";
import TeamStatsTab from "./Components/TeamStatsTab";
export default {
    name: "statistics",
    data() {
        return {

        };
    },
    created() {

    },
    computed: {

    },
    methods: {

    },
    mounted() {
        DxButton,
        DxTabPanel,
        PlayerStatsTab,
        TeamStatsTab
    }
}
</script>