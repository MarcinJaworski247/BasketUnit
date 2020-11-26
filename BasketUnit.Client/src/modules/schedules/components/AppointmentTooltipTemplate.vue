<template>
  <div class="movie-tooltip">
    <!-- <img :src="movieData.image"> -->
    <div class="movie-info">
      <div class="movie-title">
       {{ this.templateTooltipModel.appointmentData.subject }}
      </div>
    <div>
        <div v-if="this.templateTooltipModel.appointmentData.excercise">{{ this.templateTooltipModel.appointmentData.excercise }}</div>
        <div v-if="this.templateTooltipModel.appointmentData.homeTeamBadge"><img v-bind:src="'data:image/jpeg;base64,'+this.templateTooltipModel.appointmentData.homeTeamBadge"/></div>
        <div v-if="this.templateTooltipModel.appointmentData.awayTeamBadge"><img v-bind:src="'data:image/jpeg;base64,'+this.templateTooltipModel.appointmentData.awayTeamBadge"/></div>
        <div v-if="this.templateTooltipModel.appointmentData.teams">{{ this.templateTooltipModel.appointmentData.teams }}</div>
        <div v-if="this.templateTooltipModel.appointmentData.arena">{{ this.templateTooltipModel.appointmentData.arena }}</div>
      </div>
      <div>
      </div>
    </div>
  </div>
</template>
<script>

import Query from 'devextreme/data/query';

const dayOfWeekNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];


export default {
  props: {
    scheduler: {
      type: Object,
      default: () => { }
    },
    templateTooltipModel: {
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
  .appointment-content {
    width: 360px;
    margin-top: 3px;
  }

  .dx-popup-content .appointment-content {
    margin-top: 7px;
    height: 50px;
  }

  .appointment-badge {
    text-align: center;
    float: left;
    margin-right: 12px;
    color: white;
    width: 28px;
    height: 28px;
    font-size: 20px;
    line-height: 20px;
    border-radius: 28px;
    margin-top: 5px;
    display: flex;
    justify-content: center;
    flex-direction: column;
  }

  .appointment-dates {
    color: #959595;
    font-size: 12px;
    text-align: left;
    float: left;
  }

  .appointment-text {
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    width: 270px;
    font-size: 15px;
    text-align: left;
    float: left;
  }

  .delete-appointment {
    position: relative;
    border: none;
    box-shadow: none;
    top: -8px;
    height: 50px;
  }

    .delete-appointment .dx-button-content {
      width: 50px;
      height: 50px;
      padding-left: 4px;
    }

    .delete-appointment.dx-state-hover,
    .dx-list-item.dx-state-hover .dx-button {
      box-shadow: none;
      background-color: inherit;
    }

    .delete-appointment .dx-icon-trash {
      color: #337ab7 !important;
      font-size: 23px !important;
    }
</style>
