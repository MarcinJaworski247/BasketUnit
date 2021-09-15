<template>
  <div class="condition-tile">
    <div>
      <h3 class="little-header">
        Forma zawodnika:
      </h3>
    </div>
    <div class="condition" v-if="getPlayerCondition === 0">
      <span class="declining-arrow">&#8600;</span>
    </div>
    <div class="condition" v-else-if="getPlayerCondition === 1">
      <span class="stable-arrow">&#8594;</span>
    </div>
    <div class="condition" v-else-if="getPlayerCondition === 2">
      <span class="rising-arrow">&#8599;</span>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";

const STORE = "TeamPlayerDetailsStore";

export default {
  computed: {
    ...mapGetters(STORE, ["getPlayerCondition"]),
  },
  methods: {
    ...mapActions(STORE, ["setPlayerCondition"]),
  },
  mounted() {
    this.setPlayerCondition();
  },
};
</script>
<style scoped>
.declining-arrow {
  color: red;
  font-size: 56px;
  font-weight: 700;
  text-align: center;
}
.stable-arrow {
  color: black;
  font-size: 56px;
  font-weight: 700;
}
.rising-arrow {
  color: green;
  font-size: 56px;
  font-weight: 700;
}

.condition-tile {
  border: 1px solid black;
  padding: 8px;
  border-radius: 5px;
  margin-bottom: 8px;
  width: 250px;
}
.condition {
  text-align: center;
}
.little-header {
  color: #4d4d4d;
}
</style>
