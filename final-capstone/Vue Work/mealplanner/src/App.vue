<template>
  <div id="app">
    <navigation></navigation>
    <card-slider></card-slider>
    <home-menu>
    </home-menu>
  </div>
</template>

<script>
import HomeMenu from './components/HomeMenu.vue'
import Navigation from './components/Navigation.vue'
import CardSlider from './components/CardSlider.vue'
export default {
  name: 'app',
  components: {
    HomeMenu,
    Navigation,
    CardSlider
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
