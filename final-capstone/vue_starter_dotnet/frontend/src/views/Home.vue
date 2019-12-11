<template>
  <div class="home">
    <h1>Home</h1>
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
      .get(`${process.env.VUE_APP_REMOTE_API}/meal`)
      .then(response => (this.items = response.data))
  }
}
</script>
