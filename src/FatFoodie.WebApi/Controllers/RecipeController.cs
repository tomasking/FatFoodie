using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using FatFoodie.Application.Recipe;
using FatFoodie.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FatFoodie.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        private readonly IMapper mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            this.recipeService = recipeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var recipes = await recipeService.GetAllRecipes();
                var recipeDtos = mapper.Map<IEnumerable<Recipe>>(recipes);
                return Ok(recipeDtos);
            }
            catch (Exception e)
            {
                return
                    BadRequest(
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
            var recipe = recipeService.GetRecipesById(id);
            return mapper.Map<Recipe>(recipe);
        }
    }
}
