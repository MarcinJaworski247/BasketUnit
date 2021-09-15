<template>
  <form @submit.prevent="addInjury">
    <DxValidationGroup :ref="`validationGroup`">
      <div class="form-group">
        <div class="row">
          <div class="col-6">
            <label>Kontuzja</label>
            <DxTextBox v-model="AddInjury">
              <DxValidator>
                <DxRequiredRule message="Pole jest wymagane" />
              </DxValidator>
            </DxTextBox>
          </div>
          <div class="col-6">
            <label>Data do</label>
            <DxDateBox v-model="AddInjuredTo">
              <DxValidator>
                <DxRequiredRule message="Pole jest wymagane" />
              </DxValidator>
            </DxDateBox>
          </div>
        </div>
      </div>

      <div class="popup-bottom">
        <DxButton
          :use-submit-behavior="false"
          styling-mode="outlined"
          type="normal"
          text="Anuluj"
          @click="closePopup"
        />
        <DxButton
          :use-submit-behavior="true"
          type="default"
          class="ml-1"
          text="Zapisz"
          @click="closePopupOnSave"
        />
      </div>
    </DxValidationGroup>
  </form>
</template>
<script>
import { mapActions, mapMutations } from "vuex";
import { mapFields } from "vuex-map-fields";

// DevExtreme
import { DxDateBox, DxTextBox, DxButton } from "devextreme-vue";
import { DxValidator, DxRequiredRule } from "devextreme-vue/validator";
import { DxValidationGroup } from "devextreme-vue/validation-group";
import notify from "devextreme/ui/notify";

// store
const STORE = "TeamPlayerDetailsStore";

export default {
  name: "injuryAddPopup",
  computed: {
    ...mapFields(STORE, ["injuriesAdd.AddInjury", "injuriesAdd.AddInjuredTo"]),
  },
  methods: {
    ...mapActions(STORE, ["addInjury"]),
    ...mapMutations(STORE, ["resetInjuryAdd"]),
    closePopup: function() {
      this.$emit("closeAdd");
      this.resetForm();
    },
    closePopupOnSave: function(e) {
      let validateResult = e.validationGroup.validate();
      if (validateResult.isValid) {
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
  destroyed() {
    this.resetInjuryAdd();
  },
  components: {
    DxTextBox,
    DxButton,
    DxValidator,
    DxRequiredRule,
    DxValidationGroup,
    DxDateBox,
  },
};
</script>
