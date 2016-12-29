using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FatFoodie.Application.Recipe;
using FatFoodie.Contracts;

namespace FatFoodie.Api.Controllers
{
   // [Route("api/[controller]")]
    public class RecipesController : ApiController
    {
        private readonly IRecipeService recipeService;

        private readonly IMapper mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            this.recipeService = recipeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
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
                    BadRequest(e.ToString());
                        /*new ErrorModel()
                        {
                            ErrorCode = "GetAllRecipesError",
                            ErrorMessage = e.Message,
                            UserErrorMessage = "Oops, something went wrong!"
                        });#1#
                throw e;*/
            }
        }

        // GET api/recipe/{id}
        [HttpGet]
        public Recipe Get(int id)
        {
            var recipe = recipeService.GetRecipesById(id);
            return mapper.Map<Recipe>(recipe);
        }
    }
}
