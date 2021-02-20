using canalhice.services.commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace canalhice.api.Controllers
{
    [Route("api/canalhice")]
    [ApiController]
    public class CanalhiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CanalhiceController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet, Route("testandoApi")]
        public string GetTestandoApi()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;

            return "coé rapaziada";
        }

        /// <summary>
        /// recebe um texto e inverte o mesmo
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> RecebendoDisparando(string texto)
        {
            return await _mediator.Send(new PrimeiroServicoCommand(texto));
        }
    }
}
