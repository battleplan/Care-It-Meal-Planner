using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MealPlannerTest.Models;

namespace MealPlannerTest.DAL
{
    public class RecipeSqlDAO : IRecipeSqlDAO
    {

        private readonly string connectionString;

        public RecipeSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Recipe> GetRecipes()
        {
            List<Recipe> output = new List<Recipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new Recipe()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Author = Convert.ToString(reader["author"]),
                            Instructions = Convert.ToString(reader["intructions"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            GlutenFree = Convert.ToBoolean(reader["gluten_free"]),
                            CookTimeMin = Convert.ToInt32(reader["cook_time_in_mins"]),
                            PrepTimeMin = Convert.ToInt32(reader["prep_time_in_mins"]),
                            Servings = Convert.ToInt32(reader["serves"]),
                            Difficulty = Convert.ToString(reader["difficulity"]),
                            Category = Convert.ToString(reader["category"])
                        });
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return output;
        }

        public Recipe GetSingleRecipe(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Recipe()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Author = Convert.ToString(reader["author"]),
                            Instructions = Convert.ToString(reader["intructions"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            GlutenFree = Convert.ToBoolean(reader["gluten_free"]),
                            CookTimeMin = Convert.ToInt32(reader["cook_time_in_mins"]),
                            PrepTimeMin = Convert.ToInt32(reader["prep_time_in_mins"]),
                            Servings = Convert.ToInt32(reader["serves"]),
                            Difficulty = Convert.ToString(reader["difficulity"]),
                            Category = Convert.ToString(reader["category"])
                        };
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return null;
        }

        public void SaveRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO recipe(name,  intructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulity, category) VALUES (@name, @instructions, @vegan, @vegetarian, @glutenfree, @cooktime, @preptime, @serves, @difficulty, @category);", conn);
                    cmd.Parameters.AddWithValue("@name", recipe.Name);
                    cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                    cmd.Parameters.AddWithValue("@vegan", recipe.Vegan);
                    cmd.Parameters.AddWithValue("@vegetarian", recipe.Vegetarian);
                    cmd.Parameters.AddWithValue("@glutenfree", recipe.GlutenFree);
                    cmd.Parameters.AddWithValue("@cooktime", recipe.CookTimeMin);
                    cmd.Parameters.AddWithValue("@preptime", recipe.PrepTimeMin);
                    cmd.Parameters.AddWithValue("@serves", recipe.Servings);
                    cmd.Parameters.AddWithValue("@difficulty", recipe.Difficulty);
                    cmd.Parameters.AddWithValue("@category", recipe.Category);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
