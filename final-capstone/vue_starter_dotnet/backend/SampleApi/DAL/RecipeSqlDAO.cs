using SampleApi.Models;
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


        /// <summary>
        /// Adds a new Recipe to the database 
        /// </summary>
        /// <param name="newRecipe"></param>
        /// <returns></returns>
        public bool CreateRecipe(Recipe newRecipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand addRec = new SqlCommand("INSERT INTO recipe(name, instructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulty, category)" +
                        " VALUES (@Name, @IN, @Vegan, @VG, @GF, @CT, @PT, @Serves, @Difficulty, @Category); SELECT @@IDENTITY", conn);
                    addRec.Parameters.AddWithValue("@Name", newRecipe.Name);
                    addRec.Parameters.AddWithValue("@IN", newRecipe.Instructions);
                    addRec.Parameters.AddWithValue("@Vegan", newRecipe.Vegan);
                    addRec.Parameters.AddWithValue("@VG", newRecipe.Vegetarian);
                    addRec.Parameters.AddWithValue("@GF", newRecipe.GlutenFree);
                    addRec.Parameters.AddWithValue("@CT", newRecipe.CookTime);
                    addRec.Parameters.AddWithValue("@PT", newRecipe.PrepTime);
                    addRec.Parameters.AddWithValue("@Serves", newRecipe.Servings);
                    addRec.Parameters.AddWithValue("@Difficulty", newRecipe.Difficulty);
                    addRec.Parameters.AddWithValue("@Category", newRecipe.Category);

                    newRecipe.Id = Convert.ToInt32(addRec.ExecuteScalar());

                    foreach (Ingredient ingredient in newRecipe.Ingredients)
                    {
                        SqlCommand addIng = new SqlCommand("INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (@ingId, @recId, @QN, @UM)", conn);
                        addIng.Parameters.AddWithValue("@ingId", ingredient.Id);
                        addIng.Parameters.AddWithValue("@recid", newRecipe.Id);
                        addIng.Parameters.AddWithValue("@QN", ingredient.Quantity);
                        addIng.Parameters.AddWithValue("@UM", ingredient.UnitOfMeasurement);

                        addIng.ExecuteNonQuery();

                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Takes a recipe to delete and removes it from the database
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public bool DeleteRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM ingredient_recipe WHERE recipe_id = @ID" +
                    " DELETE FROM recipe WHERE Recipe.id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", recipe.Id);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edits an existing recipe stored in the database
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public bool EditRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    //Delete old recipe ingredients
                    SqlCommand cmd = new SqlCommand("DELETE FROM ingredient_recipe where recipe_id = @recId", conn);
                    cmd.Parameters.AddWithValue("@recId", recipe.Id);

                    cmd.ExecuteNonQuery();

                    // add new ingredients to the old recipe
                    //NOTE: Ingredient needs to exist in the database to function
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        SqlCommand addIng = new SqlCommand("INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (@ingId, @recId, @QN, @UM)", conn);
                        addIng.Parameters.AddWithValue("@ingId", ingredient.Id);
                        addIng.Parameters.AddWithValue("@recid", recipe.Id);
                        addIng.Parameters.AddWithValue("@QN", ingredient.Quantity);
                        addIng.Parameters.AddWithValue("@UM", ingredient.UnitOfMeasurement);

                        addIng.ExecuteNonQuery();
                    }

                    //updates name and intructions
                    SqlCommand upd = new SqlCommand("UPDATE recipe SET name = @Name, instructions = @instruc WHERE id = @id", conn);
                    upd.Parameters.AddWithValue("@Name", recipe.Name);
                    upd.Parameters.AddWithValue("@instruc", recipe.Instructions);
                    upd.Parameters.AddWithValue("@id", recipe.Id);

                    upd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets All Recipes From Database including recipes the user hasnt added
        /// </summary>
        /// <returns></returns>
        /// 
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
                        recipes.Add(recipe);
                    }
                    reader.Close();

                    foreach (Recipe recipe in recipes)
                    {
                        recipe.Ingredients = new List<Ingredient>();


                        SqlCommand getIng = new SqlCommand(@"
                            SELECT ingredient.id as id, ingredient.name as ingname, ingredient_recipe.quantity as quan, ingredient_recipe.unit_of_measurement as unit FROM recipe
                            JOIN ingredient_recipe ON recipe.id = ingredient_recipe.recipe_id
                            JOIN Ingredient ON Ingredient.id = ingredient_recipe.ingredient_id
                            WHERE recipe.id = @Recipe", conn);
                        getIng.Parameters.AddWithValue("@Recipe", recipe.Id);

                        SqlDataReader ingReader = getIng.ExecuteReader();

                        while (ingReader.Read())
                        {
                            recipe.Ingredients.Add(RowToIngredient(ingReader));
                        }
                        ingReader.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return recipes;
        }

        /// <summary>
        /// Gets a single recipe from the database by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients = new List<Ingredient>();

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
                        recipe = RowToRecipe(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from Ingredient i join ingredient_recipe ir on ir.ingredient_id = i.id where ir.recipe_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        recipe.Ingredients.Add(new Ingredient()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Quantity = Convert.ToInt32(reader["quantity"]),
                            UnitOfMeasurement = Convert.ToString(reader["unit_of_measurement"]),
                        });
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }


            return recipe;
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
                Instructions = Convert.ToString(reader["instructions"]),
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

        private MealPlan RowToMealPlan(SqlDataReader reader)
        {
            return new MealPlan()
            {
                RecipeID = Convert.ToInt32(reader["recipe_id"]),
                Username = Convert.ToString(reader["username"]),
                MealSlot = Convert.ToInt32(reader["meal_slot"]),
                MealDate = Convert.ToDateTime(reader["meal_date"]),
            };

        }

        public bool AddToMealPlan(MealPlan mealPlan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand addRec = new SqlCommand("INSERT INTO Meal_Plan(recipe_id, username, meal_slot, meal_date)" +
                        " VALUES (@recipeId, @username, @mealSlot, @mealDate); SELECT @@IDENTITY", conn);
                    addRec.Parameters.AddWithValue("@recipeId", mealPlan.Recipe.Id);
                    addRec.Parameters.AddWithValue("@username", mealPlan.User.Username);
                    addRec.Parameters.AddWithValue("@mealSlot", mealPlan.MealSlot);
                    addRec.Parameters.AddWithValue("@mealDate", mealPlan.MealDate);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveFromMealPlan(MealPlan mealPlan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Meal_Plan WHERE recipe_id = @recipeId AND username = @username AND meal_slot = @mealSlot", conn);
                    cmd.Parameters.AddWithValue("@recipeId", mealPlan.Recipe.Id);
                    cmd.Parameters.AddWithValue("@username", mealPlan.User.Username);
                    cmd.Parameters.AddWithValue("@mealSlot", mealPlan.MealSlot);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
