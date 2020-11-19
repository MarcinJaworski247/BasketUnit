<template>
<div class="content">
    <div class="printers">
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
                :to="{ name: 'team.players.details', params: { id: data.value } }">
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
                :data-source="getPositionsToLookup"
                value-expr="Value"
                display-expr="Text" />
        </DxColumn>
        <DxColumn
            data-field="PlayerNumber"
            data-type="number"
            alignment="center"
            caption="Numer" />
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
                :to="{ name: 'team.players.details', params: { id: data.value } }"
            >
                <i hint="Szczegóły" class="fas fa-chevron-right"></i>
            </router-link>
            <span @click="showEditPopup(data)" title="Edytuj" class="fas fa-pen" />
        </div>
        <DxPager :allowed-page-sizes="pageSizes" :show-page-size-selector="true" />
        <DxPaging :page-size="5" />
    </DxDataGrid>
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

</div>
</template>
<script>
import 
{  
    DxPopup,
    DxLookup
} from 'devextreme-vue';
import { DxDataGrid, DxColumn, DxFilterRow, DxPager, DxPaging } from "devextreme-vue/data-grid"; 
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
import editForm from "./EditPlayer.vue";
const store = "TeamStore";

export default {
    name: "lineup",
    data() {
        return {
            pageSizes: [5, 10, 15],
            editPopupOptions: {
                popupVisible: false
            }
        };
    },
    created() {

    },
    computed: {
        ...mapGetters(store, ["getPlayersList", "getPositionsToLookup"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setDetails", "setPositionsToLookup"]),
        showEditPopup(options){
            this.setDetails(options.data.Id);
            this.editPopupOptions.popupVisible = true;
        },
        onEditPopupClose(){
            this.editPopupOptions.popupVisible = false;
            this.setPlayersList();
        }
    },
    mounted() {
        this.setPlayersList();
        this.setPositionsToLookup();
    },
    components: {
        DxDataGrid, 
        DxColumn, 
        DxFilterRow, 
        DxPager,
        DxPaging,
        editForm,
        DxPopup,
        DxLookup
    }
}
</script>