using System.Collections.Generic;
using FatFoodie.Contracts;
using Microsoft.AspNet.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace FatFoodie.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        // GET: api/healthcheck
        [HttpGet]
        [SwaggerOperation("HealthCheck")]
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
