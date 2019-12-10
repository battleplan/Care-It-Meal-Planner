using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlannerTest.Models
{
    public class RecipeU
    {
        [Required(ErrorMessage = "Please supply a recipe name")]
        [Display(Name = "Recipe Name: ")]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Submitted By: ")]
        public string Author { get; set; }
        public string Instructions { get; set; }

        [Display(Name = "Vegan? ")]
        public bool Vegan { get; set; }

        [Display(Name = "Vegetarian? ")]
        public bool Vegetarian { get; set; }

        [Display(Name = "Gluten-Free? ")]
        public bool GlutenFree { get; set; }

        //[Required(ErrorMessage = "Please supply a cook time")]
        [Display(Name = "Cook Time", Prompt = "")]
        public int CookTimeMin { get; set; }

        //[Required]
        [Display(Name = "Prep Time", Prompt = "")]
        public int PrepTimeMin { get; set; }
        public int Servings { get; set; }
        public string Difficulty { get; set; }
        public string Category { get; set; }

        public RecipeU()
        {
            Author = "";
            Instructions = "";
            Servings = 0;
            CookTimeMin = 30;
            PrepTimeMin = 45;
            Servings = 4;
            Difficulty = "";
            Category = "";
    }

}
}
