<template>
<div id="formadd" class="container">
<form id="shopping-list">
  <h2>Meal Planner</h2>
<table id="shopping-list-table" class="table table-condensed table-hover">
  <thead>
     <tr>
       <th>Meal</th>
       <th>Recipe</th>
       <th>Actions</th>
     </tr>
  </thead>
  <tr v-for="(item, index) in itemsList">
    <td align="center">
      <span v-show="!item.inEditMode">{{ item.meal }}</span>
      <input v-bind:placeholder="item.meal" v-show="item.inEditMode" v-model="item.meal" /> 
    </td>
    <td class="NameCell" align="center">
      <span v-show="!item.inEditMode"><router-link class="ItemName" v-bind:to="{name:'recipe', params: {id: item.id}}">{{ item.itemName }}</router-link></span>
      <input v-bind:placeholder="item.itemName" v-show="item.inEditMode" v-model="item.itemName" />
    </td>
    <td align="center">
      <button type="button" class="btn btn-success" v-show="item.inEditMode" @click="editItemComplete(item)"><i class="fa fa-save"></i> Save  </button>
      <button type="button" class="btn btn-info" v-show="!item.inEditMode" @click="editItem(item)"  ><i class="fa fa-edit"></i> Edit  </button>
      <button type="button" class="btn btn-danger" @click="removeItem(index)"><i class="fa fa-remove"></i> Delete  </button>
    </td>
  </tr>
</table>
  
<div align="center" class="row col-md-6 additemform">
  <h4></h4>
              <span class="col-md-6 form-group">
                Meal
                 <select v-model="meal">
  <option value="Breakfast">Breakfast</option>
  <option value="Lunch">Lunch</option>
  <option value="Dinner">Dinner</option>
  <option value="Snack">Snack</option>
</select> 
                <!-- <input type="text" v-model="meal" class="checkbox" autofocus> -->
              </span>
              <span class="col-md-6 form-group">
                Recipe
                <select v-model="itemName">
                  <option v-for="recipe in this.recipes" v-bind:key="recipe.id">{{recipe.name}} </option>
</select>
              </span>
  
              <button type="button" @click="addItem" class="btn-primary" ><i class="fa fa-plus"></i> Add  </button>
              </div>
</form>   

 </div>
</template>

<script>
import axios from 'axios';

export default {
                  el: '#shopping-list',
  data() {
    return {
                  recipes: [],
                  meal: '',
                  itemName: '',
                  itemsList: [],
                  inEditMode: false
              }
  },
    mounted () {
    axios
      .get(`https://localhost:5001/api/meal`)
     .then(response => this.recipes = response.data)
  },

              methods: {

                  addItem: function (){
                      var mealIn = this.meal;
                      var itemNameIN = this.itemName.trim();
                      this.itemsList.push({ 
                        meal: mealIn,
                        itemName: itemNameIN,
                        inEditMode: false
                      });
                      this.clearAll();
                  },
                  clearQuantity: function () {
                      this.quantity = '';
                  },
                  clearItemName: function () {
                      this.itemName = '';
                  },
                  clearAll: function () {
                    this.clearQuantity();
                    this.clearItemName();
                  },
                  removeItem: function (index){
                      this.itemsList.splice(index, 1); //delete 1 element from the array at the position index
                  },
                  editItem:function (item){
                      item.inEditMode = true;
                  },
                  editItemComplete: function (item) {
                      item.inEditMode = false;
                  }
              },
 
}
</script>

<style scoped>
body {
  padding: 1%;
  background-color: #abca
}

h2, h4 {
  font-family: 'Nunito', sans-serif;
  z-index: 99;
  text-shadow: 3px 3px 8px black;
}

th {
    font-family: 'Nunito', sans-serif;
    color: #e0dada;
    font-size: 21px;
}


#shopping-list-table{
  table-layout: fixed;
  width: 100%;
  vertical-align: middle;
}

button {
  margin-left: 2%;
  padding: 5px 40px;
}

button.btn{
  padding: 5px 20px;
}

#formadd {
  font: normal 18px/1.5 "Fira Sans", "Helvetica Neue", sans-serif;
  background: rgba(0, 0, 0, 0.72);
  color: #fff;
  padding: 5px 0;
}

.container {
  width: 60%;
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  justify-content: center;
  margin-top: 50px;
}

* {
  text-decoration: none;
}

.ItemName {
  color: orange;
}

.NameCell{
  justify-content: center;
  width: 90%;
}



</style>