<template>
  <div class="future-workout">
    <div class="workout-icon"><i class="fas fa-running"></i></div>
    <div class="workout-name">{{ practice.workout }}</div>
    <div class="workout-date">{{ practice.date | formatDate }}</div>
  </div>
</template>
<script>
export default {
  name: "upcomingPractice",
  props: {
    practice: {
      type: Object,
      required: true,
    },
  },
};
</script>
<style scoped>
.future-workout {
  border: 3px solid #ff8000;
  border-radius: 10px;
  background: #fff;
  text-align: center;
  margin-right: 20px;
  height: 150px;
  width: 150px;
  box-shadow: 2px 2px #ffb368;
}
.workout-name {
  font-weight: 600;
  font-size: 20px;
}
.workout-date {
  font-weight: 400;
  font-size: 16px;
}
.workout-icon {
  font-size: 36px;
}
</style>
