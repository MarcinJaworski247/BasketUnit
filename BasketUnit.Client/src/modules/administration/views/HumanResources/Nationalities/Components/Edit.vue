<template>
    <form @submit.prevent="editNationality">
        <DxValidationGroup :ref="`validationGroup`">
        
        <div class="form-group">
            <div class="row" style="height: 200px;">
                <div class="col-12">
                    <div style="width: 150px; height: 150px; background-color: grey;">
                        <img v-if="Flag.length" style="width: 150px; margin: auto; display: block;" v-bind:src="'data:image/jpeg;base64,'+Flag"/>
                        <img v-if="Flag.length<=0" style="width: 150px; margin: auto; display: block;" v-bind:src="'https://cdn4.iconfinder.com/data/icons/small-n-flat/24/user-alt-512.png'"/>
                    </div>
                    <div class="mt-2">
                        <DxButton text="Wybierz zdjęcie" @click="showAvatarUpload" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Nazwa</label>
                    <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
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
            <base64-upload class="mb-2" style="width: 150px; height: 150px; margin:auto;" :imageSrc="'data:image/jpeg;base64,'+Flag" @change="onChangeImage">Wybierz flagę</base64-upload>
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
    DxValidator,
    DxPopup
} from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import Base64Upload from 'vue-base64-upload'
import { DxRequiredRule, DxCustomRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationEditNationalityStore";

export default {
    name: "nationalityEdit",
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
        ...mapGetters(store, ["getForm"]),
        ...mapFields(store, [
            "editForm.Name",
            "editForm.Flag"
        ])
    },
    methods: {
        ...mapActions(store, ["editNationality"]),
        ...mapMutations(store, ["resetForm"]),
        closePopup: function () {
            this.$emit("closeEdit");
            this.resetForm();
        },
        closePopupOnSave: function (e) {
            let validateResult = e.validationGroup.validate();
            if(validateResult.isValid) {
                this.showSuccessNotify();
                this.$emit("closeEdit");
            }
        },
        showSuccessNotify() {
            this.$nextTick(() => {
                notify("Zapisano", "success", 500);
            });
        },
        onChangeImage(file) {
            this.Flag = file.base64;
        },
        showAvatarUpload() {
            this.uploadPopup.popupVisible = true;
        },
        hideAvatarUpload() {
            this.uploadPopup.popupVisible = false;
        }
    },
    mounted(){
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
        DxPopup,
        Base64Upload
    }
};
</script>
<style scoped>

</style>