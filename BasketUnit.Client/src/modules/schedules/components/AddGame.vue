<template>
    <form @submit.prevent="addGame">
        <DxValidationGroup :ref="`gameValidationGroup`">
        <div class="form-group">
        <div class="row">
            <div class="col-6">
                <label>Data od</label>
                <DxDateBox v-model="GameDateFrom" type="datetime">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxDateBox>
            </div>
            <div class="col-6">
                <label>Data do</label>
                <DxDateBox v-model="GameDateTo" type="datetime">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxDateBox>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <label>Drużyna gospodarzy</label>
                <DxSelectBox 
                    v-model="HomeTeamId" 
                    :data-source="getTeams" 
                    value-expr="value" 
                    display-expr="text"
                    :search-enabled="false"
                    placeholder="">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxSelectBox>
            </div>
            <div class="col-6">
                <label>Drużyna gości</label>
                <DxSelectBox 
                    v-model="AwayTeamId" 
                    :data-source="getTeams" 
                    value-expr="value" 
                    display-expr="text"
                    :search-enabled="false"
                    placeholder="">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxSelectBox>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <label>Arena</label>
                <DxSelectBox 
                    v-model="ArenaId" 
                    :data-source="getArenas" 
                    value-expr="value" 
                    display-expr="text"
                    :search-enabled="false"
                    placeholder="">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxSelectBox>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <label>Arbiter 1</label>
                <DxSelectBox 
                    v-model="FirstRefereeId" 
                    :data-source="getReferees" 
                    value-expr="value" 
                    display-expr="text"
                    :search-enabled="false"
                    placeholder="">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxSelectBox>
            </div>
            <div class="col-6">
                <label>Arbiter 2</label>
                <DxSelectBox 
                    v-model="SecondRefereeId" 
                    :data-source="getReferees" 
                    value-expr="value" 
                    display-expr="text"
                    :search-enabled="false"
                    placeholder="">
                    <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                </DxSelectBox>
            </div>
        </div>
        </div>
        <DxButton
            text="Anuluj"
            type="default"
            styling-mode="outlined"
            @click="hideAddGamePopup" />
        <DxButton
            text="Zapisz"
            type="default"
            :use-submit-behavior="true"
            class="ml-1"
            @click="addGameMethod" />
            </DxValidationGroup>
        </form>
</template>
<script>
import {
    DxButton,
    DxSelectBox,
    DxDateBox
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "SchedulesStore";
export default {
    name: "gameAdd",
    created(){
        this.setTeams();
        this.setReferees()
        this.setArenas()
    },
    data(){
        return{
            
        };
    },
    computed: {
        ...mapGetters(store, [
            "getTeams", 
            "getArenas", 
            "getReferees"
        ]),
        ...mapFields(store, [
            "addGameForm.GameDateFrom",
            "addGameForm.GameDateTo",
            "addGameForm.HomeTeamId",
            "addGameForm.AwayTeamId",
            "addGameForm.ArenaId",
            "addGameForm.FirstRefereeId",
            "addGameForm.SecondRefereeId"
        ]),
    },
    methods: {
        ...mapActions(store, [
            "setTeams", 
            "setReferees", 
            "setArenas", 
            "addGame"
        ]),
        ...mapMutations(store, ["resetAddGameForm"]),
        hideAddGamePopup: function () {
            this.$emit("closeAdd");
            this.resetAddGameForm();
        },
        addGameMethod: function (e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                this.$emit("closeAdd");
                this.showSuccessNotify();
            }
        },
        showSuccessNotify() {
            this.$nextTick(() => {
                notify("Zapisano", "success", 500);
            });
        },
    },
    mounted() {
    },
    components: {
        DxButton,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup,
        DxSelectBox,
        DxDateBox
    }
    
}
</script>