using MediatR;
using Microsoft.AspNetCore.Mvc;
using Playground.Application.Features.Dish.Command.Create.Models;
using Playground.Application.Features.Dish.Command.Delete.Models;
using Playground.Application.Features.Dish.Command.Update.Models;
using Playground.Application.Features.Dish.Query.GetAll.Models;
using Playground.Application.Features.Dish.Query.GetById.Models;
using System.Net;

namespace Playground.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("digital-menu")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class DigitalMenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DigitalMenuController> _logger;

        public DigitalMenuController(
            IMediator mediator,
            ILogger<DigitalMenuController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDishOutput), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateDishCommand input,
            CancellationToken cancellationToken)
        {
            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][DigitalMenuController][CreateAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            _logger.LogInformation($"[Api][DigitalMenuController][CreateAsync][Created] input:({input.ToInformation()})");

            return CreatedAtRoute(
                routeName: "GetById",
                routeValues: new { id = output.Id },
                default);
        }

        [HttpGet("{id:Guid}", Name = "GetById")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetByIdDishOutput), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            [FromQuery] GetByIdDishQuery input,
            CancellationToken cancellationToken)
        {
            input.SetId(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][DigitalMenuController][GetByIdAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogWarning($"[Api][DigitalMenuController][GetByIdAsync][Ok] input:({input.ToInformation()})");

                return Ok(output);
            }

            _logger.LogWarning($"[Api][DigitalMenuController][GetByIdAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(GetAllDishOutput), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(
            CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetAllDishQuery(), cancellationToken);

            if (output.Any())
            {
                return Ok(output);
            }

            return NoContent();
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateDishCommand input,
            CancellationToken cancellationToken)
        {
            input.SetId(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][DigitalMenuController][UpdateAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][DigitalMenuController][UpdateAsync][Ok] input:({input.ToInformation()})");

                return Ok();
            }

            _logger.LogInformation($"[Api][DigitalMenuController][UpdateAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var input = new DeleteDishCommand(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][DigitalMenuController][DeleteAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][DigitalMenuController][DeleteAsync][Ok] input:({input.ToInformation()})");

                return Ok();
            }

            _logger.LogInformation($"[Api][DigitalMenuController][DeleteAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }
    }
}
