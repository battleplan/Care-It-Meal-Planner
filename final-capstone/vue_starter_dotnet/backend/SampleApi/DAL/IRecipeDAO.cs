using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    interface IRecipeDAO
    {
        IList<Recipe> GetAllRecipes();

        Recipe GetRecipeById(int id);

        IList<Recipe> GetUserRecipes(string username, bool isFavorite);

        IList<Recipe> GetUserRecipeByCategory(string category, string username);

        IList<Recipe> GetUserRecipeByVegetarian(bool isVegetarian, string username);

        IList<Recipe> GetUserRecipeByGlutenFree(bool isGlutenFree, string username);

        IList<Recipe> GetUserRecipeByVegan(bool isVegan, string username);

        bool CreateRecipe(Recipe newRecipe);

        bool EditRecipe(Recipe oldRecipe);

        bool DeleteRecipe(Recipe recipe);
    }
}
