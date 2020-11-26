<template>
  <div class="showtime-preview">
    <div> </div>
    <div>
      <strong>{{ templateModel.appointmentData.subject }}</strong>
      <div v-if="templateModel.appointmentData.excercise">{{ templateModel.appointmentData.excercise }}</div>
      <div v-if="templateModel.appointmentData.teams">{{ templateModel.appointmentData.teams }}</div>
      <div v-if="templateModel.appointmentData.arena">Arena: {{ templateModel.appointmentData.arena }}</div>
    </div>
    <div>
    </div>
  </div>
</template>
<script>

import Query from 'devextreme/data/query';


const dayOfWeekNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];



export default {
  components: {
  },
  props: {
    scheduler: {
      type: Object,
      default: () => { }
    },
    templateModel: {
      type: Object,
      default: () => { }
    }
  },
  data() {
    return {
      dayOfWeekNames: dayOfWeekNames
    };
  },
  mounted() {
  },
};
</script>
<style scoped>
  .dx-tooltip-wrapper .dx-overlay-content .dx-popup-content {
    padding: 14px;
  }

  .showtime-preview > div:first-child {
    font-size: 12px;
    white-space: normal;
  }

  .showtime-preview > div:not(:first-child) {
    font-size: 11px;
    white-space: normal;
  }

  .movie-tooltip .movie-info {
    display: inline-block;
    margin-left: 10px;
    vertical-align: top;
    text-align: left;
  }

  .movie-tooltip img {
    height: 80px;
    margin-bottom: 10px;
  }

  .movie-tooltip .movie-title {
    font-size: 1.5em;
    line-height: 40px;
  }

  .long-title h3 {
    font-family: 'Segoe UI Light', 'Helvetica Neue Light', 'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana;
    font-weight: 200;
    font-size: 28px;
    text-align: center;
    margin-bottom: 20px;
  }

</style>
