using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    /// <summary>
    /// api for getting the recipes for our project
    /// </summary>
    [Route("api/meal")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {
        private  IRecipeDAO dao;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dao"></param>
        public MealPlanController(IRecipeDAO dao)
        {
            this.dao = dao;
        }
        /// <summary>
        /// API call for getting ALL the recipes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IList<Recipe>> GetAll()
        {
            IList<Recipe> recipes = dao.GetAllRecipes();

            // Return 200 OK
            return Ok(recipes);
        }
        /// <summary>
        /// API call for getting ALL the ingredients
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/ingredients", Name = "Ingredients")]
        public ActionResult<IList<Ingredient>> GetIngredients()
        {
            IList<Ingredient> ingredients = dao.GetAllIngredients();

            // Return 200 OK
            return Ok(ingredients);
        }
        /// <summary>
        /// API call for getting a scpecific recipe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetRecipeById")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            Recipe recipe = dao.GetRecipeById(id);
            
            if(recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
        /// <summary>
        /// API call for adding a recipe to the database
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Recipe> AddRecipe([FromBody]Recipe recipe)
        {
            bool worked = dao.CreateRecipe(recipe);
            if (worked)
            {
                return CreatedAtRoute("GetRecipeById", new { id = recipe.Id }, recipe);
            }
            return null;
        }

        /// <summary>
        /// API call for deleting a recipe from a database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteRecipe(int id)
        {
            Recipe recipe = dao.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            dao.DeleteRecipe(recipe);
            return NoContent();
        }

        /// <summary>
        /// Modifies a recipe in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedRecipe"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult ModifyRecipe([FromBody]Recipe updatedRecipe)
        {
            Recipe existingItem = dao.GetRecipeById(updatedRecipe.Id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updatedRecipe.Name;
            existingItem.Instructions = updatedRecipe.Instructions;
            existingItem.Ingredients = updatedRecipe.Ingredients;

            dao.EditRecipe(existingItem);

            return NoContent();
        }

        /// <summary>
        /// API call for adding to the meal plan database
        /// </summary>
        /// <param name="mealPlan"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MealPlan> AddToMealPlan([FromBody]MealPlan mealPlan)
        {
            bool worked = dao.AddToMealPlan(mealPlan);
            if (worked)
            {
                return NoContent();
            }
            return null;
        }

        /// <summary>
        /// API call for deleting from the meal plan database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteFromMealPlan([FromBody]MealPlan mealPlan)
        {
            bool worked = dao.RemoveFromMealPlan(mealPlan);
            if (worked)
            {
                return NoContent();
            }
            return null;
        }

    }
}