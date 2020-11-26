<template>
    <div >
        <div >
            {{ cellData.Text }}
        </div>
    </div>
</template>
<script>
export default {
    props: {
        cellData: {
            type: Object,
            default: () => {}
        }
    },
    methods: {
  }
}
</script>
<style>
.day-cell {
    height: 100%;
    background-position: center center;
    background-repeat: no-repeat;
}

.employee-1 {
    background-color: rgba(86, 202, 133, 0.1);
}

.employee-2 {
    background-color: rgba(255, 151, 71, 0.1);
}

.employee-weekend-1 {
    background-color: rgba(86, 202, 133, 0.2);
}

.employee-weekend-2 {
    background-color: rgba(255, 151, 71, 0.2);
}
.dx-theme-material .name h2 {
    font-size: 28px;
}
</style>