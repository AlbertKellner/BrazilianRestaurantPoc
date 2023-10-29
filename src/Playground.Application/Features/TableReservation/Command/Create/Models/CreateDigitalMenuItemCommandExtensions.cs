namespace Playground.Application.Features.TableReservation.Command.Create.Models
{
    public static class CreateTableReservationCommandExtensions
    {
        public static string ToWarning(this CreateTableReservationCommand input)
        {
            return $@"{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.CustomerContact)}:{input.CustomerContact}|{nameof(input.TableNumber)}:{input.TableNumber}|{nameof(input.ReservationTime)}:{input.ReservationTime}|{nameof(input.NumberOfGuests)}:{input.NumberOfGuests}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this CreateTableReservationCommand input)
        {
            return $@"{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.CustomerContact)}:{input.CustomerContact}|{nameof(input.TableNumber)}:{input.TableNumber}|{nameof(input.ReservationTime)}:{input.ReservationTime}|{nameof(input.NumberOfGuests)}:{input.NumberOfGuests}";
        }
    }
}
