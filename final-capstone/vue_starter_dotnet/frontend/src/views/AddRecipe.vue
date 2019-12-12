<template>
  

<div id="formadd" class="container">
  <form @submit.prevent="addrecipe">
    <ul class="flex-outer">
      <li>
        <label for="name">Recipe Name</label>
        <input type="text" id="name" v-model="recipe.name" placeholder="Enter your recipe name here">
      </li>
      <li>
        <label for="instructions">Instructions:</label>
        <input type="textarea" id="instructions" v-model="recipe.instructions" placeholder="How do you make the recipe?">
      </li>
      <li>
        <label for="cooktime">Cook Time</label>
        <input type="number" id="cooktime" v-model="recipe.cooktime" placeholder="Cook Time">
      
        <label for="preptime">Prep Time </label>
        <input type="number" id="preptime" v-model="recipe.preptime" placeholder="Prep Time">
      </li>
      <li>
        <label for="servings">Servings</label>
        <input type="number" id="servings" v-model="recipe.servings" placeholder="Servings">

        <label for="category">Category</label>
        <input type="text" id="category" v-model="recipe.category" placeholder="i.e.  American, Italian, Mexican">
      </li>
      <li>
        
        <ul class="flex-inner">
          <li>
            <input type="checkbox" id="vegan" v-model="recipe.vegan">
            <label for="vegan">Vegan?</label>
          </li>
          <li>
            <input type="checkbox" id="vegetarian" v-model="recipe.vegetarian">
            <label for="vegetarian">Vegetarian?</label>
          </li>
          <li>
            <input type="checkbox" id="glutenfree" v-model="recipe.glutenfree">
            <label for="glutenfree">GF?</label>
          </li>
        </ul>
      </li>
      <li>
        <button type="submit">Submit</button>
      </li>
    </ul>
  </form>
</div>


</template>

<script>

export default {
  data () {
    return {
      recipe: {
      name: 'Form Test Recipe',
      instructions: '1. Make Food - 2. Eat Food',
      vegan: true,
      vegetarian: false,
      glutenfree: false,
      cooktime: 30,
      preptime: 40,
      servings: 10,
      difficulty: 'Super Easy',
      category: 'American',
      ingredients:[{id: 99, name: 'testIngredient1'}, {id: 100, name: 'testIngredient2'}]
      },
    }
  },
  methods: {
    addrecipe() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/meal`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.recipe),
      })
        .then((response) => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then((token) => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, '');
            }
            auth.saveToken(token);
            this.$router.push('/');
          }
        })
        .catch((err) => console.error(err));
    },
  },

}
</script>

<style scoped>


#formadd {
  font: normal 18px/1.5 "Fira Sans", "Helvetica Neue", sans-serif;
  background: #fba919;
  color: #fff;
  padding: 50px 0;
}

.container {
  width: 80%;
  max-width: 1200px;
  margin: 0 auto;
}

.container * {
  box-sizing: border-box;
}

.flex-outer,
.flex-inner {
  list-style-type: none;
  padding: 0;
}

.flex-outer {
  max-width: 800px;
  margin: 0 auto;
}

.flex-outer li,
.flex-inner {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
}

.flex-inner {
  padding: 0 8px;
  justify-content: space-between;  
}

.flex-outer > li:not(:last-child) {
  margin-bottom: 20px;
}

.flex-outer li label,
.flex-outer li p {
  padding: 8px;
  font-weight: 300;
  letter-spacing: .09em;
  text-transform: uppercase;
}

.flex-outer > li > label,
.flex-outer li p {
  flex: 1 0 120px;
  max-width: 220px;
}

.flex-outer > li > label + *,
.flex-inner {
  flex: 1 0 220px;
}

.flex-outer li p {
  margin: 0;
}

.flex-outer li input:not([type='checkbox']),
.flex-outer li textarea {
  padding: 15px;
  border: none;
}

.flex-outer li button {
  margin-left: auto;
  padding: 8px 16px;
  border: none;
  background: #333;
  color: #f2f2f2;
  text-transform: uppercase;
  letter-spacing: .09em;
  border-radius: 2px;
}

.flex-inner li {
  width: 100px;
}


</style>