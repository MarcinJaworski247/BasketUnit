<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <!-- <h3 class="main-header-title"> Trenerzy </h3> -->
        <DxButton 
            :use-submit-behavior="false"
            type="default"
            text="Dodaj"
            class="main-tabpanel-button"
            @click="showAddPopup" />
    </div>
    
    <DxDataGrid 
        id="gridContainer"
        :data-source="getCoachesList"
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
            data-type="string"/>
        <DxColumn 
            data-field="lastName"
            alignment="left"
            caption="Nazwisko"
            data-type="string"/>
        <DxColumn 
            data-field="nationalityId"
            alignment="left"
            caption="Narodowość">
            <DxLookup
                :data-source="getNationalities"
                value-expr="value"
                display-expr="text"/>
        </DxColumn>
        <DxColumn 
            data-field="birthDate"
            data-type="date"
            alignment="center"
            caption="Data urodzenia" />
        <DxColumn 
            data-field="teamId"
            alignment="left"
            caption="Drużyna">
            <DxLookup
                :data-source="getTeams"
                value-expr="value"
                display-expr="text" />
        </DxColumn>
        <DxColumn
            data-field="experienceYears"
            alignment="center"
            caption="Lata doświadczenia"
            data-type="number"/>
        <DxPager :allowed-page-sizes="pageSizes" :show-page-size-selector="true" />
        <DxPaging :page-size="10" />
        <DxColumn 
            data-field="id"
            alignment="center"
            caption=""
            cell-template="actionsCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            width="100" />
        <div slot="actionsCellTemplate" slot-scope="{ data }">
            <DxButton @click="showEditPopup(data)" hint="Edytuj" title="Edytuj" icon="fas fa-pen" class="datagrid-button" type="normal"/>
            <DxButton @click="showDeletePopup(data)" hint="Usuń" title="Usuń" icon="fas fa-trash" class="ml-3 datagrid-button" type="normal"/>
        </div>
    </DxDataGrid>

    <!-- <div class="d-flex end-xs mt-5">
        <DxButton
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function(){ $router.push({ name: 'administration.humanResources.index' }) }"/>
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
            <h3 class="popup-title-text">Dodaj trenera</h3>
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
            @click="deleteCoachMethod()" />
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
const store = "AdministrationCoachStore";
const editStore = "AdministrationEditCoachStore";

export default {
    name: "coaches",
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
        }
    },
    created() {
    },
    computed: {
        ...mapGetters(store, ["getCoachesList", "getTeams", "getNationalities"]),
        ...mapFields(store, ["idToDelete"])
    },
    methods: {      
        ...mapActions(store, ["setCoachesList", "setTeams", "setNationalities", "deleteCoach"]),
        ...mapActions(editStore, ["setCoachDetails"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
        },
        showEditPopup(options){
            this.setCoachDetails(options.data.id);
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
        deleteCoachMethod() {
            this.deleteCoach();
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
        this.setCoachesList();
        this.setTeams();
        this.setNationalities();
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