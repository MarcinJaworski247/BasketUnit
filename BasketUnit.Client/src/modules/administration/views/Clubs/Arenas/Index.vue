<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <DxButton 
            :use-submit-behavior="false"
            type="default"
            text="Dodaj"
            class="main-tabpanel-button"
            @click="showAddPopup" />
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="getArenasList"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
        width="1000">
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn 
            data-field="name"
            alignment="left"
            caption="Nazwa"
            data-type="string">
        </DxColumn>
        <DxColumn 
            data-field="address"
            data-type="string"
            alignment="left"
            caption="Adres" />
        <DxColumn
            data-field="capacity"
            data-type="number"
            alignment="center"
            caption="Pojemność" />
        <DxColumn 
            alignment="center"
            data-field="id"
            caption=""
            cellTemplate="actionsCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            width=100 />
        <DxPaging :page-size="10" />
        <div slot="actionsCellTemplate" slot-scope="{ data }">
            <DxButton @click="showEditPopup(data)" hint="Edytuj" title="Edytuj" icon="fas fa-pen" class="datagrid-button" type="normal" />
            <DxButton @click="showDeletePopup(data)" hint="Usuń" title="Usuń" icon="fas fa-trash" class="ml-3 datagrid-button" type="normal" />
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
        title-template="titleTemplate">
        <div slot="titleTemplate">
            <h3 class="popup-title-text">Dodaj arenę</h3>
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
        title-template="titleTemplate">
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
        width="280">
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideDeletePopup()" />
        <DxButton
            text="Usuń"
            type="danger"
            styling-mode="outlined"
            @click="deleteArenaMethod()" />
    </DxPopup>

</div>
</template>

<script>
import 
{ 
    DxPopup,
    DxButton
} from 'devextreme-vue';
import {
    DxDataGrid, 
    DxColumn, 
    DxFilterRow,
    DxPaging 
  } from 'devextreme-vue/data-grid'
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "AdministrationArenaStore";
const editStore = "AdministrationEditArenaStore";

export default {
    name: "arenas",
    data() {
        return {
            pageSizes: [10, 15, 20],
            addPopupOptions: {
                popupVisible: false
            },
            editPopupOptions: {
                popupVisible: false
            },
            deletePopupOptions: {
                popupVisible: false
            }
        }
    },
    created() {
        this.setArenasList();
    },
    computed: {
        ...mapGetters(store, ["getArenasList"]),
        ...mapFields(store, ["idToDelete"])  
    },
    methods: {
        
        ...mapActions(store, ["setArenasList", "deleteArena"]),
        ...mapActions(editStore, ["setArenaDetails"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
        },
        showEditPopup(options){
            this.setArenaDetails(options.data.id);
            this.editPopupOptions.popupVisible = true;
        },
        onEditPopupClose(){
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
        deleteArenaMethod() {
            this.deleteArena();
            this.deletePopupOptions.popupVisible = false;
            this.showDeletedNotify();
            this.idToDelete = null;
        },
        showDeletedNotify() {
            this.$nextTick(() => {
                notify("Usunięto", "warning", 500);
            });
        }      
    },
    components: {
        DxPopup,
        DxButton,
        DxDataGrid, 
        DxColumn, 
        DxFilterRow,
        DxPaging,
        editForm,
        addForm
    }
};
</script>