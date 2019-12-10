using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.DAL;
using SampleApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers
{
    public class RecipeController : Controller
    {

        private IRecipeDAO recipeDAO;

        public RecipeController(IRecipeDAO recipeDAO)
        {
            this.recipeDAO = recipeDAO;
        }


        public IActionResult Index()
        {
            IList<Recipe> recipes = recipeDAO.GetAllRecipes();
            return View(recipes);
        }

        //[HttpGet]
        //public IActionResult AddRecipe()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddRecipe(RecipeU recipe)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(recipe);
        //    }

        //    recipeDAO.SaveRecipe(recipe);
        //    return RedirectToAction("Index");

        //}


        [HttpPost]
        public IActionResult Detail(int id)
        {
            Recipe recipe = recipeDAO.GetRecipeById(id);
            return View(recipe);
        }

    }
}