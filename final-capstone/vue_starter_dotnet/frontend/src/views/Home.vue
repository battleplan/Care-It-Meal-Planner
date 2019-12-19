<template>
  <div class="home">
    <h1>Epstein didn't kill himself</h1>
    <h2><img class="careit" src="../../public/Careit.png"></h2>
    
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

h2 {
  font-family: 'Nunito', sans-serif;
  z-index: 99;
  text-shadow: 3px 3px 8px black;
  color: white;
}

.careit {
  width: 550px;
}
</style>