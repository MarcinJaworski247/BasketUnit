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
export default {
    name: "clubs",
    data() {
        return {
            tabs: [
                {
                    title: "Drużyny",
                    icon: "far fa-users",
                    template: "tab1"
                },
                {
                    title: "Areny",
                    icon: "far fa-warehouse",
                    template: "tab2"
                }
            ]
        };
    },
    components: {
      TeamsTab,
      ArenasTab,
      DxTabPanel,
    }
};
</script>

<style scoped>
.tile{
    width: 160px;
    height: 160px;
    border: 1px solid black;
    margin-right: 16px;
    border-radius: 2px;
    float: left;
    border-radius: 2px;
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