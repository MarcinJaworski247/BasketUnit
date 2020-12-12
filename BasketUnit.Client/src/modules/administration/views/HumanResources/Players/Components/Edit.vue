<template>
    <form @submit.prevent="editPlayer">
        <DxValidationGroup :ref="`validationGroup`">
        <div class="form-group">
            <div class="row" style="height: 200px;">
                <div class="col-12">
                    <div style="width: 150px; height: 150px; background-color: grey;">
                        <img v-if="Avatar.length" style="width: 150px; margin: auto; display: block;" v-bind:src="'data:image/jpeg;base64,'+Avatar"/>
                        <img v-if="Avatar.length<=0" style="width: 150px; margin: auto; display: block;" v-bind:src="'https://cdn4.iconfinder.com/data/icons/small-n-flat/24/user-alt-512.png'"/>
                    </div>
                    <div class="mt-2">
                        <DxButton text="Wybierz zdjęcie" @click="showAvatarUpload" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Imię</label>
                    <DxTextBox v-model="FirstName">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
                <div class="col-6">
                    <label>Nazwisko</label>
                    <DxTextBox v-model="LastName">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <label>Data urodzenia</label>
                    <DxDateBox v-model="BirthDate">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxDateBox>
                </div>
                <div class="col-4">
                    <label>Narodowość</label>
                    <DxSelectBox 
                        v-model="NationalityId"
                        :data-source="getNationalities"
                        value-expr="value"
                        display-expr="text"
                        :search-enabled="false"
                        placeholder="">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxSelectBox>
                </div>
                <div class="col-4">
                    <label>Numer</label>
                    <DxNumberBox v-model="PlayerNumber">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxNumberBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Drużyna</label>
                    <DxSelectBox 
                        v-model="TeamId"
                        :data-source="getTeams"
                        value-expr="value"
                        display-expr="text"
                        :search-enabled="false"
                        placeholder="">
                    </DxSelectBox>
                </div>
                <div class="col-6">
                    <label>Pozycja</label>
                    <DxSelectBox 
                        v-model="PositionId"
                        :data-source="getPositions"
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
                <div class="col-4">
                    <label>Wzrost</label>
                    <DxNumberBox v-model="Height" />
                </div>
                <div class="col-4">
                    <label>Waga</label>
                    <DxNumberBox v-model="Weight" />
                </div>
                <div class="col-4">
                    <label>Uniwersytet</label>
                    <DxSelectBox 
                        v-model="CollegeId"
                        :data-source="getColleges"
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

        <div class="popup-bottom">
            <DxButton 
                :use-submit-behavior="false"
                styling-mode="outlined"
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

        <DxPopup
            :visible.sync="uploadPopup.popupVisible"
            :drag-enabled="false"
            :show-title="true"
            title="Wybierz zdjęcie"
            height="auto"
            width="280">
            <base64-upload class="mb-2" style="width: 150px; height: 150px; margin:auto;" :imageSrc="'data:image/jpeg;base64,'+Avatar" @change="onChangeImage">Wybierz zdjęcie</base64-upload>
            <DxButton
                icon="fas fa-check"
                style="margin-left: auto; margin-right: auto;"
                type="default"
                styling-mode="outlined"
                @click="hideAvatarUpload()" />
        </DxPopup>
        
    </form>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxSelectBox,
    DxDateBox,
    DxNumberBox,
    DxPopup
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from 'devextreme/ui/notify';
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
import Base64Upload from 'vue-base64-upload'
const store = "AdministrationEditPlayerStore";

export default {
    name: "playerEdit",
    data(){
        return {
            uploadPopup: {
                popupVisible: false
            }
        };
    },
    computed: {
        ...mapGetters(store, ["getForm", "getTeams", "getPositions", "getNationalities", "getColleges"]),
        ...mapFields(store, [
            "editForm.Id",
            "editForm.FirstName",
            "editForm.LastName",
            "editForm.TeamId",
            "editForm.PositionId",
            "editForm.BirthDate",
            "editForm.NationalityId",
            "editForm.Avatar",
            "editForm.PlayerNumber",
            "editForm.CollegeId",
            "editForm.Height",
            "editForm.Weight"
        ])
    },
    methods: {
        ...mapActions(store, ["editPlayer", "setTeams", "setPositions", "setNationalities", "setColleges"]),
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
        },
        onChangeImage(file) {
            this.Avatar = file.base64;
        },
        showAvatarUpload() {
            this.uploadPopup.popupVisible = true;
        },
        hideAvatarUpload() {
            this.uploadPopup.popupVisible = false;
        }
    },
    mounted(){
        this.setTeams();
        this.setPositions();
        this.setNationalities();
        this.setColleges();
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
        DxDateBox,
        DxNumberBox,
        Base64Upload,
        DxPopup
    }
};
</script>