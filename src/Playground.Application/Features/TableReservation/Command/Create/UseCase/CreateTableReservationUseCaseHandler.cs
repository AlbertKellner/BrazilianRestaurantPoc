using BrazilianRestaurant.Application.Shared.ExternalServices.Interfaces;
using MediatR;
using Playground.Application.Features.TableReservation.Command.Create.Interface;
using Playground.Application.Features.TableReservation.Command.Create.Models;

namespace Playground.Application.Features.TableReservation.Command.Create.UseCase
{
    public class CreateTableReservationUseCaseHandler : IRequestHandler<CreateTableReservationCommand, CreateTableReservationOutput>
    {
        private readonly ICreateTableReservationRepository _createTableReservationRepository;
        private readonly INewEmailSender _newEmailSender;

        public CreateTableReservationUseCaseHandler(
            ICreateTableReservationRepository createTableReservationRepository, 
            INewEmailSender newEmailSender)
        {
            _createTableReservationRepository = createTableReservationRepository;
            _newEmailSender = newEmailSender;
        }

        public async Task<CreateTableReservationOutput> Handle(CreateTableReservationCommand input, CancellationToken cancellationToken)
        {
            var result = await _createTableReservationRepository.CreateTableReservationAsync(input, cancellationToken);

            _newEmailSender.NewSendEmail(
                input.CustomerEmail, 
                input.CustomerName, 
                input.CustomerContact, 
                input.ReservationCode, 
                input.TableId.ToString(), 
                input.ReservationDateTime.ToString());

            return result;
        }
    }
}
