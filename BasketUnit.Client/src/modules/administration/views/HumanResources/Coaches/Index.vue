<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Trenerzy
        </h3>
        
    </div>
    
    <DxDataGrid
        id="gridContainer"
        :data-source="coaches"
        :show-borders="true"
        key-expr="Id"
        :allow-column-reordering="true"
        :row-alternation-enabled="true"
        class="main-datagrid"
        show-filter-row="true"
    >
        <DxFilterRow :visible="true" :show-operation-chooser="true" />
        <DxColumn 
            data-field="FullName"
            alignment="left"
            caption="Imię i nazwisko"
            data-type="string">
        </DxColumn>
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
            data-field="EmailAddress"
            data-type="date"
            alignment="center"
            caption="Email" />
        <DxColumn 
            data-field="PhoneNumber"
            data-type="date"
            alignment="center"
            caption="Nr. tel." />
        <DxColumn 
            data-field="Team"
            data-type="string"
            alignment="left"
            caption="Drużyna" />
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
</div>
</template>

<script>
import { 
    DxDataGrid, 
    DxColumn, 
    DxFilterRow, 
    DxButton } 
from 'devextreme-vue';


export default {
    name: "coaches",
    data() {
        return {
            coaches: []
        }
    },
    created() {
    },
    methods: {      
    },
    mounted() {
    },
    components: {
        DxDataGrid,
        DxColumn,
        DxFilterRow,
        DxButton
    }
};
</script>