<template>
    <div class="content">
        <div class="main-header mt-1 mb-2"> 
            <h3 class="main-header-title"> Statystyki drużyny </h3>
        </div>
        <div class="printers" style="width: 800px;">
                    <div>
                    <!-- herb, nazwa druzyny -->
                        <img v-if="badge.length" style="width: 150px; margin: auto; display: block;" v-bind:src="'data:image/jpeg;base64,'+badge"/>
                        <span>{{ name }}</span>
                    </div>
                    <!-- wykres słupkowy - średnie punkty, asysty itd. -->
                    <DxChart
                        :data-source="getTeamAverages"
                        title="Średnie statystyki  zespołu"
                        >
                        <DxCommonSeriesSettings
                            argument-field="statType"
                            type="bar">
                            <DxLabel :visible="true">
                                <DxFormat
                                    :precision="2"
                                    type="fixedPoint"/>
                            </DxLabel>
                        </DxCommonSeriesSettings>
                        <DxSeries
                            value-field="avg"
                            name=" "/>
                    </DxChart>
                <!-- wykres spline - zdobyte i stracone punkty na przestrzeni meczów -->
                <DxChart
                    :data-source="getTeamScoreAndLosePoints"
                    palette="Violet"
                    title="Punkty zdobyte i stracone na przestrzeni meczów"
                    >
                    <DxCommonSeriesSettings
                        type="spline"
                        argument-field="opponentName"
                    />
                    <DxCommonAxisSettings>
                        <DxGrid :visible="true"/>
                    </DxCommonAxisSettings>
                    <DxSeries
                        v-for="item in sources"
                        :key="item.value"
                        :value-field="item.value"
                        :name="item.name"
                    />
                    <DxMargin :bottom="20"/>
                    <DxArgumentAxis
                        :allow-decimals="false"
                        :axis-division-factor="60"
                    >
                        <DxLabel>
                        <DxFormat type="decimal"/>
                        </DxLabel>
                    </DxArgumentAxis>
                    <DxLegend
                        vertical-alignment="top"
                        horizontal-alignment="right"
                    />
                    <DxTooltip :enabled="true"/>
                </DxChart>
        </div>
    </div>
</template>

<script>
import { 
    DxChart, 
    DxSeries,
    DxCommonSeriesSettings,
    DxLabel,
    DxFormat,
    DxArgumentAxis,
    DxCommonAxisSettings,
    DxGrid,
    DxLegend,
    DxMargin,
    DxTooltip
} from 'devextreme-vue/chart';
import { mapFields } from "vuex-map-fields";
import { mapGetters, mapActions } from "vuex";

const store = "StatisticsStore";

export default {
    name: "statistics",
    data(){
        return {
            sources: [
                {
                    value: 'teamScore',
                    name: 'Punkty zdobyte'
                },
                {
                    value: 'opponentScore',
                    name: 'Punkty stracone'
                }
            ]
        };
    },
    computed: {
        ...mapGetters(store, ["getTeamForm", "getTeamAverages", "getTeamScoreAndLosePoints"]),
        ...mapFields(store, ["teamForm.name", "teamForm.badge"])
    },
    methods: {
        ...mapActions(store, ["setTeamForm", "setTeamAverages", "setTeamScoreAndLosePoints"])
    },
    mounted(){
        this.setTeamForm();
        this.setTeamAverages();
        this.setTeamScoreAndLosePoints();
    },
    components: {
        DxChart, 
        DxSeries,
        DxCommonSeriesSettings,
        DxLabel,
        DxFormat,
        DxArgumentAxis,
        DxCommonAxisSettings,
        DxGrid,
        DxLegend,
        DxMargin,
        DxTooltip
    }
}
</script>