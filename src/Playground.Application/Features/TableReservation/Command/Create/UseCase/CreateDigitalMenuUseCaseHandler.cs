using MediatR;
using Playground.Application.Features.TableReservation.Command.Create.Interface;
using Playground.Application.Features.TableReservation.Command.Create.Models;

namespace Playground.Application.Features.TableReservation.Command.Create.UseCase
{
    public class CreateTableReservationUseCaseHandler : IRequestHandler<CreateTableReservationCommand, CreateTableReservationOutput>
    {
        private readonly ICreateTableReservationRepository _createTableReservationRepository;

        public CreateTableReservationUseCaseHandler(ICreateTableReservationRepository createTableReservationRepository)
        {
            _createTableReservationRepository = createTableReservationRepository;
        }

        public async Task<CreateTableReservationOutput> Handle(CreateTableReservationCommand input, CancellationToken cancellationToken)
        {
            var result = await _createTableReservationRepository.CreateTableReservationAsync(input, cancellationToken);

            return result;
        }
    }
}
