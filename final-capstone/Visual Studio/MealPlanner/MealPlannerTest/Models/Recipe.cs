using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlannerTest.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Instructions { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }
        public bool GlutenFree { get; set; }
        public int CookTimeMin { get; set; }
        public int PrepTimeMin { get; set; }
        public int Servings { get; set; }
        public string Difficulty { get; set; }
        public string Category { get; set; }

        public Recipe() { }
    }
}
