<template>
<div class="container">
    <div class="row mt-4 mb-4">
    <div class="col-xs-6 mr-4 mt-4">
        <label class="mt-4">Point Guard</label>
        <DxSelectBox
            v-model="pointGuardId"
            :data-source="getPointGuards"
            value-expr="value"
            display-expr="text"/>
        <label class="mt-2">Shooting Guard</label>
        <DxSelectBox
            v-model="shootingGuardId"
            :data-source="getShootingGuards"
            value-expr="value"
            display-expr="text"/>
        <label class="mt-2">Small Forward</label>
        <DxSelectBox
            v-model="smallForwardId"
            :data-source="getSmallForwards"
            value-expr="value"
            display-expr="text"/>
        <label class="mt-2">Power Forward</label>
        <DxSelectBox
            v-model="powerForwardId"
            :data-source="getPowerForwards"
            value-expr="value"
            display-expr="text"/>
        <label class="mt-2">Center</label>
        <DxSelectBox
            v-model="centerId"
            :data-source="getCenters"
            value-expr="value"
            display-expr="text"/>
    </div>
    <div class="col-xs-6 ml-4 court-wrapper court-background-image">
        <div class="ml-4">
            <div class="row mt-4">
                <div class="tile-border" style="margin-left: 20px;">
                   <div><img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[4].avatar" style="width: 100px;  margin-top: 10px;" /> </div>
                   <span style="font-weight: bold;margin-top: 8px;"> {{getFirstLineupPlayers[4].firstName}}</span>
                </div>
                <div class="tile-border" style="margin-left: 450px;">
                    <div><img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[3].avatar" style="width: 100px;  margin-top: 10px;" /> </div>
                    <span style="font-weight: bold; margin-top: 8px;">{{getFirstLineupPlayers[3].firstName}}</span>
                </div>
            </div>
            <div class="row mt-4">
                <div class="tile-border" style="margin-left: 20px;">
                    <div><img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[2].avatar" style="width: 100px;  margin-top: 10px;" /> </div>
                    <span style="font-weight: bold; margin-top: 8px;">{{getFirstLineupPlayers[2].firstName}}</span>
                </div>
                <div class="tile-border" style="margin-left: 450px;">
                    <div><img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[1].avatar" style="width: 100px;  margin-top: 10px;" /> </div>
                    <span style="font-weight: bold; margin-top: 8px;">{{getFirstLineupPlayers[1].firstName}}</span>
                </div>
            </div>
            <div class="row mt-4">
                <div class="tile-border" style="margin-left: 310px;">
                    <div><img v-bind:src="'data:image/jpeg;base64,'+getFirstLineupPlayers[0].avatar" style="width: 100px;margin-top: 10px;" /></div>
                    <span style="font-weight: bold; margin-top: 8px; ">{{getFirstLineupPlayers[0].firstName}}</span>
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
    display:  flex;
    
}

.court-background-image{
    background-image: url('../../../../assets/court.png')
}

.tile-border {
    border: 1px solid  rgb(243, 234, 234); 
    height: 150px; 
    width: 150px;
    border-radius: 5px;
    background-color: rgb(243, 234, 234);
    text-align: center;
    opacity: 0.8;
}
</style>