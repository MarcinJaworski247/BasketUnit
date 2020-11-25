<template>
    <form @submit.prevent="editTeam">
        <DxValidationGroup :ref="`validationGroup`">

        <div class="form-group">
            
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
    </form>
</template>
<script>
import {
    DxTextBox,
    DxButton,
    DxSelectBox
} from 'devextreme-vue';
import notify from 'devextreme/ui/notify';
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import { mapGetters, mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";
const store = "AdministrationEditTeamStore";

export default {
    name: "teamEdit",
    created(){

    },
    data(){
        return {

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
        DxSelectBox
    }
};
</script>
<style scoped>

</style>