using MediatR;
using Microsoft.AspNetCore.Mvc;
using Playground.Application.Features.Order.Command.Create.Models;
using Playground.Application.Features.Order.Command.Delete.Models;
using Playground.Application.Features.Order.Command.Update.Models;
using Playground.Application.Features.Order.Query.GetAll.Models;
using Playground.Application.Features.Order.Query.GetById.Models;
using System.Net;

namespace Playground.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("Order")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(
            IMediator mediator,
            ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOrderOutput), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateOrderCommand input,
            CancellationToken cancellationToken)
        {
            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][OrderController][CreateAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            _logger.LogInformation($"[Api][OrderController][CreateAsync][Created] input:({input.ToInformation()})");

            return CreatedAtRoute(
                routeName: "OrderGetById",
                routeValues: new { id = output.Id },
                output.Id);
        }

        [HttpGet("{id:Guid}", Name = "OrderGetById")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetByIdOrderOutput), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            [FromQuery] GetByIdOrderQuery input,
            CancellationToken cancellationToken)
        {
            input.SetId(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][OrderController][GetByIdAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][OrderController][GetByIdAsync][Ok] input:({input.ToInformation()})");

                return Ok(output);
            }

            _logger.LogInformation($"[Api][OrderController][GetByIdAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(GetAllOrderOutput), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(
            CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetAllOrderQuery(), cancellationToken);

            if (output.Any())
            {
                _logger.LogInformation($"[Api][OrderController][GetAllAsync][Ok]");

                return Ok(output);
            }

            _logger.LogInformation($"[Api][OrderController][GetAllAsync][NoContent]");

            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateOrderCommand input,
            CancellationToken cancellationToken)
        {
            input.SetId(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][OrderController][UpdateAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][OrderController][UpdateAsync][Ok] input:({input.ToInformation()})");

                return Ok();
            }

            _logger.LogInformation($"[Api][OrderController][UpdateAsync][NoContent] input:({input.ToInformation()})");

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
            var input = new DeleteOrderCommand(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][OrderController][DeleteAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][OrderController][DeleteAsync][Ok] input:({input.ToInformation()})");

                return Ok();
            }

            _logger.LogInformation($"[Api][OrderController][DeleteAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }
    }
}
