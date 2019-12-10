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
            IList<Recipe> recipes = recipeDAO.GetRecipes();
            return View(recipes);
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipe(RecipeU recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            recipeDAO.SaveRecipe(recipe);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Detail(int id)
        {
            RecipeVM recipe = recipeDAO.GetSingleRecipe(id);
            return View(recipe);
        }

    }
}