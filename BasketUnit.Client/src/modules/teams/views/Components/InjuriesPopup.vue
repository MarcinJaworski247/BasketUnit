<template>
    <div>
        <div class="main-header mt-1 mb-2"> 
            <DxButton
                :use-submit-behavior="false"
                type="default"
                text="Dodaj"
                class="main-tabpanel-button"
                @click="showAddInjuryPopup" />
        </div>
        <DxDataGrid
            :data-source="playerInjuries"
            key-expr="id"
            :allow-column-reordering="true"
            :row-alternation-enabled="true"
            class="main-datagrid"
            height="auto">
            <DxColumn 
                data-field="injury"
                data-type="string"
                alignment="left"
                caption="Kontuzja" />
            <DxColumn 
                data-field="injuredTo"
                data-type="date"
                alignment="center"
                caption="Data do" />
        </DxDataGrid>

        <!-- add popup -->
        <DxPopup 
            :visible.sync="addPopupVisible"
            :drag-enabled="false"
            :show-title="true"
            :width="500"
            height="auto"
            class="popup"
            title-template="titleTemplate">
            <div slot="titleTemplate">
                <h3 class="popup-title-text">Dodaj</h3>
            </div>
            <AddInjury @closeAdd="onAddInjuryPopupClose"></AddInjury>
        </DxPopup>

    </div>
</template>
<script>
import { DxPopup, DxButton } from 'devextreme-vue';
import { DxDataGrid, DxColumn } from 'devextreme-vue/data-grid';
import AddInjury from "./AddInjury.vue";
export default {
    name: "injuriesPopup",
    props: {
        playerInjuries: Array
    },
    data() {
        return  {
            addPopupVisible: false
        };
    },
    methods: {
        showAddInjuryPopup() {
            this.addPopupVisible = true;
        },
        onAddInjuryPopupClose() {
            this.addPopupVisible = false;
        }
    },
    components: {
        DxPopup,
        DxButton,
        DxDataGrid,
        DxColumn,
        AddInjury
    }
};
</script>