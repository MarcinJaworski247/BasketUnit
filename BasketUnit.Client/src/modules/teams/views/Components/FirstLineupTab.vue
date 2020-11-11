<template>
<div class="container">
    <!-- <div class="players-list-draggable">
        <div v-for="item in firstLineup" v-bind:key="item.Id">
            <div>
                <img v-bind:src="'data:image/jpeg;base64,'+item.Avatar" />
            </div>
            <span>
                {{ item.FullName }}, {{ item.Position }}
            </span>
        </div>
    </div> -->
    <div class="court-area">
    </div>
</div>
</template>
<script>
export default {
    name: "firstLineup",
    props: {
        playersList: Array,
        firstLineup: Array
    },
    data() {
        return {
             
        };
    },
    created() {

    },
    computed: {

    },
    methods: {

    },

}
</script>