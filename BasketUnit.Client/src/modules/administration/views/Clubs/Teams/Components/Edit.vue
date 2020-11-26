<template>
    <form @submit.prevent="editTeam">
        <DxValidationGroup :ref="`validationGroup`">

        <div class="form-group">
            <div class="row" style="height: 200px;">
                <div class="col-12">
                    <div style="width: 150px; height: 150px; background-color: grey;">
                        <img v-if="Badge.length" style="width: 150px; margin: auto; display: block;" v-bind:src="'data:image/jpeg;base64,'+Badge"/>
                        <img v-if="Badge.length<=0" style="width: 150px; margin: auto; display: block;" v-bind:src="'https://cdn4.iconfinder.com/data/icons/small-n-flat/24/user-alt-512.png'"/>
                    </div>
                    <div class="mt-2">
                        <DxButton text="Wybierz zdjęcie" @click="showBadgeUpload" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Miasto</label>
                    <DxTextBox v-model="City">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
                <div class="col-6">
                    <label>Nazwa</label>
                    <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Arena</label>
                    <DxSelectBox 
                        v-model="ArenaId"
                        :data-source="getArenas"
                        value-expr="value"
                        display-expr="text"
                        :search-enabled="false"
                        placeholder=""/>
                </div>
                <div class="col-6">
                    <label>Trener</label>
                    <DxSelectBox 
                        v-model="CoachId"
                        :data-source="getCoaches"
                        value-expr="value"
                        display-expr="text"
                        :search-enabled="false"
                        placeholder=""/>
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
            <base64-upload class="mb-2" style="width: 150px; height: 150px; margin:auto;" :imageSrc="'data:image/jpeg;base64,'+Badge" @change="onChangeImage">Wybierz zdjęcie</base64-upload>
            <DxButton
                icon="fas fa-check"
                style="margin-left: auto; margin-right: auto;"
                type="default"
                styling-mode="outlined"
                @click="hideBadgeUpload()" />
        </DxPopup>

    </form>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxSelectBox,
    DxPopup
} from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
import Base64Upload from 'vue-base64-upload'
const store = "AdministrationEditTeamStore";

export default {
    name: "teamEdit",
    created(){

    },
    data(){
        return {
            uploadPopup: {
                popupVisible: false
            }
        };
    },
    computed: {
        ...mapGetters(store, ["getForm", "getCoaches", "getArenas"]),
        ...mapFields(store, [
            "editForm.Name",
            "editForm.City",
            "editForm.ArenaId",
            "editForm.CoachId",
            "editForm.Badge"
        ])
    },
    methods: {
        ...mapActions(store, ["editTeam", "setArenas", "setCoaches"]),
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
            this.Badge = file.base64;
        },
        showBadgeUpload() {
            this.uploadPopup.popupVisible = true;
        },
        hideBadgeUpload() {
            this.uploadPopup.popupVisible = false;
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
        DxRequiredRule,
        DxValidationGroup,
        DxSelectBox,
        Base64Upload,
        DxPopup
    }
};
</script>
<style scoped>

</style>