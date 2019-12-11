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
            IList<Recipe> reviews = dao.GetAllRecipes();

            // Return 200 OK
            return Ok(reviews);
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
        public ActionResult ModifyRecipe(int id, [FromBody]Recipe updatedRecipe)
        {
            Recipe existingItem = dao.GetRecipeById(id);

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
    }
}