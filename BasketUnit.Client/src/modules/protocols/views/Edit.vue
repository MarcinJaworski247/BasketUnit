<template>
    <div class="content">
        <div class="printers">

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
                />
                <DxColumn 
                    data-field="team"
                    caption="Drużyna"
                    alignment="left"
                    data-type="string"
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
                    <DxButton @click="showEditPopup(data)" hint="Edytuj" title="Edytuj" icon="fas fa-pen" class="datagrid-button" type="normal" />
                </div>
            </DxDataGrid>

            <div class="d-flex end-xs mt-5">
            <DxButton
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function(){ $router.push({ name: 'games.index' }) }"/>
            </div>
        </div>

        <!-- edit  popup  -->
        <DxPopup
            id="editPopup"
            :visible.sync="popupVisible"
            :drag-enabled="false"
            :width="500"
            height="auto"
            class="popup">
            <div class="form-group">
                <div class="row">
                    <div class="col-12">
                        <label>Zawodnik</label>
                        {{ FullName }}
                    </div>
                </div>
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
                <div class="popup-bottom">
                    <DxButton 
                        :use-submit-behavior="false"
                        styling-mode="outlined"
                        type="normal"
                        text="Anuluj"
                        @click="hideEditPopup" />
                    <DxButton 
                        :use-submit-behavior="true"
                        type="default"
                        class="ml-1"
                        text="Zapisz"
                        @click="saveGamePlayerStatistics" />
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
    DxNumberBox,
    DxTextBox
} from 'devextreme-vue';
import {
    DxDataGrid, 
    DxColumn, 
    DxFilterRow,
    DxPaging,
    DxLookup 
  } from 'devextreme-vue/data-grid'
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "ProtocolsEditStore";
export default {
    name: "protocolEdit",
    data(){
        popupVisible = false;
    },
    created(){

    },
    computed: {
        ...mapGetters(store, ["getGameStatistics"]),
        ...mapState(store, ["getForm"])
    },
    methods: {
        ...mapActions(store, ["saveGamePlayerStatistics", "setGamePlayerStatistics", "setGameStatistics"]),
        showEditPopup(options){
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
        saveGamePlayerStatistics(){
            this.saveGamePlayerStatistics();
            this.popupVisible = false;
            this.showSuccessNotify();
        }
    },
    mounted(){
        this.setGameStatistics();
    }
}
</script>