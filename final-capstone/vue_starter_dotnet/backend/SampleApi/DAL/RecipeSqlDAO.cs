﻿using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class RecipeSqlDAO : IRecipeDAO
    {
        private string connectionString;

        public RecipeSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        //DAO Methods

        public bool CreateRecipe(Recipe newRecipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO recipe(name, instructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulty, category)" +
                        " VALUES (@Name, @IN, @Vegan, @VG, @GF, @CT, @PT, @Serves, @Difficulty, @Category)", conn);
                    cmd.Parameters.AddWithValue("@Name", newRecipe.Name);
                    cmd.Parameters.AddWithValue("@IN", newRecipe.Instructions);
                    cmd.Parameters.AddWithValue("@Vegan", newRecipe.Vegan);
                    cmd.Parameters.AddWithValue("@VG", newRecipe.Vegetarian);
                    cmd.Parameters.AddWithValue("@GF", newRecipe.GlutenFree);
                    cmd.Parameters.AddWithValue("@CT", newRecipe.CookTime);
                    cmd.Parameters.AddWithValue("@PT", newRecipe.PrepTime);
                    cmd.Parameters.AddWithValue("@Serves", newRecipe.Servings);
                    cmd.Parameters.AddWithValue("@Difficulty", newRecipe.Difficulty);
                    cmd.Parameters.AddWithValue("@Category", newRecipe.Category);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool EditRecipe(Recipe oldRecipe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets All Recipes From Database including recipes the user hasnt added
        /// </summary>
        /// <returns></returns>
        public IList<Recipe> GetAllRecipes()
        {
            IList<Recipe> recipes = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM recipe", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipe recipe = RowToRecipe(reader);

                        SqlCommand getIng = new SqlCommand(@"
                            SELECT ingredient.id as id, ingredient.name as ingname, ingredient_recipe.quantity as quan, ingredient_recipe.unit_of_measurement as unit FROM recipe
                            JOIN ingredient_recipe ON recipe.id = ingredient_recipe.recipe_id
                            JOIN Ingredient ON Ingredient.id = ingredient_recipe.ingredient_id
                            WHERE recipe.id = @Recipe", conn);
                        cmd.Parameters.AddWithValue("@Recipe", recipe.Id);

                        SqlDataReader ingReader = getIng.ExecuteReader();

                        while (ingReader.Read())
                        {
                            recipe.Ingredients.Add(RowToIngredient(ingReader));
                        }

                        recipes.Add(recipe);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetUserRecipeByCategory(string category, string username)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetUserRecipeByGlutenFree(bool isGlutenFree, string username)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetUserRecipeByVegan(bool isVegan, string username)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetUserRecipeByVegetarian(bool isVegetarian, string username)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetUserRecipes(string username, bool isFavorite)
        {
            throw new NotImplementedException();
        }

        private Recipe RowToRecipe(SqlDataReader reader)
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
                CookTime = Convert.ToInt32(reader["cook_time_in_mins"]),
                PrepTime = Convert.ToInt32(reader["prep_time_in_mins"]),
                Servings = Convert.ToInt32(reader["serves"]),
                Difficulty = Convert.ToString(reader["difficulty"]),
                Category = Convert.ToString(reader["category"]),
            };

        }

        private Ingredient RowToIngredient(SqlDataReader ingReader)
        {
            return new Ingredient()
            {
                Id = Convert.ToInt32(ingReader["id"]),
                Name = Convert.ToString(ingReader["ingname"]),
                Quantity = Convert.ToDouble(ingReader["quan"]),
                UnitOfMeasurement = ingReader["unit"] == null ? "" : Convert.ToString(ingReader["unit"])
            };
        }

    }
}