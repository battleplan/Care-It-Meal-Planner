<template>
<div id="formadd" class="container">
<form id="shopping-list">
  <h2>Meals for Monday</h2>
<table id="shopping-list-table" class="table table-condensed table-hover">
  <thead>
     <tr>
       <th>Meal</th>
       <th>Recipe</th>
       <th>Actions</th>
     </tr>
  </thead>
  <tr v-for="(item, index) in itemsList">
    <td>
      <span v-show="!item.inEditMode">{{ item.meal }}</span>
      <input v-bind:placeholder="item.meal" v-show="item.inEditMode" v-model="item.meal" /> 
    </td>
    <td>
      <span v-show="!item.inEditMode">{{ item.itemName }}</span>
      <input v-bind:placeholder="item.itemName" v-show="item.inEditMode" v-model="item.itemName" />
    </td>
    <td>
      <button type="button" class="btn btn-success" v-show="item.inEditMode" @click="editItemComplete(item)"><i class="fa fa-save"></i> Save  </button>
      <button type="button" class="btn btn-info" v-show="!item.inEditMode" @click="editItem(item)"  ><i class="fa fa-edit"></i> Edit  </button>
      <button type="button" class="btn btn-danger" @click="removeItem(index)"><i class="fa fa-remove"></i> Delete  </button>
    </td>
  </tr>
</table>
  <h4>Add new item</h4>
<div class="row col-md-6">
              <div class="col-md-6 form-group">
                Meal
                 <select v-model="meal">
  <option value="Breakfast">Breakfast</option>
  <option value="Lunch">Lunch</option>
  <option value="Dinner">Dinner</option>
  <option value="Snack">Snack</option>
</select> 
                <!-- <input type="text" v-model="meal" class="checkbox" autofocus> -->
              </div>
              <div class="col-md-6 form-group">
                Recipe
                <select v-model="itemName">
                  <option v-for="recipe in this.recipes" v-bind:key="recipe.id">{{recipe.name}} </option>
</select>
              </div>
  
              <button type="button" @click="addItem" class="btn btn-primary" ><i class="fa fa-plus"></i> Add  </button>
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
}


#shopping-list-table{
  table-layout: fixed;
  width: 50%;
  vertical-align: middle;
}

button {
  margin-left: 2%;
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

</style>