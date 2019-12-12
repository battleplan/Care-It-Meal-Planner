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
    <login-box></login-box>
  </div>
</template>

<script>
/* import Navigation from './components/Navigation.vue'
import CardSlider from './components/CardSlider.vue'
import SearchBar from './components/SearchBar.vue' */

import LoginBox from './components/LoginBox.vue'
export default {
  name: 'app',
  components: {
/*      Navigation,
    CardSlider,
    SearchBar */
    LoginBox
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
