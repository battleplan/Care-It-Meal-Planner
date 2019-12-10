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

        Recipe GetSingleRecipe(int id);

        void SaveRecipe(Recipe recipe);
    }
}
