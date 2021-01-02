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
        :data-source="getRefereesList"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
      >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn
          data-field="firstName"
          alignment="left"
          caption="Imię"
          data-type="string"
        />
        <DxColumn
          data-field="lastName"
          alignment="left"
          caption="Nazwisko"
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
        />
        <DxColumn
          data-field="licenseExpirationDate"
          data-type="date"
          alignment="center"
          caption="Data wygaśnięcia licencji"
        />
        <DxPaging :page-size="10" />
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
            @click="showEditPopup(data)"
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
        <h3 class="popup-title-text">Dodaj sędziego</h3>
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
        @click="deleteRefereeMethod()"
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
const store = "AdministrationRefereeStore";
const editStore = "AdministrationEditRefereeStore";

export default {
  name: "referees",
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
    ...mapGetters(store, ["getRefereesList", "getNationalities"]),
    ...mapFields(store, ["idToDelete"]),
  },
  methods: {
    ...mapActions(store, [
      "setRefereesList",
      "setNationalities",
      "deleteReferee",
    ]),
    ...mapActions(editStore, ["setRefereeDetails"]),
    showAddPopup() {
      this.addPopupOptions.popupVisible = true;
    },
    onAddPopupClose() {
      this.addPopupOptions.popupVisible = false;
    },
    showEditPopup(options) {
      this.setRefereeDetails(options.data.id);
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
    deleteReferee() {
      this.deleteReferee();
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
    this.setRefereesList();
    this.setNationalities();
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
