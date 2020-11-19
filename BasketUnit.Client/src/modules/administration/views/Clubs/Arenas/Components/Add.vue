<template>
    <form @submit.prevent="addArena">
        <DxValidationGroup :ref="`validationGroup`">
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
                    <label class="col-xs-12">Address</label>
                    <div class="col-xs-12">
                        <DxTextBox v-model="Address">
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
                    <label class="col-xs-12">Pojemność</label>
                    <div class="col-xs-12">
                        <DxNumberBox v-model="Capacity">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                        </DxNumberBox>
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
    DxNumberBox
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationArenaStore";

export default {
    name: "arenaAdd",
    created(){

    },
    data(){
        return {

        };
    },
    computed: {
        ...mapGetters(store, ["getForm"]),
        ...mapFields(store, [
            "addForm.Name",
            "addForm.Address",
            "addForm.Capacity"
        ])
    },
    methods: {
        ...mapActions(store, ["addArena"]),
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
    },
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxNumberBox,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup
    }
};
</script>
<style scoped>

</style>