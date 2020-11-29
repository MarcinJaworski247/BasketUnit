<template>
    <div class="content">
        <div class="printers">
            <div class="main-header mt-4 mb-4"> 
                <h3 class="main-header-title"> Protokół meczu </h3>
            </div>
            <DxDataGrid
                id="gridContainer"
                :data-source="getGameStatistics"
                :show-borders="true"
                key-expr="id"
                :allow-column-reordering="true"
                :row-alternation-enabled="true"
                class="main-datagrid"
                show-filter-row="true"
                width="1000">
                <DxFilterRow :visible="true" :show-operation-chooser="true" />
                <DxColumn 
                    data-field="fullName"
                    caption="Zawodnik"
                    alignment="left"
                    data-type="string"
                    width="200"
                />
                <DxColumn 
                    data-field="team"
                    caption="Drużyna"
                    alignment="left"
                    data-type="string"
                    width="200"
                />
                <DxColumn 
                    data-field="points"
                    caption="Punkty"
                    alignment="center"
                    data-type="number"
                />
                <DxColumn 
                    data-field="assists"
                    caption="Asysty"
                    alignment="center"
                    data-type="number"
                />
                <DxColumn 
                    data-field="rebounds"
                    caption="Zbiórki"
                    alignment="center"
                    data-type="number"
                />
                <DxColumn 
                    data-field="steals"
                    caption="Przechwyty"
                    alignment="center"
                    data-type="number"
                />
                <DxColumn 
                    data-field="blocks"
                    caption="Bloki"
                    alignment="center"
                    data-type="number"
                />
                <DxColumn 
                    data-field="fouls"
                    caption="Faule"
                    alignment="center"
                    data-type="number"
                />
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
                    <DxButton @click="showProtocolEditPopup(data)" icon="fas fa-chevron-right"/>
                </div>
            </DxDataGrid>

            <div class="d-flex end-xs mt-5 mb-4">
            <DxButton
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function(){ $router.push({ name: 'protocols.index' }) }"/>
            </div>
        </div>

        <!-- edit  popup  -->
        <DxPopup
            id="editPopup"
            :visible.sync="popupVisible"
            :drag-enabled="false"
            :width="500"
            :title="FullName"
            height="auto"
            class="popup">
            <div class="form-group">
                <div class="row">
                    <div class="col-6">
                        <label>Punkty</label>
                        <DxNumberBox v-model="Points"/>
                    </div>
                    <div class="col-6">
                        <label>Asysty</label>
                        <DxNumberBox v-model="Assists"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <label>Zbiórki</label>
                        <DxNumberBox v-model="Rebounds"/>
                    </div>
                    <div class="col-6">
                        <label>Przechwyty</label>
                        <DxNumberBox v-model="Steals"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <label>Bloki</label>
                        <DxNumberBox v-model="Blocks"/>
                    </div>
                    <div class="col-6">
                        <label>Faule</label>
                        <DxNumberBox v-model="Fouls"/>
                    </div>
                </div>
                <div class="popup-bottom mt-4">
                    <DxButton 
                        :use-submit-behavior="false"
                        styling-mode="outlined"
                        type="normal"
                        text="Anuluj"
                        @click="hideEditPopup" />
                    <DxButton 
                        :use-submit-behavior="false"
                        type="default"
                        class="ml-1"
                        text="Zapisz"
                        @click="saveGamePlayerStatisticsMethod" />
                </div>
            </div>
        </DxPopup>



    </div>
</template>
<script>
import 
{ 
    DxPopup,
    DxButton,
    DxNumberBox
} from 'devextreme-vue';
import {
    DxDataGrid, 
    DxColumn, 
    DxFilterRow
  } from 'devextreme-vue/data-grid'
import { mapFields } from "vuex-map-fields";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapState } from "vuex";
const store = "ProtocolsEditStore";
export default {
    name: "protocolEdit",
    data(){
        return {
        popupVisible: false
        };
    },
    created(){

    },
    computed: {
        ...mapGetters(store, ["getGameStatistics"]),
        ...mapState(store, ["getForm"]),
        ...mapFields(store, [
            "editForm.Id",
            "editForm.FullName",
            "editForm.Points",
            "editForm.Assists",
            "editForm.Rebounds",
            "editForm.Steals",
            "editForm.Blocks",
            "editForm.Fouls"
        ])
    },
    methods: {
        ...mapActions(store, ["saveGamePlayerStatistics", "setGamePlayerStatistics", "setGameStatistics"]),
        showProtocolEditPopup(options){
            debugger
            this.setGamePlayerStatistics(options.data.id);
            this.popupVisible = true;
        },
        hideEditPopup(){
            this.popupVisible = false;
        },
        showSuccessNotify() {
            this.$nextTick(() => {
                notify("Zapisano", "success", 500);
            });
        },
        saveGamePlayerStatisticsMethod(){
            this.saveGamePlayerStatistics();
            this.popupVisible = false;
            this.showSuccessNotify();
        }
    },
    mounted(){
        this.setGameStatistics();
    },
    components: {
    DxPopup,
    DxButton,
    DxNumberBox,
    DxDataGrid, 
    DxColumn, 
    DxFilterRow
    }
}
</script>