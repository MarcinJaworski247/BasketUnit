<template>
    <form @submit.prevent="addArena">
        
        <DxValidationGroup :ref="`validationGroup`">
        <div class="form-group">
            <div class="row">
                <div class="col-6">
                    <label>Nazwa</label>
                    <DxTextBox v-model="Name">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextBox>
                </div>
                <div class="col-6">
                    <label>Pojemność</label>
                    <DxNumberBox v-model="Capacity">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxNumberBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Adres</label>
                    <DxTextArea v-model="Address">
                        <DxValidator>
                            <DxRequiredRule message="Pole jest wymagane"/>
                        </DxValidator>
                    </DxTextArea>
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
    </form>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxNumberBox,
    DxTextArea
} from 'devextreme-vue';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import { mapGetters, mapActions, mapMutations } from "vuex";
import notify from 'devextreme/ui/notify';
import { mapFields } from "vuex-map-fields";
const store = "AdministrationArenaStore";

export default {
    name: "arenaAdd",
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
    destroyed() {
        this.resetForm();
    },
    components: {
        DxTextBox,
        DxButton,
        DxNumberBox,
        DxValidator,
        DxRequiredRule,
        DxValidationGroup,
        DxTextArea
    }
};
</script>