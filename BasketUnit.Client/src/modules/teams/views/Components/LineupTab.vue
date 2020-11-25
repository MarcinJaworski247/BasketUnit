<template>
<div class="content">
    <div class="printers mt-4 mb-2">
        <DxDataGrid
        id="gridContainer"
        :data-source="getPlayersList"
        :show-borders="true"
        key-expr="id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn 
            data-field="avatar"
            caption=""
            cell-template="avatarCellTemplate"
            :allow-search="false"
            :allow-filtering="false"
            alignment="center"
            width="100"
        />
        <div slot="avatarCellTemplate" slot-scope="{ data }">
            <img v-bind:src="data.avatar" />
        </div>
        <DxColumn 
            data-field="fullName"
            alignment="left"
            caption="Imię i nazwisko"
            data-type="string"
            cellTemplate="nameHyperlinkTemplate" />
        <div slot="nameHyperlinkTemplate" slot-scope="{ data }">
            <router-link
                :to="{ name: 'team.player.details', params: { playerId: data.value } }">
                {{ data.value }}
            </router-link>
        </div>
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
            data-field="positionId"
            alignment="left"
            caption="Pozycja">
            <DxLookup
                :data-source="getPositionsToLookup"
                value-expr="value"
                display-expr="text" />
        </DxColumn>
        <DxColumn
            data-field="playerNumber"
            data-type="number"
            alignment="center"
            caption="Numer" />
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
            <router-link
                class="datagrid-btn"
                :to="{ name: 'team.player.details', params: { playerId: data.value } }">
                <DxButton hint="Szczegóły" icon="fas fa-chevron-right" class="datagrid-button" type="normal"></DxButton>
            </router-link>
            <!-- <DxButton @click="showEditPopup(data)" hint="Edytuj" title="Edytuj" icon="fas fa-pen" class="ml-3 datagrid-button" type="normal"/> -->
        </div>
        <DxPager :allowed-page-sizes="pageSizes" :show-page-size-selector="true" />
        <DxPaging :page-size="5" />
    </DxDataGrid>
    </div>

    <!-- edit popup -->
    <!-- <DxPopup
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
    </DxPopup> -->

</div>
</template>
<script>
import 
{  
    // DxPopup,
    DxButton
} from 'devextreme-vue';
import { DxDataGrid, DxColumn, DxFilterRow, DxPager, DxPaging, DxLookup } from "devextreme-vue/data-grid"; 
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
// import editForm from "./EditPlayer.vue";
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
        ...mapGetters(store, ["getPlayersList", "getPositionsToLookup", "getNationalities"])
    },
    methods: {
        ...mapActions(store, ["setPlayersList", "setDetails", "setPositionsToLookup", "setNationalities"]),
        // showEditPopup(options){
        //     this.setDetails(options.data.Id);
        //     this.editPopupOptions.popupVisible = true;
        // },
        // onEditPopupClose(){
        //     this.editPopupOptions.popupVisible = false;
        //     this.setPlayersList();
        // }
    },
    mounted() {
        this.setPlayersList();
        this.setNationalities();
        this.setPositionsToLookup();
    },
    components: {
        DxDataGrid, 
        DxColumn, 
        DxFilterRow, 
        DxPager,
        DxPaging,
        // editForm,
        // DxPopup,
        DxLookup,
        DxButton
    }
}
</script>