<template>
    <div>
        <DxChart :data-source="data" /> 
    </div>
</template>
<script>
export default {
    name: "avarageStatsChart",
    props: {
        data: Array
    }
}
</script>
// to do 