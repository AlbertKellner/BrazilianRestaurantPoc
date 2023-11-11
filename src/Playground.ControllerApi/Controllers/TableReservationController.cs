using MediatR;
using Microsoft.AspNetCore.Mvc;
using Playground.Application.Features.TableReservation.Command.Create.Models;
using Playground.Application.Features.TableReservation.Command.Delete.Models;
using Playground.Application.Features.TableReservation.Command.Update.Models;
using Playground.Application.Features.TableReservation.Query.GetAll.Models;
using Playground.Application.Features.TableReservation.Query.GetById.Models;
using System.Net;

namespace Playground.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("table-reservation")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class TableReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TableReservationController> _logger;

        public TableReservationController(
            IMediator mediator,
            ILogger<TableReservationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTableReservationOutput), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateTableReservationCommand input,
            CancellationToken cancellationToken)
        {
            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][TableReservationController][CreateAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            _logger.LogInformation($"[Api][TableReservationController][CreateAsync][Created] input:({input.ToInformation()})");

            return CreatedAtRoute(
                routeName: "TableReservationGetById",
                routeValues: new { id = output.Id },
                output.Id);
        }

        [HttpGet("{id:Guid}", Name = "TableReservationGetById")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetByIdTableReservationOutput), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            [FromQuery] GetByIdTableReservationQuery input,
            CancellationToken cancellationToken)
        {
            input.SetId(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][TableReservationController][GetByIdAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][TableReservationController][GetByIdAsync][Ok] input:({input.ToInformation()})");

                return Ok(output);
            }

            _logger.LogInformation($"[Api][TableReservationController][GetByIdAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(GetAllTableReservationOutput), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(
            CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetAllTableReservationQuery(), cancellationToken);

            if (output.Any())
            {
                _logger.LogInformation($"[Api][TableReservationController][GetAllAsync][Ok]");

                return Ok(output);
            }

            _logger.LogInformation($"[Api][TableReservationController][GetAllAsync][NoContent]");

            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateTableReservationCommand input,
            CancellationToken cancellationToken)
        {
            input.SetId(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][TableReservationController][UpdateAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][TableReservationController][UpdateAsync][Ok] input:({input.ToInformation()})");

                return Ok();
            }

            _logger.LogInformation($"[Api][TableReservationController][UpdateAsync][NoContent] input:({input.ToInformation()})");

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
            var input = new DeleteTableReservationCommand(id);

            if (input.IsInvalid())
            {
                _logger.LogWarning($"[Api][TableReservationController][DeleteAsync][BadRequest] input:({input.ToWarning()})");

                return BadRequest(input.ErrosList());
            }

            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid())
            {
                _logger.LogInformation($"[Api][TableReservationController][DeleteAsync][Ok] input:({input.ToInformation()})");

                return Ok();
            }

            _logger.LogInformation($"[Api][TableReservationController][DeleteAsync][NoContent] input:({input.ToInformation()})");

            return NoContent();
        }
    }
}
