<template>
  <DxDataGrid
    id="gridContainer"
    :data-source="getGamesList"
    :show-borders="true"
    key-expr="id"
    :allow-column-reordering="true"
    :row-alternation-enabled="true"
    class="main-datagrid"
    show-filter-row="true"
  >
    <DxFilterRow :visible="true" :show-operation-chooser="true" />
    <DxColumn
      data-field="homeTeam"
      alignment="left"
      caption="Gospodarze"
      data-type="string"
    />
    <DxColumn
      data-field="awayTeam"
      alignment="left"
      caption="Goście"
      data-type="string"
    />
    <DxColumn
      data-field="arena"
      alignment="left"
      caption="Arena"
      data-type="string"
    />
    <DxColumn
      data-field="date"
      alignment="center"
      caption="Data"
      data-type="date"
      format="dd/MM/yyyy"
    />
    <DxColumn
      data-field="id"
      alignment="center"
      caption=""
      cell-template="actionsCellTemplate"
      :allow-search="false"
      :allow-filtering="false"
      width="100"
    />
    <div slot="actionsCellTemplate" slot-scope="{ data }">
      <router-link
        class="datagrid-btn"
        :to="{ name: 'protocols.edit', params: { gameId: data.value } }"
      >
        <DxButton
          hint="Edytuj"
          icon="fas fa-chevron-right"
          class="datagrid-button"
          type="normal"
        />
      </router-link>
    </div>
  </DxDataGrid>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

// DevExtreme
import { DxButton } from "devextreme-vue";
import { DxDataGrid, DxColumn, DxFilterRow } from "devextreme-vue/data-grid";

// store
const STORE = "ProtocolsStore";

export default {
  computed: {
    ...mapGetters(STORE, ["getGamesList"]),
  },
  methods: {
    ...mapActions(STORE, ["setGamesList"]),
  },
  mounted() {
    this.setGamesList();
  },
  components: {
    DxButton,
    DxDataGrid,
    DxColumn,
    DxFilterRow,
  },
};
</script>
