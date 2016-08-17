using System.Collections.Generic;
using FatFoodie.Application.Recipe;
using FatFoodie.Contracts;
using Microsoft.AspNet.Mvc;

namespace FatFoodie.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            IEnumerable<Recipe> recipes = recipeService.GetAllRecipes();
            return recipes;
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return recipeService.GetRecipesById(id);
        }
    }
}
