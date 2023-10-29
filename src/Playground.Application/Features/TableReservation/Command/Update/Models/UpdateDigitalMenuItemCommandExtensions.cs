namespace Playground.Application.Features.TableReservation.Command.Update.Models
{
    public static class UpdateTableReservationCommandExtensions
    {
        public static string ToWarning(this UpdateTableReservationCommand input)
        {
            return $@"{nameof(input.ReservationId)}:{input.ReservationId}|{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.CustomerContact)}:{input.CustomerContact}|{nameof(input.TableNumber)}:{input.TableNumber}|{nameof(input.ReservationTime)}:{input.ReservationTime}|{nameof(input.NumberOfGuests)}:{input.NumberOfGuests}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this UpdateTableReservationCommand input)
        {
            return $@"{nameof(input.ReservationId)}:{input.ReservationId}|{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.CustomerContact)}:{input.CustomerContact}|{nameof(input.TableNumber)}:{input.TableNumber}|{nameof(input.ReservationTime)}:{input.ReservationTime}|{nameof(input.NumberOfGuests)}:{input.NumberOfGuests}";
        }
    }
}
