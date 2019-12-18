<template>
  <div class="home">
    <h1>Epstein didn't kill himself</h1>
    <card-slider v-bind:data="this.items"></card-slider>
    
  </div>
  
</template>

<script>
import CardSlider from "../components/CardSlider.vue";
import axios from 'axios';

export default {
  name: 'home',
  components: {

    CardSlider,
    

  },data(){
    return {
      items: [],
      }
  },
  mounted () {
    axios
      .get(`https://localhost:5001/api/meal`)
      .then(response => (this.items = response.data))
  }
}
</script>

<style scoped>
h1 {
  font-size:1px
}
</style>