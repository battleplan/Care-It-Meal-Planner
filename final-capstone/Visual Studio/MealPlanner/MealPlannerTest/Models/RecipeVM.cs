using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlannerTest.Models
{
    public class RecipeVM
    {
        public Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients {get; set;}

        public string[] Instructions
        {
            get
            {
                return Recipe.Instructions.Split("Step");
            }
        }

    }
}
