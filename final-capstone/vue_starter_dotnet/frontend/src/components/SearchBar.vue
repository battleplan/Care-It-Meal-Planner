<template>
<div>
    <input id="sbar" type="text" v-model="search" placeholder="         Search Recipes "/>
</div>
</template>

<script>
export default {
    name: "search-bar",
    data(){
        return{
            search:''
        }
    },
    methods:{

    },
}
</script>

<style scoped>
#sbar {
    margin: 20px;
    border: 1px solid black;
}
</style>