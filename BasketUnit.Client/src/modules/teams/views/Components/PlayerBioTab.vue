<template>
  <div class="content">
    <div class="printers">
      <div class="row mt-4">
        <div class="col-3">
          <!-- informacje -->
          <div class="player-tile">
            <img
              v-if="Avatar.length"
              style="width: 250px;"
              v-bind:src="'data:image/jpeg;base64,' + Avatar"
            />
            <h2>{{ FirstName }} {{ LastName }}</h2>
          </div>
          <div>
            <h4>{{ Position + " " }} #{{ PlayerNumber }}</h4>
          </div>
        </div>
        <div class="col-3">
          <div>
            <div class="personal-info">Data urodzenia: {{ BirthDate }}</div>
          </div>
          <div>
            <div class="personal-info">Wzrost [cm]: {{ Height }}</div>
          </div>
          <div>
            <div class="personal-info">Waga [kg]: {{ Weight }}</div>
          </div>
          <div>
            <DxButton
              :use-submit-behavior="false"
              type="normal"
              class="mt-2"
              styling-mode="outlined"
              text="Historia kontuzji"
              @click="showInjuriesPopup"
            />
          </div>
        </div>
        <div class="col-3">
          
          <div>
            <h4>Narodowość:</h4>
          <h4>{{ " " + Nationality }}</h4>
          <img
            v-if="NationalityFlag.length"
            style="width: 150px;"
            v-bind:src="'data:image/jpeg;base64,' + NationalityFlag"
          />
          </div>
        </div>
        <div class="col-3">
          <div>
            <h4>Uniwersytet:</h4>
            <h4>{{ " " + College }}</h4>
            <img
              v-if="CollegeBadge.length"
              style="width: 150px;"
              v-bind:src="'data:image/jpeg;base64,' + CollegeBadge"
            />
          </div>
        </div>
      </div>
      <div class="row mt-2">
        <div class="col-12">
          <h3 class="little-header">Statystyki z ostatnich meczów</h3>
          <DxDataGrid
            id="gridContainer"
            :data-source="getLastGamesStats"
            key-expr="opponent"
            :allow-column-reordering="true"
            :row-alternation-enabled="true"
            class="main-datagrid"
          >
            <DxColumn
              data-field="opponent"
              alignment="left"
              caption="Przeciwko"
              data-type="string"
            />
            <DxColumn
              data-field="gameTime"
              alignment="center"
              caption="Data"
              data-type="date"
            />
            <DxColumn
              data-field="points"
              alignment="center"
              caption="Punkty"
              data-type="number"
            />
            <DxColumn
              data-field="assists"
              alignment="center"
              caption="Asysty"
              data-type="number"
            />
            <DxColumn
              data-field="rebounds"
              alignment="center"
              caption="Zbiórki"
              data-type="number"
            />
            <DxColumn
              data-field="steals"
              alignment="center"
              caption="Przechwyty"
              data-type="number"
            />
            <DxColumn
              data-field="blocks"
              alignment="center"
              caption="Bloki"
              data-type="number"
            />
            <DxColumn
              data-field="fouls"
              alignment="center"
              caption="Faule"
              data-type="number"
            />
            <DxColumn
              data-field="gameId"
              alignment="center"
              caption=""
              cell-template="actionsCellTemplate"
              :allow-search="false"
              :allow-filtering="false"
              width="100"
            />
            <div slot="actionsCellTemplate" slot-scope="{ data }">
              <DxButton
                @click="function() {$router.push({name: 'games.details',params: { gameId: data.data.gameId }, });}"
                hint="Szczegóły"
                title="Szczegóły"
                icon="fas fa-chevron-right"
                class="datagrid-button"
                type="normal"
              />
            </div>
          </DxDataGrid>
        </div>
      </div>
    </div>
    <div class="d-flex end-xs mt-5 mb-4">
      <DxButton
        :use-submit-behavior="false"
        type="normal"
        styling-mode="outlined"
        text="Wróć"
        @click="function() {$router.push({ name: 'team.index' });}"
      />
    </div>

    <!-- Injuries popup -->
    <DxPopup
      :visible.sync="popupVisible"
      :drag-enabled="false"
      :show-title="true"
      :width="500"
      height="auto"
      class="popup"
      :close-on-outside-click="true"
      title-template="titleTemplate"
    >
      <div slot="titleTemplate">
        <h3 class="popup-title-text">Kontuzje</h3>
      </div>
      <InjuriesPopup
        :playerInjuries="getInjuries"
        @closeAdd="onPopupClose"
      ></InjuriesPopup>
    </DxPopup>
  </div>
</template>

<script>
import { DxButton, DxPopup } from "devextreme-vue";
import { DxDataGrid, DxColumn } from "devextreme-vue/data-grid";
// import {
//     DxChart,
//     DxSeries,
//     DxCommonSeriesSettings,
//     DxLabel,
//     DxFormat
// } from 'devextreme-vue/chart';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";

import InjuriesPopup from "./InjuriesPopup.vue";

const store = "TeamPlayerDetailsStore";
export default {
  name: "playerDetails",
  data() {
    return {
      popupVisible: false,
    };
  },
  computed: {
    ...mapGetters(store, [
      "getForm",
      "getLastGamesStats",
      "getDataToCharts",
      "getInjuries",
    ]),
    ...mapFields(store, [
      "detailsForm.Id",
      "detailsForm.FirstName",
      "detailsForm.LastName",
      "detailsForm.BirthDate",
      "detailsForm.Team",
      "detailsForm.PlayerNumber",
      "detailsForm.Avatar",
      "detailsForm.Nationality",
      "detailsForm.Position",
      "detailsForm.College",
      "detailsForm.CollegeBadge",
      "detailsForm.NationalityFlag",
      "detailsForm.Height",
      "detailsForm.Weight",
      "detailsForm.Injury",
      "detailsForm.InjuredTo",
      "detailsForm.IsInjured",
    ]),
  },
  methods: {
    ...mapActions(store, [
      "setDetails",
      "setLastGamesStats",
      "setDataToChart",
      "setInjuries",
    ]),
    showInjuriesPopup() {
      this.popupVisible = true;
    },
    onPopupClose() {
      this.popupVisible = false;
    },
  },
  mounted() {
    this.setDetails();
    this.setLastGamesStats();
    this.setDataToChart();
    this.setInjuries();
  },
  components: {
    DxPopup,
    DxButton,
    DxDataGrid,
    DxColumn,
    // DxChart,
    // DxSeries,
    // DxCommonSeriesSettings,
    // DxLabel,
    // DxFormat,
    InjuriesPopup,
  },
};
</script>

<style scoped>
.player-tile {
}
.player-tile img {
  border: 1px solid #4d4d4d;;
  border-radius: 5px;
}
.personal-info{
  font-size: 18px;
}
.little-header{
  color: #4d4d4d;
}
</style>
