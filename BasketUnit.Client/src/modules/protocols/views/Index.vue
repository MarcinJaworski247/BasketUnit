<template>
  <div class="content">
    <div class="main-header">
      <h3 class="main-header-title">Protokoły</h3>
    </div>
    <ProtocolsDataGrid />
  </div>
</template>
<script>
import ProtocolsDataGrid from "../components/ProtocolsDataGrid.vue";
export default {
  name: "protocols",
  components: {
    ProtocolsDataGrid,
  },
};
</script>
<style scoped>
.main-header-title {
  color: #4d4d4d;
  font-size: 32px;
}
</style>
