<template>
<div class="container">
    <div class="row mt-4 mb-2">
    <div class="col-xs-6 mr-4">
        <label>Point Guard</label>
        <DxSelectBox
            v-model="pointGuardId"
            :data-source="getPointGuards"
            value-expr="Value"
            display-expr="Text"/>
        <label>Shooting Guard</label>
        <DxSelectBox
            v-model="shootingGuardId"
            :data-source="getShootingGuards"
            value-expr="Value"
            display-expr="Text"/>
        <label>Small Forward</label>
        <DxSelectBox
            v-model="smallForwardId"
            :data-source="getSmallForwards"
            value-expr="Value"
            display-expr="Text"/>
        <label>Power Forward</label>
        <DxSelectBox
            v-model="powerForwardId"
            :data-source="getPowerForwards"
            value-expr="Value"
            display-expr="Text"/>
        <label>Center</label>
        <DxSelectBox
            v-model="centerId"
            :data-source="getCenters"
            value-expr="Value"
            display-expr="Text"/>
    </div>
    <div class="col-xs-6 ml-4 court-wrapper" style="display: flex;">
        <div class="ml-4">
            <div class="row mt-4">
                <div class="tile-border">
                    {{ firstLineup.pointGuard.FirstName }} {{ firstLineup.pointGuard.LastName }}
                    {{ firstLineup.pointGuard.Number }}
                    <img v-if="firstLineup.pointGuard.Avatar.length" v-bind:src="'data:image/jpeg;base64,'+firstLineup.pointGuard.Avatar" /> 
                </div>
                <div class="tile-border">
                    {{ firstLineup.shootingGuard.FirstName }} {{ firstLineup.shootingGuard.LastName }}
                    {{ firstLineup.shootingGuard.Number }}
                    <img v-if="firstLineup.shootingGuard.Avatar.length" v-bind:src="'data:image/jpeg;base64,'+firstLineup.shootingGuard.Avatar" /> 
                </div>
            </div>
            <div class="row mt-4">
                <div class="tile-border">
                    {{ firstLineup.smallForward.FirstName }} {{ firstLineup.smallForward.LastName }}
                    {{ firstLineup.smallForward.Number }}
                    <img v-if="firstLineup.smallForward.Avatar.length" v-bind:src="'data:image/jpeg;base64,'+firstLineup.smallForward.Avatar" /> 
                </div>
                <div class="tile-border">
                    {{ firstLineup.powerForward.FirstName }} {{ firstLineup.powerForward.LastName }}
                    {{ firstLineup.powerForward.Number }}
                    <img v-if="firstLineup.powerForward.Avatar.length" v-bind:src="'data:image/jpeg;base64,'+firstLineup.powerForward.Avatar" /> 
                </div>
            </div>
            <div class="row mt-4">
                <div class="tile-border">
                    {{ firstLineup.center.FirstName }} {{ firstLineup.center.LastName }} 
                    {{ firstLineup.center.Number }}
                    <img v-if="firstLineup.center.Avatar.length" v-bind:src="'data:image/jpeg;base64,'+firstLineup.center.Avatar" /> 
                </div>
            </div>
        </div>
    </div>
    </div>
    <div class="d-flex end-xs mt-5">
        <DxButton 
            text="Zapisz"
            type="default"
            styling-mode="outlined"
            class="mb-2"
            @click="saveFirstLineup()"
        />
    </div>
</div>

</template>
<script>
import 
{ 
    DxSelectBox,
    DxButton
} from 'devextreme-vue';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapState } from "vuex";
import notify from 'devextreme/ui/notify';
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
        ...mapGetters(store, [
            "getPlayersList", 
            "getFirstLineupPlayers",
            "getPointGuards",
            "getShootingGuards",
            "getSmallForwards",
            "getPowerForwards",
            "getCenters"
        ]),
        ...mapState(store, [
            "pointGuardId", 
            "shootingGuardId", 
            "smallForwardId", 
            "powerForwardId", 
            "centerId",
            "firstLineup"
        ])
    },
    methods: {
        ...mapActions(store, [
            "setPlayersList", 
            "setFirstLineupPlayers",
            "setPointGuard",
            "setShootingGuard",
            "setSmallForward",
            "setPowerForward",
            "setCenter",
            "setPointGuards",
            "setShootingGuards",
            "setSmallForwards",
            "setPowerForwards",
            "setCenters",
            "saveFirstLineup"
        ]),
        saveFirstLineup() {
            this.saveFirstLineup()
                .then(() => {
                    this.showSuccessNotify();
                });
        },
        showSuccessNotify() {
            this.$nextTick(() => {
            notify("Zapisano", "success", 500);
            })
        },
    },
    mounted() {
        this.setPlayersList();
        this.setFirstLineupPlayers();
        this.setPointGuard();
        this.setShootingGuard();
        this.setSmallForward();
        this.setPowerForward();
        this.setCenter();
        this.setPointGuards();
        this.setShootingGuards();
        this.setSmallForwards();
        this.setPowerForwards();
        this.setCenters();
    },
    components: {
        DxSelectBox,
        DxButton
    }

}
</script>
<style scoped>
.court-wrapper {
    border: 1px solid black;
    width: 800px;
    height: 600px;
}
.tile-border {
    border: 1px solid black; 
    height: 100px; 
    width: 100px;
    border-radius: 3px;;
}
</style>