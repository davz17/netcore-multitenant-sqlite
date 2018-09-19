using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webmarks.xyz.Infrastructure;
using webmarks.xyz.Models;

namespace webmarks.xyz.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    [ServiceFilter(typeof(TenantAttribute))]
    public class TestController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var host = "landing page";
            if (RouteData.Values["tenant"] != null)
            {
                host = (RouteData.Values["tenant"] as Tenants).Host;
            }
            return Ok("From TestController API - " + host);
        }
    }
}