<template>
    <form @submit.prevent="editReferee">
        <DxValidationGroup :ref="`validationGroup`">
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
                    <label class="col-xs-12">Numer telefonu</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="PhoneNumber">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxTextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Adres email</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="EmailAddress">
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
            <div class="col-xs-6">
                <div class="form-group row">
                    <label class="col-xs-12">Narodowość</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="Nationality">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxTextBox>
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
    DxValidator
} from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { DxRequiredRule } from "devextreme-vue/validator";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "HumanResourcesRefereeEditStore";

export default {
    name: "refereeEdit",
    created(){
    },
    data(){
        return {

        };
    },
    computed: {
        ...mapGetters(store, ["getForm"]),
        ...mapFields(store, [
            "editForm.Id",
            "editForm.FirstName",
            "editForm.LastName",
            "editForm.BirthDate",
            "editForm.Nationality",
            "editForm.EmailAddress",
            "editForm.PhoneNumber"
        ])
    },
    methods: {
        ...mapActions(store, ["editReferee"]),
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
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxValidator,
        DxRequiredRule
    }
};
</script>
<style scoped>

</style>