<template>
  <div>
    <div class="centered-div">
      <img
        v-if="badge.length"
        style="width: 150px;"
        v-bind:src="'data:image/jpeg;base64,' + badge"
      />
    </div>
    <h3 class="centered-div mb-4">{{ name }}</h3>
  </div>
</template>
<script>
import { mapFields } from "vuex-map-fields";
import { mapActions } from "vuex";

const STORE = "StatisticsStore";

export default {
  name: "teamInfo",
  computed: {
    ...mapFields(STORE, ["teamForm.name", "teamForm.badge"]),
  },
  methods: {
    ...mapActions(STORE, ["setTeamForm"]),
  },
  mounted() {
    this.setTeamForm();
  },
};
</script>
<style scoped>
.centered-div {
  justify-content: center;
  display: flex;
}
</style>
