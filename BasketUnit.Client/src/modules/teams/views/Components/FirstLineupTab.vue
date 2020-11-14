<template>
<div class="container">
    <div>
        <label>Point Guard</label>
        <DxSelectBox
            v-model="PointGuardId"
            :data-source="getPlayers"
            value-expr="Value"
            display-expr="Text"/>
        <label>Shooting Guard</label>
        <DxSelectBox
            v-model="ShootingGuardId"
            :data-source="getPlayers"
            value-expr="Value"
            display-expr="Text"/>
        <label>Small Forward</label>
        <DxSelectBox
            v-model="SmallForwardId"
            :data-source="getPlayers"
            value-expr="Value"
            display-expr="Text"/>
        <label>Power Forward</label>
        <DxSelectBox
            v-model="PowerForwardId"
            :data-source="getPlayers"
            value-expr="Value"
            display-expr="Text"/>
        <label>Center</label>
        <DxSelectBox
            v-model="CenterId"
            :data-source="getPlayers"
            value-expr="Value"
            display-expr="Text"/>
    </div>
    <div class="court-area">
        <div>
            <div>
            {{ getPointGuard.FullName }}
            {{ getPointGuard.Number }}
            {{ getPointGuard.Avatar }}
            </div>
            <div>
            {{ getShootingGuard.FullName }}
            {{ getShootingGuard.Number }}
            {{ getShootingGuard.Avatar }}
            </div>
            <div>
            {{ getSmallForward.FullName }}
            {{ getSmallForward.Number }}
            {{ getSmallForward.Avatar }}
            </div>
            <div>
            {{ getPowerForward.FullName }}
            {{ getPowerForward.Number }}
            {{ getPowerForward.Avatar }}
            </div>
            <div>
            {{ getCenter.FullName }}
            {{ getCenter.Number }}
            {{ getCenter.Avatar }}
            </div>
        </div>
    </div>
</div>
</template>
<script>
import 
{ 
    DxDataGrid, 
    DxColumn, 
    DxFilterRow, 
    DxButton,
    DxPager,
    DxPaging
} from 'devextreme-vue';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapState } from "vuex";
const store = "TeamStore";
export default {
    name: "firstLineup",
    data() {
        return {
             
        };
    },
    created() {

    },
    computed: {
        ...mapGetters(name, ["getPlayersList", "getFirstLineupPlayers", "getPointGuard", "getShootingGuard", "getSmallForward", "getPowerForward", "getCenter"]),
        ...mapState(name, ["pointGuardId", "shootingGuardId", "smallForwardId", "powerForwardId", "centerId"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setFirstLineupPlayers"])
    },
    mounted() {
        this.setPlayersList();
        this.setFirstLineupPlayers();
    },
    components: {

    }

}
</script>