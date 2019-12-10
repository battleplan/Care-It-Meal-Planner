using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlannerTest.DAL;
using MealPlannerTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerTest.Controllers
{
    public class RecipeController : Controller
    {

        private IRecipeSqlDAO recipeDAO;

        public RecipeController(IRecipeSqlDAO recipeDAO)
        {
            this.recipeDAO = recipeDAO;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                // TODO Preserve model and display error messages on the form.  We did this when it was on a separate page.
                // I didn't want to mess with it here given the time limit, but my thought would've been to use ViewData, or maybe a partial view with the Model of the Puppy object.

                IList<Recipe> recipes = recipeDAO.GetRecipes();
                return View("Index", recipes);

            }

            recipeDAO.SaveRecipe(recipe);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            Recipe recipe = recipeDAO.GetSingleRecipe(1);
            return View(recipe);
        }

    }
}