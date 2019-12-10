<template>
<div>
<div id="recipes">
  {{ recipe }} 
</div>
  <h1>Text</h1>

</div>
</template>

<script>
import axios from 'axios';
export default {
  data () {
    return {
      recipe: null
    }
  },
  mounted () {
    axios
      .get('https://localhost:44392/api/meal')
      .then(response => (this.info = response))
  }
}
</script>

<style>

</style>