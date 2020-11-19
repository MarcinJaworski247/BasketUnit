<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Ćwiczenia </h3>
        <DxButton
            :use-submit-behavior="false"
            type="default"
            text="Dodaj"
            class="main-tabpanel-button"
            @click="showAddPopup" />
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="getExcersisesList"
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
            data-type="string" />
        <DxColumn 
            data-field="Description"
            data-type="string"
            alignment="left"
            caption="Opis" />
        <DxColumn 
            data-field="WorkoutTypeId"
            alignment="left"
            caption="Rodzaj treningu">
            <DxLookup
                :data-source="getWorkoutTypes"
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
            @click="function(){ $router.push({ name: 'workouts.index' }) }"/>
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
            <h3 class="popup-title-text">Dodaj ćwiczenie</h3>
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
            @click="deleteExcersise()" />
    </DxPopup>

</div>
</template>

<script>
import 
{ 
    DxPopup,
    DxButton,
    DxLookup
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
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "WorkoutsExcercisesStore";

export default {
    name: "excersises",
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
        ...mapGetters(store, ["getExcersisesList", "getWorkoutTypes"]),
        ...mapFields(store, ["idToDelete"])
    },
    methods: {
        ...mapActions(store, ["setExcersisesList", "setWorkoutTypes", "setDetails"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
            this.setExcersisesList();
        },
        showEditPopup(options){
            this.setExcersiseDetails(options.data.Id);
            this.editPopupOptions.popupVisible = true;
        },
        onEditPopupClose(){
            this.editPopupOptions.popupVisible = false;
            this.setExcersisesList();
        },
        showDeletePopup(data) {
            this.deletePopupOptions.popupVisible = true;
            this.idToDelete = data.value;
        },
        hideDeletePopup() {
            this.deletePopupOptions.popupVisible = false;
            this.idToDelete = null;
        },
        deleteExcersise() {
            this.deleteExcersise()
                .then(() => {
                    this.setExcersisesList();
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
        this.setExcersisesList();
        this.setWorkoutTypes();
    },
    components: {
        DxPopup,
        DxDataGrid, 
        DxColumn, 
        DxFilterRow,
        DxPager,
        DxPaging, 
        DxButton,
        DxLookup,
        addForm,
        editForm
    }
};
</script>