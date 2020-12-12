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
                    <TeamsTab/>
                </div>
            </template>
            <template slot="tab2">
                <div class="container">
                    <ArenasTab/>
                </div>
            </template>
            <template slot="tab3">
                <div class="container">
                    <CollegesTab/>
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
import TeamsTab from "./Teams/Index";
import ArenasTab from "./Arenas/Index";
import CollegesTab from "./Colleges/Index";
export default {
    name: "clubs",
    data() {
        return {
            tabs: [
                {
                    title: "Drużyny",
                    icon: "fas fa-users",
                    template: "tab1"
                },
                {
                    title: "Areny",
                    icon: "fas fa-warehouse",
                    template: "tab2"
                },
                {
                    title: "Uniwersytety",
                    icon: "fas fa-warehouse",
                    template: "tab3"
                }
            ]
        };
    },
    components: {
      TeamsTab,
      ArenasTab,
      CollegesTab,
      DxTabPanel,
    }
};
</script>