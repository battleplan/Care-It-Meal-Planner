using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {
        private  IRecipeDAO dao;

        public MealPlanController(IRecipeDAO dao)
        {
            this.dao = dao;
        }

        [HttpGet]
        public ActionResult<IList<Recipe>> GetAll()
        {
            IList<Recipe> reviews = dao.GetAllRecipes();

            // Return 200 OK
            return Ok(reviews);
        }
    }
}