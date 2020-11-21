<template>
    <form @submit.prevent="editPlayer">
        <DxValidationGroup :ref="`validationGroup`">
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group row">
                    <div class="file-upload">
                        <img v-bind:src="'data:image/jpeg;base64,'+Avatar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Imię</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="FirstName">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxTextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Nazwisko</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="LastName">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
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
                        <DxSelectBox 
                            v-model="PositionId"
                            :data-source="getPositions"
                            value-expr="Value"
                            display-expr="Text"
                            :search-enabled="false"
                            placeholder=""/>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Drużyna</label>
                    <div class="col-xs-12">
                        <DxSelectBox 
                            v-model="TeamId"
                            :data-source="getTeams"
                            value-expr="Value"
                            display-expr="Text"
                            :search-enabled="false"
                            placeholder=""/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Narodowość</label>
                    <div class="col-xs-12">
                        <DxSelectBox 
                            v-model="NationalityId"
                            :data-source="getNationalities"
                            value-expr="Value"
                            display-expr="Text"
                            :search-enabled="true"
                            placeholder="">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxSelectBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Data urodzenia</label>
                    <div class="col-xs-12">
                        <DxDateBox v-model="BirthDate">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxDateBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="popup-bottom">
            <DxButton 
                :use-submit-behavior="false"
                styling-mode="text"
                type="normal"
                text="Anuluj"
                @click="closePopup" />
            <DxButton 
                :use-submit-behavior="true"
                type="default"
                class="ml-1"
                text="Zapisz"
                @click="closePopupOnSave" />
        </div>
        </DxValidationGroup>
    </form>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxSelectBox,
    DxDateBox
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationEditPlayerStore";

export default {
    name: "playerEdit",
    created(){
    },
    data(){
        return {

        };
    },
    computed: {
        ...mapGetters(store, ["getForm", "getTeams", "getPositions", "getNationalities"]),
        ...mapFields(store, [
            "editForm.Id",
            "editForm.FirstName",
            "editForm.LastName",
            "editForm.TeamId",
            "editForm.PositionId",
            "editForm.BirthDate",
            "editForm.Nationality",
            "editForm.Avatar"
        ])
    },
    methods: {
        ...mapActions(store, ["editPlayer", "setTeams", "setPositions", "setNationalities"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeEdit");
            this.resetForm();
        },
        closePopupOnSave: function (e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                this.$emit("closeEdit");
                this.showSuccessNotify();
            }
        },
        showSuccessNotify() {
            this.$nextTick(() => {
                notify("Zapisano", "success", 500);
            });
        }  
    },
    mounted(){
        //this.setDetails();
        this.setTeams();
        this.setPositions();
        this.setNationalities();
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup,
        DxSelectBox,
        DxDateBox
    }
};
</script>
<style scoped>

</style>