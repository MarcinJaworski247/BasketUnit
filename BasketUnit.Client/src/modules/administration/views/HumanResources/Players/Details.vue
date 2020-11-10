<template>
<div class="content">
    <div class="card">
    <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <div class="file-upload">
                        <img v-bind:src="'data:image/jpeg;base64,'+PlayerAvatar" />
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <div class="file-upload">
                        <img v-bind:src="'data:image/jpeg;base64,'+TeamBadge" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Imię</label>
                    <div class="col-xs-12">
                        <DxTextBox :read-only="true" v-model="FirstName">
                        </DxTextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Nazwisko</label>
                    <div class="col-xs-12">
                        <DxTextBox :read-only="true" v-model="LastName">
                        </DxTextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Pozycja</label>
                    <div class="col-xs-12">
                        <DxSelectBox :read-only="true" v-model="Position"/>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Drużyna</label>
                    <div class="col-xs-12">
                        <DxSelectBox :read-only="true" v-model="TeamName"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Narodowość</label>
                    <div class="col-xs-12">
                        <DxTextBox :read-only="true" v-model="Nationality">
                        </DxTextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Data urodzenia</label>
                    <div class="col-xs-12">
                        <DxDateBox :read-only="true" v-model="BirthDate">
                        </DxDateBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <div class="row">
            <DxDataGrid
                id="gridContainer"
                :data-source="getLastPlayerStatistics"
                :show-borders="true"
                key-expr="Id"
                :allow-column-reordering="true"
                :row-alternation-enabled="true"
                class="main-datagrid"
                show-filter-row="true">
                <DxColumn 
                    data-field="Against"
                    alignment="left"
                    caption="Przeciwko"
                    data-type="string" />
                <DxColumn 
                    data-field="Date"
                    data-type="date"
                    alignment="center"
                    caption="Data" />
                <DxColumn 
                    data-field="Points"
                    data-type="number"
                    alignment="center"
                    caption="Punkty" />
                <DxColumn 
                    data-field="Assists"
                    data-type="number"
                    alignment="center"
                    caption="Punkty" />
                <DxColumn 
                    data-field="Rebounds"
                    data-type="number"
                    alignment="center"
                    caption="Punkty" />
                <DxColumn 
                    data-field="Blocks"
                    data-type="number"
                    alignment="center"
                    caption="Punkty" />
                <DxColumn 
                    data-field="Steals"
                    data-type="number"
                    alignment="center"
                    caption="Punkty" />
                <DxColumn
                    data-fiel="FinalScore"
                    data-type="string"
                    alignment="center"
                    caption="Wynik" />
                <DxColumn
                    data-field="GameResult"
                    alignment="center"
                    cell-template="resultTemplate" />
                <div slot="resultTemplate" slot-scope="{ data }">
                    <span v-if="data.value == 0" style="color: green;">{{data.value}}</span>
                    <span v-if="data.value == 1" style="color: red;">{{data.value}}</span>
                </div>
            </DxDataGrid>
        </div>
    </div>
    <div class="card">
        <AvarageStatsChart :data="getPlayerStatsToChart" />
    </div>
</div>
</template>

<script>
import {
    DxTextBox,
    DxButton,
    DxValidator,
    DxNumberBox,
    DxSelectBox
} from 'devextreme-vue';
import { DxRequiredRule } from "devextreme-vue/validator";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
import AvarageStatsChart from "./Components/AvarageStatsChart";
const store = "HumanResourcesPlayerStore";
const statsStore = "HumanResourcesPlayerDetailsStore";


export default {
    
};
</script>