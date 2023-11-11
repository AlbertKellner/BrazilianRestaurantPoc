namespace Playground.Application.Features.TableReservation.Command.Create.Models
{
    public static class CreateTableReservationCommandExtensions
    {
        public static string ToWarning(this CreateTableReservationCommand input)
        {
            return $@"{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.CustomerContact)}:{input.CustomerContact}|{nameof(input.TableId)}:{input.TableId}|{nameof(input.ReservationDateTime)}:{input.ReservationDateTime}|{nameof(input.ErrosList)}:{string.Join(", ", input.ErrosList())}";
        }

        public static string ToInformation(this CreateTableReservationCommand input)
        {
            return $@"{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.CustomerContact)}:{input.CustomerContact}|{nameof(input.TableId)}:{input.TableId}|{nameof(input.ReservationDateTime)}:{input.ReservationDateTime}";
        }
    }
}
