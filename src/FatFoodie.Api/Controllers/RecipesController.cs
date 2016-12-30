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
        public async Task<IHttpActionResult> Get(int id)
        {
            var recipe = await recipeService.GetRecipesById(id);
            return Ok(mapper.Map<Recipe>(recipe));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Recipe recipe)
        {
            var mapperRequest = mapper.Map<Domain.Recipe>(recipe);
            var recipeResponse = await recipeService.AddOrUpdateRecipe(mapperRequest);
            return Ok(mapper.Map<Recipe>(recipeResponse));
        }
    }
}
