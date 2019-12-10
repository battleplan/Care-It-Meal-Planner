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
            throw new NotImplementedException();
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
            IList<Recipe> recipes = new Recipe();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        recipe.Add(RowToRecipe(reader));
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
    }
}
