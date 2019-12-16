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
                recipe: {name:''},
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
        //HERE WE DO A REDIRECT BACK TO THE (UPDATED) DETAILS PAGE
    }
            
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