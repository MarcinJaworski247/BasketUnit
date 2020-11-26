<template>
<div class="container">
    <div class="row mt-4 mb-2">
    <div class="col-xs-6 mr-4">
        <label>Point Guard</label>
        <DxSelectBox
            v-model="pointGuardId"
            :data-source="getPointGuards"
            value-expr="value"
            display-expr="text"/>
        <label>Shooting Guard</label>
        <DxSelectBox
            v-model="shootingGuardId"
            :data-source="getShootingGuards"
            value-expr="value"
            display-expr="text"/>
        <label>Small Forward</label>
        <DxSelectBox
            v-model="smallForwardId"
            :data-source="getSmallForwards"
            value-expr="value"
            display-expr="text"/>
        <label>Power Forward</label>
        <DxSelectBox
            v-model="powerForwardId"
            :data-source="getPowerForwards"
            value-expr="value"
            display-expr="text"/>
        <label>Center</label>
        <DxSelectBox
            v-model="centerId"
            :data-source="getCenters"
            value-expr="value"
            display-expr="text"/>
    </div>
    <div class="col-xs-6 ml-4 court-wrapper">
        <div class="ml-4">
            <div class="row mt-4">
                <div class="tile-border">
                    <!-- {{ center.firstName }} {{ center.lastName }}
                    #{{ center.playerNumber }} -->
                    {{getFirstLineupPlayers[4].fullName}}
                    <img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[4].avatar" /> 
                </div>
                <div class="tile-border">
                    <!-- {{ powerForward.firstName }} {{ powerForward.lastName }}
                    #{{ powerForward.playerNumber }} -->
                    {{getFirstLineupPlayers[3].fullName}}
                    <img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[3].avatar" /> 
                </div>
            </div>
            <div class="row mt-4">
                <div class="tile-border">
                    <!-- {{ smallForward.firstName }} {{ smallForward.lastName }}
                    #{{ smallForward.playerNumber }} -->
                    {{getFirstLineupPlayers[2].fullName}}
                    <img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[2].avatar" /> 
                </div>
                <div class="tile-border">
                    <!-- {{ shootingGuard.firstName }} {{ shootingGuard.lastName }}
                    #{{ shootingGuard.playerNumber }} -->
                    {{getFirstLineupPlayers[1].fullName}}
                    <img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[1].avatar" /> 
                </div>
            </div>
            <div class="row mt-4">
                <div class="tile-border">
                    <!-- {{ pointGuard.firstName }} {{ pointGuard.lastName }} 
                    #{{ pointGuard.playerNumber }} -->
                    {{getFirstLineupPlayers[0].fullName}}
                    <img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[0].avatar" /> 
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
            @click="saveFirstLineupMethod()"
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
const store = "FirstLineupStore";
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
            "getPointGuards",
            "getShootingGuards",
            "getSmallForwards",
            "getPowerForwards",
            "getCenters",
            "getForm",
            "getFirstLineupPlayers"
        ]),
        ...mapFields(store, [
            "editForm.pointGuardId",
            "editForm.shootingGuardId",
            "editForm.smallForwardId",
            "editForm.powerForwardId",
            "editForm.centerId",
        ])
    },
    methods: {
        ...mapActions(store, [
            "setPlayersList",
            "setPointGuards",
            "setShootingGuards",
            "setSmallForwards",
            "setPowerForwards",
            "setCenters",
            "setEditForm",
            "saveFirstLineup",
            "setFirstLineupPlayers"
        ]),
        saveFirstLineupMethod() {
            this.saveFirstLineup()
                .then(() => {
                    this.showSuccessNotify();
                });
        },
        showSuccessNotify() {
            this.$nextTick(() => {
            notify("Zapisano", "success", 500);
            })
        }
    },
    mounted() {
        this.setPlayersList();
        this.setEditForm();
        this.setPointGuards();
        this.setShootingGuards();
        this.setSmallForwards();
        this.setPowerForwards();
        this.setCenters();
        this.setFirstLineupPlayers();
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