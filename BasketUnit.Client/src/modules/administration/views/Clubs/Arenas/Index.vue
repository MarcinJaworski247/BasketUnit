<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Areny
        </h3>
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
        key-expr="Id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn 
            data-field="Name"
            alignment="left"
            caption="Nazwa"
            data-type="string">
        </DxColumn>
        <DxColumn 
            data-field="Team"
            data-type="string"
            alignment="left"
            caption="Drużyna" />
        <DxColumn 
            data-field="Address"
            data-type="string"
            alignment="left"
            caption="Adres" />
        <DxColumn 
            alignment="center"
            data-field="Id"
            caption=""
            cellTemplate="actionsCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            width=100 />
        <DxPager :allowed-page-sizes="pageSizes" :show-page-size-selector="true" />
        <DxPaging :page-size="5" />
        <div slot="actionsCellTemplate" slot-scope="{ data }">
            <span @click="showEditPopup(data)" title="Edytuj" class="fas fa-pen" />
            <span @click="showDeletePopup(data)" title="Usuń" class=" ml-3 fas fa-trash" />
        </div>
    </DxDataGrid>
    <div class="d-flex end-xs mt-5">
        <DxButton
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function(){ $router.push({ name: 'administration.clubs.index' }) }"/>
    </div>
    </div>  

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
            @click="deleteArena()" />
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
    DxPager,
    DxPaging 
  } from 'devextreme-vue/data-grid'
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
//import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "AdministrationArenaStore";

export default {
    name: "arenas",
    data() {
        return {
            pageSizes: [5, 10, 15],
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
    },
    computed: {
        ...mapGetters(store, ["getArenasList"]),
        ...mapFields(store, ["idToDelete"])  
    },
    methods: {
        
        ...mapActions(store, ["setArenasList"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
            this.setTeamsList();
        },
        showEditPopup(options){
            this.setDetails(options.data.Id);
            this.editPopupOptions.popupVisible = true;
        },
        onEditPopupClose(){
            this.editPopupOptions.popupVisible = false;
            this.setTeamsList();
        },
        showDeletePopup(data) {
            this.deletePopupOptions.popupVisible = true;
            this.idToDelete = data.value;
        },
        hideDeletePopup() {
            this.deletePopupOptions.popupVisible = false;
            this.idToDelete = null;
        },
        deleteTeam() {
            this.deleteTeam()
                .then(() => {
                    this.setArenasList();
                });
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
    mounted() {
        this.setArenasList();
    },
    components: {
        DxPopup,
        DxButton,
        DxDataGrid, 
        DxColumn, 
        DxFilterRow,
        DxPager,
        DxPaging,
        editForm,
        //addForm
    }
};
</script>