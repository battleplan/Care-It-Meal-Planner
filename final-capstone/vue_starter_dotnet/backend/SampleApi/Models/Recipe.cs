using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Model for a single recipe
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Unique Identifier for the Recipe
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Recipe Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The display name of the user who created the recipe
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Step by step instructions for making the recipe
        /// </summary>
        public string Instructions { get; set; }
        /// <summary>
        /// True if the recipe is vegan, false otherwise
        /// </summary>
        public bool Vegan { get; set; }
        /// <summary>
        /// True if the recipe is vegetarian, false otherwise
        /// </summary>
        public bool Vegetarian { get; set; }
        /// <summary>
        /// True if the recipe is gluten free, false otherwise
        /// </summary>
        public bool GlutenFree { get; set; }
        /// <summary>
        /// The recipe's cook time in minutes
        /// </summary>
        public int CookTime { get; set; }
        /// <summary>
        /// The recipe's prep time in minutes
        /// </summary>
        public int PrepTime { get; set; }
        /// <summary>
        /// Total time to make recipe
        /// </summary>
        public int TotalMakeTime { get { return CookTime + PrepTime; } }
        /// <summary>
        /// The number of servings the recipe makes
        /// </summary>
        public int Servings { get; set; }
        /// <summary>
        /// A string denoting the difficulty level of making the recipe
        /// </summary>
        public string Difficulty { get; set; }
        /// <summary>
        /// The category that the recipe falls under ex. "Italian"
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// List of all of the ingredients in the recipe
        /// </summary>
        public string ImageURL { get; set; }
        /// <summary>
        /// Address for the image of the recipe
        /// </summary>

        public List<Ingredient> Ingredients { get; set; }
        /// <summary>
        /// constructor that takes all properties for ease of use
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="instructions"></param>
        /// <param name="vegan"></param>
        /// <param name="vegetarian"></param>
        /// <param name="glutenFree"></param>
        /// <param name="cookTime"></param>
        /// <param name="prepTime"></param>
        /// <param name="servings"></param>
        /// <param name="difficulty"></param>
        /// <param name="category"></param>
        public Recipe(int id, string name, string author, string instructions, bool vegan, bool vegetarian, bool glutenFree, int cookTime, int prepTime, int servings, string difficulty, string category)
        {
            Id = id;
            Name = name;
            Author = author;
            Instructions = instructions;
            Vegan = vegan;
            Vegetarian = vegetarian;
            GlutenFree = glutenFree;
            CookTime = cookTime;
            PrepTime = prepTime;
            Servings = servings;
            Difficulty = difficulty;
            Category = category;
            Ingredients = new List<Ingredient>();
        }
        /// <summary>
        /// Default constructor for ease of use
        /// </summary>
        public Recipe() { Ingredients = new List<Ingredient>(); }
    }
}
