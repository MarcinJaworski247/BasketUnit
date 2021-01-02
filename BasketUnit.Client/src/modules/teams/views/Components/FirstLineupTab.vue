<template>
  <div class="content">
    <div class="printers">
      <div class="main-header">
        <span class="main-header-title">Pierwsza piątka</span>
      </div>
      <div class="row mt-2">
        <div class="col-3 pr-4">
          <h4>Rozgrywający</h4>
          <DxSelectBox
            v-model="pointGuardId"
            :data-source="getPointGuards"
            value-expr="value"
            display-expr="text"
            class="mb-2"
          />
          <h4>Rzucający obrońca</h4>
          <DxSelectBox
            v-model="shootingGuardId"
            :data-source="getShootingGuards"
            value-expr="value"
            display-expr="text"
            class="mb-2"
          />
          <h4 class="mt-2">Skrzydłowy</h4>
          <DxSelectBox
            v-model="smallForwardId"
            :data-source="getSmallForwards"
            value-expr="value"
            display-expr="text"
            class="mb-2"
          />
          <h4 class="mt-2">Silny skrzydłowy</h4>
          <DxSelectBox
            v-model="powerForwardId"
            :data-source="getPowerForwards"
            value-expr="value"
            display-expr="text"
            class="mb-2"
          />
          <h4 class="mt-2">Center</h4>
          <DxSelectBox
            v-model="centerId"
            :data-source="getCenters"
            value-expr="value"
            display-expr="text"
          />
        </div>
        <div class="col-9 court-wrapper court-background-image">
          <div>
            <div class="row">
              <div class="tile-border" style="margin-left: 20px;">
                <div>
                  <img
                    v-bind:src="
                      'data:image/jpeg;base64,' +
                        getFirstLineupPlayers[4].avatar
                    "
                    style="width: 100px;  margin-top: 10px;"
                  />
                </div>
                <span style="font-weight: bold;margin-top: 8px;">
                  {{ getFirstLineupPlayers[4].firstName }}</span
                >
              </div>
              <div class="tile-border" style="margin-left: 450px;">
                <div>
                  <img
                    v-bind:src="
                      'data:image/jpeg;base64,' +
                        getFirstLineupPlayers[3].avatar
                    "
                    style="width: 100px;  margin-top: 10px;"
                  />
                </div>
                <span style="font-weight: bold; margin-top: 8px;">{{
                  getFirstLineupPlayers[3].firstName
                }}</span>
              </div>
            </div>
            <div class="row mt-4">
              <div class="tile-border" style="margin-left: 20px;">
                <div>
                  <img
                    v-bind:src="
                      'data:image/jpeg;base64,' +
                        getFirstLineupPlayers[2].avatar
                    "
                    style="width: 100px;  margin-top: 10px;"
                  />
                </div>
                <span style="font-weight: bold; margin-top: 8px;">{{
                  getFirstLineupPlayers[2].firstName
                }}</span>
              </div>
              <div class="tile-border" style="margin-left: 450px;">
                <div>
                  <img
                    v-bind:src="
                      'data:image/jpeg;base64,' +
                        getFirstLineupPlayers[1].avatar
                    "
                    style="width: 100px;  margin-top: 10px;"
                  />
                </div>
                <span style="font-weight: bold; margin-top: 8px;">{{
                  getFirstLineupPlayers[1].firstName
                }}</span>
              </div>
            </div>
            <div class="row mt-4">
              <div class="tile-border" style="margin-left: 310px;">
                <div>
                  <img
                    v-bind:src="
                      'data:image/jpeg;base64,' +
                        getFirstLineupPlayers[0].avatar
                    "
                    style="width: 100px;margin-top: 10px;"
                  />
                </div>
                <span style="font-weight: bold; margin-top: 8px; ">{{
                  getFirstLineupPlayers[0].firstName
                }}</span>
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
  </div>
</template>
<script>
import { DxSelectBox, DxButton } from "devextreme-vue";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapState } from "vuex";
import notify from "devextreme/ui/notify";
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
      "getFirstLineupPlayers",
    ]),
    ...mapFields(store, [
      "editForm.pointGuardId",
      "editForm.shootingGuardId",
      "editForm.smallForwardId",
      "editForm.powerForwardId",
      "editForm.centerId",
    ]),
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
      "setFirstLineupPlayers",
    ]),
    saveFirstLineupMethod() {
      this.saveFirstLineup().then(() => {
        this.showSuccessNotify();
      });
    },
    showSuccessNotify() {
      this.$nextTick(() => {
        notify("Zapisano", "success", 500);
      });
    },
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
    DxButton,
  },
};
</script>
<style scoped>
.court-wrapper {
  display: flex;
}

.court-background-image {
  background-image: url("../../../../assets/court.png");
  background-repeat: no-repeat;
}

.tile-border {
  border: 1px solid rgb(243, 234, 234);
  height: 150px;
  width: 150px;
  border-radius: 50px;
  background-color: rgb(243, 234, 234);
  text-align: center;
  /* opacity: 0.8; */
}
.main-header-title{
  color: rgb(31, 31, 131);
  font-size: 32px;
}
</style>
