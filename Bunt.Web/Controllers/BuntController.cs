using System.Collections.Generic;
using System.Threading.Tasks;
using Bunt.Core.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bunt.Web.Controllers
{
    [Route("api/bunt")]
    public class BuntController : Controller
    {
        private readonly IMediator _mediator;

        public BuntController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ListaBuntladeStallen.BuntladeStalle>> List()
        {
            return await _mediator.Send(new ListaBuntladeStallen.Query());
        }
    }
}