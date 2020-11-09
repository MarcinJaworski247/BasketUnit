<template>
    <form @submit.prevent="addTeam">
        <DxValidationGroup :ref="`validationGroup`">
        <!-- <div class="row">
            <div class="col-xs-12">
                <div class="form-group row">
                    <div class="file-upload">
                        <img v-bind:src="'data:image/jpeg;base64,'+Badge" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="fileuploader-container">
                        <DxFileUploader
                            select-button-text="Wybierz zdjęcie"
                            label-text="lub upuść tutaj"
                            accept="image/*"
                            upload-mode="useForm"
                            :show-file-list="false"
                            :multiple="false"
                        />
                    </div>
                </div>
            </div>
        </div> -->
        <div class="row">
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Nazwa</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxTextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Miasto</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="City">
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
                    <label class="col-xs-12">Arena</label>
                    <div class="col-xs-12">
                        <DxSelectBox 
                            v-model="ArenaId"
                            :data-source="getArenas"
                            value-expr="Value"
                            display-expr="Text"
                            :search-enabled="false"
                            placeholder=""/>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Trener</label>
                    <div class="col-xs-12">
                        <DxSelectBox 
                            v-model="CoachId"
                            :data-source="getCoaches"
                            value-expr="Value"
                            display-expr="Text"
                            :search-enabled="false"
                            placeholder=""/>
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
    DxValidator,
    DxNumberBox,
    DxSelectBox
} from 'devextreme-vue';
import { DxFileUploader } from 'devextreme-vue/file-uploader';
import { DxRequiredRule, DxCustomRule } from "devextreme-vue/validator";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationTeamStore";

export default {
    name: "teamAdd",
    created(){

    },
    data(){
        return {

        };
    },
    computed: {
        ...mapGetters(store, ["getForm", "getCoaches", "getArenas"]),
        ...mapFields(store, [
            "addForm.Name",
            "addForm.City",
            "addForm.ArenaId",
            "addForm.CoachId",
            "addForm.Badge"
        ])
    },
    methods: {
        ...mapActions(store, ["addTeam", "setArenas", "setCoaches"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeAdd");
            this.resetForm();
        },
        closePopupOnSave: function (e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                this.showSuccessNotify();
                this.$emit("closeAdd");
            }
        },
        showSuccessNotify() {
            this.$nextTick(() => {
                notify("Zapisano", "success", 500);
            });
        }    
    },
    mounted(){
        this.setCoaches();
        this.setArenas();
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxValidator,
        DxNumberBox,
        DxRequiredRule,
        DxSelectBox
    }
};
</script>
<style scoped>

</style>