<template>
  

<div id="formadd" class="container">
  <form @submit.prevent="addrecipe">
    <ul class="flex-outer">
      <h2 align="center">Add a Recipe to the Database</h2>
      <li>
        <label for="name">Recipe Name</label>
        <input type="text" id="name" v-model="recipe.name" placeholder="Enter your recipe name here">
      </li>
      <li>
        <label for="instructions">Instructions:</label>
        <input type="textarea" rows="20" cols="50" id="instructions" v-model="recipe.instructions" placeholder="How do you make the recipe?">
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

        <label for="difficulty">Difficulty</label>
        <input type="text" id="difficulty" v-model="recipe.difficulty" placeholder="i.e.  Easy,Challenging">
      </li>
      <li>
        <label for="category">Category</label>
        <input type="text" id="category" v-model="recipe.category" placeholder="i.e.  American, Italian, Mexican">
        
      </li>   
            <li>
        <label for="ImageURL">Image URL</label>
        <input type="text" id="ImageURL" v-model="recipe.ImageURL" placeholder="Enter the location of the image">
      </li>      
      <li>
       
      <li>
        <b-form-select v-model="recipe.ingredients" :options="ingredients"></b-form-select>
        </li>    
        
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
            <label for="glutenfree">Gluten-Free?</label>
          </li>
        </ul>
      <!-- </li> -->
      <li>
        <button type="submit">Submit</button>
      </li>
    </ul>
  </form>

<!-- <form @submit.prevent="addingredient">
<li>
<label for="name">Ingredient Name</label>
<input type="text" id="name" v-model="ingredient.name" placeholder="Enter your ingredient here">
</li>
<button type="submit">Add Ingredient to Database</button>
</form>
<hr>

<form @submit.prevent="getingredients">
<button type="submit">Load Ingredients</button>
</form> -->

<!-- <form>
<div class="col-md-6 form-group">
Add Ingredients
<input v-model="recipe.ingredients" type="text" list="ingredients" />
<datalist id="ingredients">
<option v-for="ingredient in this.ingredients" v-bind:key="ingredient.id">{{ingredient.name}} </option>
</datalist>
</div>
<button @click="addingredienttorecipe">Add Ingredient to Recipe</button>

  </form> -->


<!-- <form @submit.prevent="">
<div>
Add Ingredients
<input v-bind="this.recipe.ingredients" type="text" list="ingredients" />
<datalist id="ingredients">
<option v-for="ingredient in this.ingredients" v-on:click.left="addingredienttorecipe(ingredient)" v-bind:key="ingredient.id">{{ingredient.name}} </option>
</datalist>
</div>
<button type="submit">Add Ingredient to Recipe</button>
</form>


<form @submit.prevent="removeingredienttorecipe">
<div>
Remove Ingredients
<input v-model="recipe.ingredients" type="text" list="ingredients" />
<datalist id="ingredients">
<option v-for="ingredient in this.recipe.ingredients" v-bind:key="ingredient.id">{{ingredient.name}} </option>
</datalist>
</div>
<button type="submit">Remove Ingredient from Recipe</button>
</form> -->

</div>

</template>

<script>
import axios from 'axios';

export default {
  data () {
    return {
      recipe: {
      name: '',
      instructions: '',
      vegan: false,
      vegetarian: false,
      glutenfree: false,
      cooktime: 30,
      preptime: 60,
      servings: 4,
      difficulty: '',
      category: '',
      ImageURL:'',
      ingredients:[]
      },
      ingredients: [],
      ingredient: {
        name: '',
      },
      returnrecipe: {
      },
    }
  },
methods: {

addrecipe() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/meal/`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.recipe),
        
      })
    .then(response => {this.returnrecipe = response.data; 
    const status = 
            JSON.parse(response.status);
    if (status == '201') {
          this.$router.push('/');
          }})
    .catch(error => {console.log(error)});
},

addingredienttorecipe(){
console.log('Is this being reached?');

item => {
this.recipe.ingredients.unshift(item)};
console.log(this.recipe.ingredients);

},

removeingredienttorecipe(){
this.recipe.ingredients.shift();
},


getingredients () {
    axios
      .get(`${process.env.VUE_APP_REMOTE_API}/meal/api/ingredients`)
     .then(response => this.ingredients = response.data)
  },

addingredient () {
      fetch(`${process.env.VUE_APP_REMOTE_API}/meal/addingredient`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.ingredient),
        
      })
     .then(response => this.responseData = response.data)
    .catch(error => {console.log(error)});
},

  }
}
  
</script>

<style scoped>

textarea {
  border: 1px solid #888; 
}

#formadd {
  font: normal 18px/1.5 "Fira Sans", "Helvetica Neue", sans-serif;
  background: rgba(0, 0, 0, 0.72);
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
  background: #fba919;
  color: #f2f2f2;
  text-transform: uppercase;
  letter-spacing: .09em;
  border-radius: 2px;
}

.flex-inner li {
  width: 100px;
}


</style>