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
        :data-source="getNationalities"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
      >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn
          data-field="flag"
          caption=""
          cell-template="badgeCellTemplate"
          :allow-search="false"
          :allow-filtering="false"
          alignment="center"
          width="100"
        />
        <div slot="badgeCellTemplate" slot-scope="{ data }">
          <img
            v-if="data.value.length"
            style="width: 60px; margin: auto; display: block;"
            v-bind:src="'data:image/jpeg;base64,' + data.value"
          />
        </div>
        <DxColumn
          data-field="name"
          alignment="left"
          caption="Nazwa"
          data-type="string"
        >
        </DxColumn>
        <DxColumn
          alignment="center"
          data-field="id"
          caption=""
          cellTemplate="actionsCellTemplate"
          :allow-search="false"
          :allow-filtering="false"
          width="100"
        />
        <DxPaging :page-size="10" />
        <div slot="actionsCellTemplate" slot-scope="{ data }">
          <DxButton
            @click="showEditPopupMethod(data)"
            hint="Edytuj"
            title="Edytuj"
            icon="fas fa-pen"
            class="datagrid-button"
            type="normal"
          />
          <DxButton
            @click="showDeletePopupMethod(data)"
            hint="Usuń"
            title="Usuń"
            icon="fas fa-trash"
            class="ml-3 datagrid-button"
            type="normal"
          />
        </div>
      </DxDataGrid>

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
          <h3 class="popup-title-text">Dodaj narodowość</h3>
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
          @click="deleteNationalityMethod()"
        />
      </DxPopup>
    </div>
  </div>
</template>
<script>
import { DxPopup, DxButton } from "devextreme-vue";
import {
  DxDataGrid,
  DxColumn,
  DxFilterRow,
  DxPaging,
} from "devextreme-vue/data-grid";
import notify from "devextreme/ui/notify";
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "AdministrationNationalityStore";
const editStore = "AdministrationEditNationalityStore";

export default {
  name: "nationalities",
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
    ...mapGetters(store, ["getNationalities"]),
    ...mapFields(store, ["idToDelete"]),
  },
  methods: {
    ...mapActions(store, ["setNationalities", "deleteNationality"]),
    ...mapActions(editStore, ["setDetails"]),
    showAddPopup() {
      this.addPopupOptions.popupVisible = true;
    },
    onAddPopupClose() {
      this.addPopupOptions.popupVisible = false;
    },
    showEditPopupMethod(options) {
      this.setDetails(options.data.id);
      this.editPopupOptions.popupVisible = true;
    },
    onEditPopupClose() {
      this.editPopupOptions.popupVisible = false;
    },
    showDeletePopupMethod(data) {
      this.deletePopupOptions.popupVisible = true;
      this.idToDelete = data.value;
    },
    hideDeletePopup() {
      this.deletePopupOptions.popupVisible = false;
      this.idToDelete = null;
    },
    deleteNationalityMethod() {
      this.deleteNationality();
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
  },
};
</script>
