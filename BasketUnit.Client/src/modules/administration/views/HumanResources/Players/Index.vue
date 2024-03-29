<template>
  <div class="content">
    <div class="printers">
      <div class="main-header">
        <DxButton
          :use-submit-behavior="false"
          type="default"
          text="Dodaj"
          class="main-tabpanel-button"
          @click="showAddPopup"
        />
      </div>

      <DxDataGrid
        id="gridContainer"
        :data-source="getPlayersList"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
      >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn
          data-field="avatar"
          caption=""
          cell-template="avatarCellTemplate"
          :allow-search="false"
          :allow-filtering="false"
          alignment="center"
          width="100"
        />
        <div slot="avatarCellTemplate" slot-scope="{ data }">
          <img
            v-if="data.value.length"
            style="width: 60px; margin: auto; display: block;"
            v-bind:src="'data:image/jpeg;base64,' + data.value"
          />
        </div>
        <DxColumn
          data-field="fullName"
          alignment="left"
          caption="Imię i nazwisko"
          data-type="string"
        />
        <DxColumn
          data-field="nationalityId"
          alignment="left"
          caption="Narodowość"
        >
          <DxLookup
            :data-source="getNationalities"
            value-expr="value"
            display-expr="text"
          />
        </DxColumn>
        <DxColumn
          data-field="birthDate"
          data-type="date"
          alignment="center"
          caption="Data urodzenia"
          format="dd/MM/yyyy"
        />
        <DxColumn data-field="positionId" alignment="left" caption="Pozycja">
          <DxLookup
            :data-source="getPositions"
            value-expr="value"
            display-expr="text"
          />
        </DxColumn>
        <DxColumn data-field="teamId" alignment="left" caption="Drużyna">
          <DxLookup
            :data-source="getTeams"
            value-expr="value"
            display-expr="text"
          />
        </DxColumn>
        <DxColumn
          data-field="playerNumber"
          alignment="center"
          caption="Numer"
          data-type="number"
        />
        <DxColumn data-field="collegeId" alignment="left" caption="Uniwersytet">
          <DxLookup
            :data-source="getColleges"
            value-expr="value"
            display-expr="text"
          />
        </DxColumn>
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
            @click="showPlayerEditPopup(data)"
            hint="Edytuj"
            title="Edytuj"
            icon="fas fa-pen"
            class="datagrid-button"
            type="normal"
          />
          <DxButton
            @click="showDeletePopup(data)"
            hint="Usuń"
            title="Usuń"
            icon="fas fa-trash"
            class="ml-3 datagrid-button"
            type="normal"
          />
        </div>
        <DxPaging :page-size="10" />
      </DxDataGrid>
    </div>

    <!-- add popup -->
    <DxPopup
      id="addPopup"
      :visible.sync="addPopupOptions.popupVisible"
      :drag-enabled="false"
      :show-title="true"
      :width="500"
      height="auto"
      class="popup"
      title-template="titleTemplate"
    >
      <div slot="titleTemplate">
        <h3 class="popup-title-text">Dodaj zawodnika</h3>
      </div>
      <addForm @closeAdd="onAddPopupClose"></addForm>
    </DxPopup>

    <!-- edit popup -->
    <DxPopup
      id="editPopup"
      :visible.sync="editPopupOptions.popupVisible"
      :drag-enabled="false"
      :show-title="true"
      :width="500"
      height="auto"
      class="popup"
      title-template="titleTemplate"
    >
      <div slot="titleTemplate">
        <h3 class="popup-title-text">Edycja</h3>
      </div>
      <editForm @closeEdit="onEditPopupClose"></editForm>
    </DxPopup>

    <!-- delete popup -->
    <DxPopup
      :visible.sync="deletePopupOptions.popupVisible"
      :drag-enabled="false"
      :show-title="true"
      title="Czy na pewno usunąć?"
      height="150"
      width="280"
    >
      <DxButton
        text="Anuluj"
        type="default"
        styling-mode="outlined"
        @click="hideDeletePopup()"
      />
      <DxButton
        text="Usuń"
        type="danger"
        styling-mode="outlined"
        @click="deletePlayerMethod()"
      />
    </DxPopup>
  </div>
</template>

<script>
import { DxPopup, DxButton } from "devextreme-vue";
import {
  DxDataGrid,
  DxColumn,
  DxFilterRow,
  DxPaging,
  DxLookup,
} from "devextreme-vue/data-grid";
import notify from "devextreme/ui/notify";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "AdministrationPlayerStore";
const editStore = "AdministrationEditPlayerStore";

export default {
  name: "players",
  data() {
    return {
      pageSizes: [10, 20, 30],
      addPopupOptions: {
        popupVisible: false,
      },
      editPopupOptions: {
        popupVisible: false,
      },
      deletePopupOptions: {
        popupVisible: false,
      },
    };
  },
  computed: {
    ...mapGetters(store, [
      "getPlayersList",
      "getTeams",
      "getPositions",
      "getNationalities",
      "getColleges",
    ]),
    ...mapFields(store, ["idToDelete"]),
  },
  methods: {
    ...mapActions(store, [
      "setPlayersList",
      "setTeams",
      "setPositions",
      "setNationalities",
      "deletePlayer",
      "setColleges",
    ]),
    ...mapActions(editStore, ["setPlayerDetails"]),
    showAddPopup() {
      this.addPopupOptions.popupVisible = true;
    },
    onAddPopupClose() {
      this.addPopupOptions.popupVisible = false;
    },
    showPlayerEditPopup(options) {
      this.setPlayerDetails(options.data.id);
      this.editPopupOptions.popupVisible = true;
    },
    onEditPopupClose() {
      this.editPopupOptions.popupVisible = false;
    },
    showDeletePopup(data) {
      this.deletePopupOptions.popupVisible = true;
      this.idToDelete = data.value;
    },
    hideDeletePopup() {
      this.deletePopupOptions.popupVisible = false;
      this.idToDelete = null;
    },
    deletePlayerMethod() {
      this.deletePlayer();
      this.deletePopupOptions.popupVisible = false;
      this.showDeletedNotify();
      this.idToDelete = null;
    },
    showDeletedNotify() {
      this.$nextTick(() => {
        notify("Usunięto", "warning", 500);
      });
    },
  },
  mounted() {
    this.setPlayersList();
    this.setTeams();
    this.setPositions();
    this.setNationalities();
    this.setColleges();
  },
  components: {
    DxPopup,
    DxButton,
    DxDataGrid,
    DxColumn,
    DxFilterRow,
    DxPaging,
    editForm,
    addForm,
    DxLookup,
  },
};
</script>
