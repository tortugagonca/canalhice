using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace canalhice.api.Controllers
{
    [Route("api/canalhice")]
    [ApiController]
    public class CanalhiceController : ControllerBase
    {
        [HttpGet, Route("testandoApi")]
        public string GetTestandoApi()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;

            return "coé rapaziada";
        }
        [HttpGet]
        public string RecebendoDisparando(string texto)
        {
            return new string(texto.Reverse().ToArray());
        }
    }
}
