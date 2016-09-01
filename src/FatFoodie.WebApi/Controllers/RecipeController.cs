using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FatFoodie.Application.Recipe;
using FatFoodie.Contracts;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Recipe> recipes = await recipeService.GetAllRecipes();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(
                        new ErrorModel()
                        {
                            ErrorCode = "GetAllRecipesError",
                            ErrorMessage = e.Message,
                            UserErrorMessage = "Oops, something went wrong!"
                        });
            }
        }

        // GET api/recipe/{id}
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return recipeService.GetRecipesById(id);
        }
    }
}
