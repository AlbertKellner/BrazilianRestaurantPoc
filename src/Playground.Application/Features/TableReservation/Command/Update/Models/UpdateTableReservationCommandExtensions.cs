namespace Playground.Application.Features.TableReservation.Command.Update.Models
{
    public static class UpdateTableReservationCommandExtensions
    {
        public static string ToWarning(this UpdateTableReservationCommand input)
        {
            return $@"{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.TableId)}:{input.TableId}|{nameof(input.ReservationDateTime)}:{input.ReservationDateTime}|{nameof(input.ErrosList)}:{string.Join(", ", input.ErrosList())}";
        }

        public static string ToInformation(this UpdateTableReservationCommand input)
        {
            return $@"{nameof(input.CustomerName)}:{input.CustomerName}|{nameof(input.TableId)}:{input.TableId}|{nameof(input.ReservationDateTime)}:{input.ReservationDateTime}";
        }
    }
}
