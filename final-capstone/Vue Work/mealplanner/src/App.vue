<template>
  <div id="app">
    <navigation></navigation>
    <search-bar></search-bar>
    <card-slider></card-slider>
    
    <home-menu>
 </home-menu>
  </div>
</template>

<script>
import HomeMenu from './components/HomeMenu.vue'
import Navigation from './components/Navigation.vue'
import CardSlider from './components/CardSlider.vue'
import SearchBar from './components/SearchBar.vue'

export default {
  name: 'app',
  components: {
    HomeMenu,
    Navigation,
    CardSlider,
    SearchBar
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
