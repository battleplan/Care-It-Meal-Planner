<template>
    <div class="recipe-detail">
        <!-- <h1>Recipe Detail</h1>
        
        <pre>
            {{ recipe }}
        </pre> -->
        <poster v-bind:recipe="this.recipe"></poster>
    </div>
</template>

<script>
    import axios from 'axios';
    import Poster from '../components/Poster.vue';

    export default {
        name: 'recipe-detail',
        prop:{
            id: 1,
        },
        components:{
            Poster
        },
        data() {
            return {
                recipe: {
                    name: 'blank',
                    id: 1,
                }
            }
        },
        methods: {
            getRecipe(id) {
                console.log(id);
            }
        }, 
        created() {
            //this.geRecipe(this.$route.params.id);
        },
        mounted () {
    axios
      .get(`${process.env.VUE_APP_REMOTE_API}/meal/${this.$route.params.id}`)
      .then(response => (this.recipe = response.data))
  }
    }
</script>