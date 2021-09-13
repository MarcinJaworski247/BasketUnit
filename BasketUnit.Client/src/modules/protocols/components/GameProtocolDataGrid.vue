<template>
  <div>
    <DxDataGrid
      id="gridContainer"
      :data-source="getGameStatistics"
      :show-borders="true"
      key-expr="id"
      :allow-column-reordering="true"
      :row-alternation-enabled="true"
      class="main-datagrid"
      show-filter-row="true"
    >
      <DxFilterRow :visible="true" :show-operation-chooser="true" />
      <DxColumn
        data-field="fullName"
        caption="Zawodnik"
        alignment="left"
        data-type="string"
        width="200"
      />
      <DxColumn
        data-field="team"
        caption="Drużyna"
        alignment="left"
        data-type="string"
        width="200"
      />
      <DxColumn
        data-field="points"
        caption="Punkty"
        alignment="center"
        data-type="number"
      />
      <DxColumn
        data-field="assists"
        caption="Asysty"
        alignment="center"
        data-type="number"
      />
      <DxColumn
        data-field="rebounds"
        caption="Zbiórki"
        alignment="center"
        data-type="number"
      />
      <DxColumn
        data-field="steals"
        caption="Przechwyty"
        alignment="center"
        data-type="number"
      />
      <DxColumn
        data-field="blocks"
        caption="Bloki"
        alignment="center"
        data-type="number"
      />
      <DxColumn
        data-field="fouls"
        caption="Faule"
        alignment="center"
        data-type="number"
      />
      <DxColumn
        data-field="id"
        alignment="center"
        caption=""
        cell-template="actionsCellTemplate"
        :allow-search="false"
        :allow-filtering="false"
        width="100"
      />
      <div slot="actionsCellTemplate" slot-scope="{ data }">
        <DxButton
          @click="showProtocolEditPopup(data)"
          icon="fas fa-chevron-right"
        />
      </div>
    </DxDataGrid>

    <DxPopup
      id="editPopup"
      :visible.sync="popupVisible"
      :drag-enabled="false"
      :width="500"
      :title="FullName"
      height="auto"
      class="popup"
    >
      <div class="form-group">
        <PlayerStatisticsForm />
        <div class="popup-bottom mt-4">
          <DxButton
            :use-submit-behavior="false"
            styling-mode="outlined"
            type="normal"
            text="Anuluj"
            @click="hideEditPopup"
          />
          <DxButton
            :use-submit-behavior="false"
            type="default"
            class="ml-1"
            text="Zapisz"
            @click="saveGamePlayerStatisticsMethod"
          />
        </div>
      </div>
    </DxPopup>
  </div>
</template>

<script>
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";

// DevExtreme
import notify from "devextreme/ui/notify";
import { DxButton, DxPopup } from "devextreme-vue";
import { DxDataGrid, DxColumn, DxFilterRow } from "devextreme-vue/data-grid";

// store
const STORE = "ProtocolsEditStore";

// components
import PlayerStatisticsForm from "./PlayerStatisticsForm.vue";

export default {
  data() {
    return {
      popupVisible: false,
    };
  },
  computed: {
    ...mapGetters(STORE, ["getGameStatistics"]),
    ...mapFields(STORE, ["editForm.FullName"]),
  },
  methods: {
    ...mapActions(STORE, [
      "setGameStatistics",
      "setGamePlayerStatistics",
      "saveGamePlayerStatistics",
    ]),
    showProtocolEditPopup(options) {
      this.setGamePlayerStatistics(options.data.id);
      this.popupVisible = true;
    },
    saveGamePlayerStatisticsMethod() {
      this.saveGamePlayerStatistics();
      this.popupVisible = false;
      this.showSuccessNotify();
    },
    hideEditPopup() {
      this.popupVisible = false;
    },
    showSuccessNotify() {
      this.$nextTick(() => {
        notify("Zapisano", "success", 500);
      });
    },
  },
  mounted() {
    this.setGameStatistics();
  },
  components: {
    DxButton,
    DxDataGrid,
    DxColumn,
    DxFilterRow,
    DxPopup,
    PlayerStatisticsForm,
  },
};
</script>
