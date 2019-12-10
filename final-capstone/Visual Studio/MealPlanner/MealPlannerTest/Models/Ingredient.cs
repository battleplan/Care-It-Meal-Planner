using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlannerTest.Models
{
    public class Ingredient
    {
        /// <summary>
        /// Unique identifier for the ingredient
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ingredient name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Amount of the ingredient needed for the recipe
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// unit of measurement used for the ingredient in the recipe
        /// </summary>
        public string UnitOfMeasurement { get; set; }
        /// <summary>
        /// Constructor that takes all the properties for ease of use
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="unitOfMeasurement"></param>
        public Ingredient(int id, string name, double quantity, string unitOfMeasurement)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
        }
        /// <summary>
        /// Default constructor for ease of use
        /// </summary>
        public Ingredient() { }
    }
}
