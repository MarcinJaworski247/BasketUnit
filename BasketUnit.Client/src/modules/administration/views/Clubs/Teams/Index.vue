<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <!-- <h3 class="main-header-title"> Zespoły </h3> -->
        <DxButton 
            :use-submit-behavior="false"
            type="default"
            text="Dodaj"
            class="main-tabpanel-button"
            @click="showAddPopup" />
        
    </div>
    
    <DxDataGrid
        id="gridCOntainer"
        :data-source="getTeamsList"
        :remote-operations="true"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn
            data-field="badge"
            caption=""
            cell-template="badgeCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            alignment="center"
            width="100"/>
        <div slot="badgeCellTemplate" slot-scope="{ data }">
            <img v-bind:src="data.badge" />
        </div>
        <DxColumn 
            data-field="city"
            data-type="string"
            alignment="left"
            caption="Miasto" />
        <DxColumn 
            data-field="name"
            alignment="left"
            caption="Nazwa"
            data-type="string"/>
        <DxColumn 
            data-field="arenaId"
            alignment="left"
            caption="Arena">
            <DxLookup
                :data-source="getArenas"
                value-expr="value"
                display-expr="text" />
        </DxColumn>
        <DxColumn 
            data-field="coachId"
            alignment="left"
            caption="Trener">
            <DxLookup
                :data-source="getCoaches"
                value-expr="value"
                display-expr="text" />
        </DxColumn>
        <DxColumn 
            alignment="center"
            data-field="id"
            caption=""
            cellTemplate="teamActionsCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            width=100 />
        <DxPager :allowed-page-sizes="pageSizes" :show-page-size-selector="true" />
        <DxPaging :page-size="10" />
        <div slot="teamActionsCellTemplate" slot-scope="{ data }">
            <DxButton @click="showEditPopupMethod(data)" hint="Edytuj" title="Edytuj" icon="fas fa-pen" class="datagrid-button" type="normal" styling-mode="text" />
        </div>
    </DxDataGrid>

    <!-- <div class="d-flex end-xs mt-5">
        <DxButton
            :use-submit-behavior="false"
            type="normal"
            styling-mode="outlined"
            text="Wróć"
            @click="function(){ $router.push({ name: `administration.clubs.index` }) }" />
    </div> -->

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
            <h3 class="popup-title-text">Dodaj zespół</h3>
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
            @click="deleteTeamMethod()" />
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
    DxPaging,
    DxLookup 
  } from 'devextreme-vue/data-grid'
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "AdministrationTeamStore";
const editStore = "AdministrationEditTeamStore";

export default {
    name: "teams",
    data() {
        return {
            pageSizes: [10, 20, 30],
            addPopupOptions: {
                popupVisible: false
            },
            editPopupOptions: {
                popupVisible: false
            },
            deletePopupOptions: {
                popupVisible: false
            }
        };
    },
    created() {
    },
    computed: {
        ...mapGetters(store, ["getTeamsList", "getArenas", "getCoaches"]),
        ...mapFields(store, ["idToDelete", "arenas"])
    },
    methods: {
        ...mapActions(store, ["setTeamsList", "setArenas", "setCoaches", "deleteTeam"]),
        ...mapActions(editStore, ["setTeamDetails"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
        },
        showEditPopupMethod(options){
            debugger
            this.setTeamDetails(options.data.id);
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
        deleteTeam() {
            this.deleteTeam();
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
        this.setTeamsList();
        this.setArenas();
        this.setCoaches();
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
        addForm,
        DxLookup
    }
};
</script>