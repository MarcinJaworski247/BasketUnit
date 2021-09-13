<template>
  <div>
    <div class="main-header">
      <h3 class="main-header-title">Protokół meczu</h3>
    </div>
    <GameProtocolDataGrid />
    <div class="d-flex end-xs mt-5 mb-4">
      <DxButton
        :use-submit-behavior="false"
        type="normal"
        styling-mode="outlined"
        text="Wróć"
        @click="
          () => {
            $router.push({ name: 'protocols.index' });
          }
        "
      />
    </div>
  </div>
</template>
<script>
// DevExtreme
import { DxButton } from "devextreme-vue";
import GameProtocolDataGrid from "../components/GameProtocolDataGrid.vue";

export default {
  name: "protocolEdit",
  components: {
    DxButton,
    GameProtocolDataGrid,
  },
};
</script>
<style scoped>
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
}
</style>
