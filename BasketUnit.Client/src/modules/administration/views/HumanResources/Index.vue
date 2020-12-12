<template>
    <div class="content">

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
                    <PlayersTab/>
                </div>
            </template>
            <template slot="tab2">
                <div class="container">
                    <CoachesTab/>
                </div>
            </template>
            <template slot="tab3">
                <div class="container">
                    <RefereesTab/>
                </div>
            </template>
            <template slot="tab4">
                <div class="container">
                    <NationalitiesTab/>
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
import PlayersTab from "./Players/Index";
import CoachesTab from "./Coaches/Index";
import RefereesTab from "./Referees/Index";
import NationalitiesTab from "./Nationalities/Index";
export default {
    name: "humanResources",
    data() {
        return {
            tabs: [
                {
                    title: "Zawodnicy",
                    icon: "fas fa-users",
                    template: "tab1"
                },
                {
                    title: "Trenerzy",
                    icon: "fas fa-users",
                    template: "tab2"
                },
                {
                    title: "Sędziowie",
                    icon: "fas fa-users",
                    template: "tab3"
                },
                {
                    title: "Narodowości",
                    icon: "far fa-flag",
                    template: "tab4"
                }
            ]
        };
    },
    components: {
        DxTabPanel,
        PlayersTab,
        CoachesTab,
        NationalitiesTab,
        RefereesTab
    }
};
</script>

<style scoped>
</style>