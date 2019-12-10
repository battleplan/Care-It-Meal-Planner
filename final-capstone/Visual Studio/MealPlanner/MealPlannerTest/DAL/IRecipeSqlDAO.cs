using MealPlannerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlannerTest.DAL
{
    public interface IRecipeSqlDAO
    {
        IList<Recipe> GetRecipes();

        RecipeVM GetSingleRecipe(int id);

        void SaveRecipe(RecipeU recipe);
    }
}
