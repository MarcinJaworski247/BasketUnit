<template>
  <div class="injured-players-row">
    <div class="row-header">Kontuzje</div>
    <div class="flexxin">
      <div v-for="item in injuredPlayers" v-bind:key="item.id">
        <Injury :injuredPlayer="item" />
      </div>
    </div>
  </div>
</template>

<script>
import Injury from "@/components/Dashboard/Injuries/Injury";

export default {
  name: "injuriesList",
  props: {
    injuredPlayers: {
      type: Array,
      required: true,
    },
  },
  components: {
    Injury,
  },
};
</script>

<style scoped>
.injured-players-row {
  background: rgb(245, 245, 245);
  border-radius: 10px;
  padding: 10px;
  margin-bottom: 50px;
  width: 100%;
  margin-right: 10px;
  /* display: flex; */
  box-shadow: 2px 2px #cecece;
}
.row-header {
  font-size: 24px;
  color: #4d4d4d;
  margin-bottom: 10px;
}
.flexxin {
  display: flex;
}
</style>
