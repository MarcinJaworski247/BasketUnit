<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Zawodnicy </h3>
        <DxButton
            :use-submit-behavior="false"
            type="default"
            text="Dodaj"
            class="main-tabpanel-button"
            @click="showAddPopup" />
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="getPlayersList"
        :show-borders="true"
        key-expr="Id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn 
            data-field="Avatar"
            caption=""
            cell-template="avatarCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            alignment="center"
            width="100"
        />
        <div slot="avatarCellTemplate" slot-scope="{ data }">
            <img v-bind:src="data.Avatar" />
        </div>
        <DxColumn 
            data-field="FullName"
            alignment="left"
            caption="Imię i nazwisko"
            data-type="string"
            cellTemplate="nameHyperlinkTemplate" />
        <div slot="nameHyperlinkTemplate" slot-scope="{ data }">
            <router-link
                :to="{ name: 'administration.humanResources.players.details', params: { id: data.value } }">
                {{ data.Value }}
            </router-link>
        </div>
        <DxColumn 
            data-field="Nationality"
            data-type="string"
            alignment="left"
            caption="Narodowość" />
        <DxColumn 
            data-field="BirthDate"
            data-type="date"
            alignment="center"
            caption="Data urodzenia" />
        <DxColumn 
            data-field="PositionId"
            alignment="left"
            caption="Pozycja">
            <DxLookup
                :data-source="getPositions"
                value-expr="Value"
                display-expr="Text" />
        </DxColumn>
        <DxColumn 
            data-field="Team"
            alignment="left"
            caption="Drużyna">
            <DxLookup
                :data-source="getTeams"
                value-expr="Value"
                display-expr="Text" />
        </DxColumn>
        <DxColumn 
            data-field="Id"
            alignment="center"
            caption=""
            cell-template="actionsCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            width="100"
        />
        <div slot="actionsCellTemplate" slot-scope="{ data }">
            <router-link
                class="datagrid-btn"
                :to="{ name: 'administration.humanResources.players.details', params: { id: data.value } }"
            >
                <i hint="Szczegóły" class="fas fa-chevron-right"></i>
            </router-link>
            <span @click="showEditPopup(data)" title="Edytuj" class="fas fa-pen" />
            <span @click="showDeletePopup(data)" title="Usuń" class="ml-3 fas fa-trash" />
        </div>
        <DxPager :allowed-page-sizes="pageSizes" :show-page-size-selector="true" />
        <DxPaging :page-size="5" />
    </DxDataGrid>

    <div class="d-flex end-xs mt-5">
        <DxButton
            :use-submit-behavior="false"
            type="normal"
            styling-mode="outlined"
            text="Wróć"
            @click="function(){ $router.push({ name: 'administration.humanResources.index' }) }"/>
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
import 
{ 
    DxDataGrid, 
    DxColumn, 
    DxFilterRow, 
    DxButton,
    DxPager,
    DxPaging
} from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "HumanResourcesPlayerStore";

export default {
    name: "players",
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
        ...mapGetters(store, ["getPlayersList", "getTeams", "getPositions"]),
        ...mapFields(store, ["idToDelete"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setTeams", "setPositions", "setDetails"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
            this.setPlayersList();
        },
        showEditPopup(options){
            this.setDetails(options.data.Id);
            this.editPopupOptions.popupVisible = true;
        },
        onEditPopupClose(){
            this.editPopupOptions.popupVisible = false;
            this.setPlayersList();
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
                    this.setPlayersList();
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
        this.setPlayersList();
        this.setTeams();
        this.setPositions();
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxFilterRow,
        DxButton,
        DxPager,
        DxPaging
    }
};
</script>