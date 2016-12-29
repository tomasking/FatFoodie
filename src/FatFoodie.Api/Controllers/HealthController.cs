using System.Collections.Generic;
using System.Web.Http;
using FatFoodie.Contracts;
using Swashbuckle.Swagger.Annotations;

namespace FatFoodie.Api.Controllers
{
   // [Route("api/[controller]")]
    public class HealthController : ApiController
    {
        // GET: api/healthcheck
        [HttpGet]
     //   [SwaggerOperation("HealthCheck")]
        public IEnumerable<HealthCheck> Get()
        {
            return new[]
            {
                new HealthCheck() {Name = "FatFoodie.Api", State = "WORKING", Error = null},
                new HealthCheck() {Name = "FatFoodie.Database", State = "UNKNOWN", Error = null},
            };
        }
    }
}
