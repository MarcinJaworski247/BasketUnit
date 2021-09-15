<template>
  <DxDataGrid
    id="gridContainer"
    :data-source="getLastGamesStats"
    key-expr="opponent"
    :allow-column-reordering="true"
    :row-alternation-enabled="true"
    class="main-datagrid"
  >
    <DxColumn
      data-field="opponent"
      alignment="left"
      caption="Przeciwko"
      data-type="string"
    />
    <DxColumn
      data-field="gameTime"
      alignment="center"
      caption="Data"
      data-type="date"
      format="dd/MM"
    />
    <DxColumn
      data-field="points"
      alignment="center"
      caption="Punkty"
      data-type="number"
    />
    <DxColumn
      data-field="assists"
      alignment="center"
      caption="Asysty"
      data-type="number"
    />
    <DxColumn
      data-field="rebounds"
      alignment="center"
      caption="Zbiórki"
      data-type="number"
    />
    <DxColumn
      data-field="steals"
      alignment="center"
      caption="Przechwyty"
      data-type="number"
    />
    <DxColumn
      data-field="blocks"
      alignment="center"
      caption="Bloki"
      data-type="number"
    />
    <DxColumn
      data-field="fouls"
      alignment="center"
      caption="Faule"
      data-type="number"
    />
    <DxColumn
      data-field="gameId"
      alignment="center"
      caption=""
      cell-template="actionsCellTemplate"
      :allow-search="false"
      :allow-filtering="false"
      width="100"
    />
    <div slot="actionsCellTemplate" slot-scope="{ data }">
      <DxButton
        @click="
          () => {
            $router.push({
              name: 'games.details',
              params: { gameId: data.data.gameId },
            });
          }
        "
        hint="Szczegóły"
        title="Szczegóły"
        icon="fas fa-chevron-right"
        class="datagrid-button"
        type="normal"
      />
    </div>
  </DxDataGrid>
</template>
<script>
import { mapGetters, mapActions } from "vuex";

// DevExtreme
import { DxDataGrid, DxColumn } from "devextreme-vue/data-grid";

// store
const STORE = "TeamPlayerDetailsStore";

export default {
  components: {
    DxColumn,
    DxDataGrid,
  },
  computed: {
    ...mapGetters(STORE, ["getLastGamesStats"]),
  },
  methods: {
    ...mapActions(STORE, ["setLastGamesStats"]),
  },
  mounted() {
    this.setLastGamesStats();
  },
};
</script>
