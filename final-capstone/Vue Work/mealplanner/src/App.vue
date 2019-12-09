<template>
  <div id="app">
    <navigation></navigation>
    <home-menu>
    </home-menu>
  </div>
</template>

<script>
import HomeMenu from './components/HomeMenu.vue'
import Navigation from './components/Navigation.vue'

export default {
  name: 'app',
  components: {
    HomeMenu,
    Navigation
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
