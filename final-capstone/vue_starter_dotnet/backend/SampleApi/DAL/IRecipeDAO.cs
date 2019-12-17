using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IRecipeDAO
    {
        IList<Recipe> GetAllRecipes();

        IList<Ingredient> GetAllIngredients();

        Recipe GetRecipeById(int id);

        IList<Recipe> GetUserRecipes(string username, bool isFavorite);

        IList<Recipe> GetUserRecipeByCategory(string category, string username);

        IList<Recipe> GetUserRecipeByVegetarian(bool isVegetarian, string username);

        IList<Recipe> GetUserRecipeByGlutenFree(bool isGlutenFree, string username);

        IList<Recipe> GetUserRecipeByVegan(bool isVegan, string username);

        bool CreateRecipe(Recipe newRecipe);

        bool CreateIngredient(Ingredient ingredient);

        bool EditRecipe(Recipe recipe);

        bool DeleteRecipe(Recipe recipe);

        bool AddToMealPlan(MealPlan mealPlan);

        bool RemoveFromMealPlan(MealPlan mealPlan);
    }
}
