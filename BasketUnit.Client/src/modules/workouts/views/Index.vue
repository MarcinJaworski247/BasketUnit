<template>
    <div class="content">
            <div class="main-header mt-1 mb-2">
                <h3 class="main-header-title"> Treningi </h3>
            </div>

            <DxTabPanel
                height="800"
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
                        <WorkoutTypesTab/>
                    </div>
                </template>
                <template slot="tab2">
                    <div class="container">
                        <ExcercisesTab/>
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
import WorkoutTypesTab from "./WorkoutTypes/Index";
import ExcercisesTab from "./Excercises/Index";
export default {
    name: "workouts",
    data() {
        return {
            tabs: [
                {
                    title: "Rodzaje treningów",
                    icon: "far fa-dumbbell",
                    template: "tab1"
                },
                {
                    title: "Ćwiczenia",
                    icon: "far fa-running",
                    template: "tab2"
                }
            ]
        };
    },
    components: {
        DxTabPanel,
        WorkoutTypesTab,
        ExcercisesTab
    }
}
</script>

<style scoped>
/* .tile{
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
} */

</style>