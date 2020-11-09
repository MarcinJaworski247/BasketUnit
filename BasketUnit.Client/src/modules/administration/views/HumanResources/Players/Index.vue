<template>
<div class="content">
    <div class="printers">
    <div class="main-header mt-1 mb-2"> 
        <h3 class="main-header-title"> Zawodnicy </h3>
        <DxButton
            :use-submit-behavior="false"
            type="default"
            text="Dodaj"
            @click="function() { $router.push({ name: 'administration.humanResources.players.add' }) }" />
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
            data-field="avatar"
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
            data-field="Position"
            data-type="string"
            alignment="left"
            caption="Pozycja" />
        <DxColumn 
            data-field="Team"
            data-type="string"
            alignment="left"
            caption="Drużyna" />
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
            <router-link
                class="datagrid-btn"
                :to="{ name: 'administration.humanResources.players.edit', params: { id: data.value } }"
            >
                <i hint="Edycja" class="fas fa-pen"></i>
            </router-link>
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
} 
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
        DxButton,
        DxPager,
        DxPaging
    }
};
</script>