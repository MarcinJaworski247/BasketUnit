<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Zespoły
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
        :data-source="getTeamsList"
        :show-borders="true"
        key-expr="Id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn
            data-field="Badge"
            caption=""
            cell-template="badgeCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            alignment="center"
            width="100"/>
        <div slot="badgeCellTemplate" slot-scope="{ data }">
            <img v-bind:src="data.Badge" />
        </div>
        <DxColumn 
            data-field="Name"
            alignment="left"
            caption="Nazwa"
            data-type="string">
        </DxColumn>
        <DxColumn 
            data-field="City"
            data-type="string"
            alignment="left"
            caption="Miasto" />
        <DxColumn 
            data-field="ArenaId"
            alignment="left"
            caption="Arena">
            <DxLookup
                :data-source="getArenas"
                value-expr="Value"
                display-expr="Text" />
        </DxColumn>
        <DxColumn 
            data-field="Coach"
            alignment="left"
            caption="Trener">
            <DxLookup
                :data-source="getCoaches"
                value-expr="Value"
                display-expr="Text" />
        </DxColumn>
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
            <span @click="showDeletePopup(data)" title="Usuń" class="ml-3 fas fa-trash" />
        </div>
    </DxDataGrid>

    <div class="d-flex end-xs mt-5">
        <DxButton
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function(){ $router.push({ name: `administration.clubs.index` }) }" />
    </div>

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
            @click="deleteTeam()" />
    </DxPopup>

</div>
</template>

<script>
import { 
    DxDataGrid, 
    DxColumn, 
    DxFilterRow, 
    DxButton 
} from "devextreme-vue";
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "AdministrationTeamStore";

export default {
    name: "teams",
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
        };
    },
    created() {
    },
    computed: {
        ...mapGetters(store, ["getTeamsList", "getArenas", "getCoaches"]),
        ...mapFields(store, ["idToDelete"])
    },
    methods: {
        ...mapActions(store, ["setTeamsList", "setArenas", "setCoaches"]),
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
                    this.setTeamsList();
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
        this.setTeamsList();
        this.setArenas();
        this.setCoaches();
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxFilterRow,
        DxButton,
        addForm,
        editForm
    }
};
</script>