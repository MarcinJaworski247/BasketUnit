<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <!-- <h3 class="main-header-title"> Ćwiczenia </h3> -->
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
            data-type="string" />
        <DxColumn 
            data-field="description"
            data-type="string"
            alignment="left"
            caption="Opis" />
        <DxColumn 
            data-field="workoutTypeId"
            alignment="left"
            caption="Rodzaj treningu">
            <DxLookup
                :data-source="getWorkoutTypes"
                value-expr="value"
                display-expr="text" />
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
            <DxButton @click="showEditPopup(data)" hint="Edytuj" title="Edytuj" icon="fas fa-pen" class="datagrid-button" type="normal" />
            <DxButton @click="showDeletePopup(data)" hint="Usuń" title="Usuń" icon="fas fa-trash" class="ml-3 datagrid-button" type="normal" />
        </div>
        <DxPaging :page-size="15" />
    </DxDataGrid>

    <!-- <div class="d-flex end-xs mt-5">
        <DxButton
            :use-submit-behavior="false"
            type="normal"
            styling-mode="outlined"
            text="Wróć"
            @click="function(){ $router.push({ name: 'workouts.index' }) }"/>
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
            @click="deleteExcersiseMethod()" />
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
    DxPaging,    
    DxLookup
  } from 'devextreme-vue/data-grid'
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions, mapMutations } from "vuex";
import addForm from "./Components/Add.vue";
import editForm from "./Components/Edit.vue";
const store = "WorkoutsExcercisesStore";
const editStore = "WorkoutsExcercisesEditStore";

export default {
    name: "excersises",
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
    },
    computed: {
        ...mapGetters(store, ["getExcersisesList", "getWorkoutTypes"]),
        ...mapFields(store, ["idToDelete"])
    },
    methods: {
        ...mapActions(store, ["setExcersisesList", "setWorkoutTypes", "deleteExcercise"]),
        ...mapActions(editStore, ["setExcersiseDetails"]),
        ...mapMutations(store, ["resetForm"]),
        showAddPopup(){
            this.addPopupOptions.popupVisible = true;
        },      
        onAddPopupClose(){
            this.addPopupOptions.popupVisible = false;
        },
        showEditPopup(options){
            this.setExcersiseDetails(options.data.id);
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
        deleteExcersiseMethod() {
            this.deleteExcercise();
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
        DxPaging, 
        DxButton,
        DxLookup,
        addForm,
        editForm
    }
};
</script>