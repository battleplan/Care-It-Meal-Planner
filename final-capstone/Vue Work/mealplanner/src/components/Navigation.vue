<template>
  <div>
      <nav>
          <router-link :to="{ name: 'Recipes'}">Recipes</router-link>  |  Faves |  Recent
          <img class="nv" src="/img/plus-sign.png">
          <img class="nv" src="/img/magnifying-glass.png">
            <!-- <router-link to="/categories"> </router-link> -->
      </nav>
  </div>
</template>

<script>
export default {

}
</script>

<style>
.nv {
    width: 15px;
    padding-left:10px;
}
</style>