<template>
  <div>
    <div class="row">
      <div class="col-6">
        <label>Punkty</label>
        <DxNumberBox v-model="Points" />
      </div>
      <div class="col-6">
        <label>Asysty</label>
        <DxNumberBox v-model="Assists" />
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <label>Zbiórki</label>
        <DxNumberBox v-model="Rebounds" />
      </div>
      <div class="col-6">
        <label>Przechwyty</label>
        <DxNumberBox v-model="Steals" />
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <label>Bloki</label>
        <DxNumberBox v-model="Blocks" />
      </div>
      <div class="col-6">
        <label>Faule</label>
        <DxNumberBox v-model="Fouls" />
      </div>
    </div>
  </div>
</template>
<script>
import { mapFields } from "vuex-map-fields";

// DevExtreme
import { DxNumberBox } from "devextreme-vue";

// store
const STORE = "ProtocolsEditStore";

export default {
  computed: {
    ...mapFields(STORE, [
      "editForm.Id",
      "editForm.FullName",
      "editForm.Points",
      "editForm.Assists",
      "editForm.Rebounds",
      "editForm.Steals",
      "editForm.Blocks",
      "editForm.Fouls",
    ]),
  },
  components: {
    DxNumberBox,
  },
};
</script>
