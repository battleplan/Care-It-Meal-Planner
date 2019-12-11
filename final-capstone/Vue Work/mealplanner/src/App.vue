<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Main</router-link>
      <router-link to="/recipes">Recipes</router-link>
    </div>
    <router-view />
<!--     <search-bar></search-bar>
    <card-slider></card-slider>
    <navigation></navigation> -->
    <navie></navie>
  </div>
</template>

<script>
/* import Navigation from './components/Navigation.vue'
import CardSlider from './components/CardSlider.vue'
import SearchBar from './components/SearchBar.vue' */
import Navie from './components/Navie.vue'

export default {
  name: 'app',
  components: {
/*      Navigation,
    CardSlider,
    SearchBar */
    Navie
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
