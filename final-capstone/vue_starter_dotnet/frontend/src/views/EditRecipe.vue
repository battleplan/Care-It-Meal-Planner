<template>
    <div>
        <pre>
            {{  recipe  }}
        </pre>
        <form @submit.prevent="modRecipe">
            <input type="text" v-model="recipe.name"   />
        </form>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'edit-recipe',
        prop:{
            id: 0,
        },
        components:{
        },
        data() {
            return {
                recipe: null,
            }
        },
        methods: {
            getRecipe(id) {
                console.log(id);
            },
            modRecipe() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/meal/${this.recipe.id}`, {
        method: 'PUT',
        headers: {
          
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.recipe),
      })
        
        .catch((err) => console.error(err));
    }
            
        }, 
        onCreated() {
            //this.geRecipe(this.$route.params.id);
            axios
      .get(`${process.env.VUE_APP_REMOTE_API}/meal/${this.$route.params.id}`)
      .then(response => (this.recipe = response.data))
        },
        mounted () {
    axios
      .get(`${process.env.VUE_APP_REMOTE_API}/meal/${this.$route.params.id}`)
      .then(response => (this.recipe = response.data))
  }
    }
</script>

<style scoped>

</style>