<template>
    <div class="content">
        <div class="printers">
            <div >
                <div style="text-align: center; font-size: 24px; font-weight: bold;" class="mt-4">
                    <div>
                        
                        <img style="width: 100px;" v-bind:src="'data:image/jpeg;base64,'+HomeTeamBadge"/>
                        {{ HomeTeam }}
                        {{ HomeTeamScore }}  :  {{ AwayTeamScore }}
                        {{ AwayTeam }}
                        <img style="width: 100px;" v-bind:src="'data:image/jpeg;base64,'+AwayTeamBadge"/>
                        
                    </div>
                    <div class="mt-4">
                        <h4>Data: {{ GameDate }}</h4>
                        <h4>Arena: {{ Arena }}</h4>
                        <h4>Sędziowie: {{ FirstReferee }},  {{ SecondReferee }}</h4>
                    </div>
                </div>
                <div class="mt-4">
                    <h4 class="mb-4">Statystyki </h4>
                    <DxDataGrid
                        id="homegridContainer"
                        :data-source="getGamePlayersStats"
                        :show-borders="true"
                        key-expr="fullName"
                        :row-alternation-enabled="true"
                        class="main-datagrid">
                        <DxColumn
                            data-field="fullName"
                            caption="Zawodnik"
                            alignment="left"
                            data-type="string"/>
                        <DxColumn
                            data-field="team"
                            caption="Drużyna"
                            alignment="left"
                            data-type="string"/>
                        <DxColumn
                            data-field="points"
                            caption="Punkty"
                            alignment="center"
                            data-type="number"/>
                        <DxColumn
                            data-field="assists"
                            caption="Asysty"
                            alignment="center"
                            data-type="number"/>
                        <DxColumn
                            data-field="rebounds"
                            caption="Zbiórki"
                            alignment="center"
                            data-type="number"/>
                        <DxColumn
                            data-field="steals"
                            caption="Przechwyty"
                            alignment="center"
                            data-type="number"/>
                        <DxColumn
                            data-field="blocks"
                            caption="Bloki"
                            alignment="center"
                            data-type="number"/>
                        <DxColumn
                            data-field="fouls"
                            caption="Faule"
                            alignment="center"
                            data-type="number"/>

                    </DxDataGrid>
                </div>
                
            </div>
            <div class="d-flex end-xs mt-5 mb-4">
            <DxButton
                :use-submit-behavior="false"
                type="normal"
                styling-mode="outlined"
                text="Wróć"
                @click="function(){ $router.push({ name: 'games.index' }) }"/>
            </div>
        </div>
    </div>
</template>
<script>
import {
    DxDataGrid, 
    DxColumn,
} from 'devextreme-vue/data-grid';
import { 
    DxButton
} from 'devextreme-vue';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";
const store = "GamesDetailsStore";
export default {
    name: "gameDetails",
    computed: {
        ...mapGetters(store, ["getGameDetails", "getGamePlayersStats"]),
        ...mapFields(store, [
            "detailsForm.HomeTeam",
            "detailsForm.AwayTeam",
            "detailsForm.HomeTeamBadge",
            "detailsForm.AwayTeamBadge",
            "detailsForm.GameDate",
            "detailsForm.HomeTeamScore",
            "detailsForm.AwayTeamScore",
            "detailsForm.Arena",
            "detailsForm.FirstReferee",
            "detailsForm.SecondReferee",
        ])
    },
    methods: {
        ...mapActions(store, ["setGameDetails", "setGamePlayersStats"])
    },
    mounted() {
        this.setGameDetails();
        this.setGamePlayersStats();
    },
    components: {
        DxButton,
        DxDataGrid, 
        DxColumn
    }
}
</script>