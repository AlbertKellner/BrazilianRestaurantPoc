namespace Playground.Application.Features.TableReservation.Command.Update.Models
{
    public static class UpdateTableReservationCommandExtensions
    {
        public static string ToWarning(this UpdateTableReservationCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this UpdateTableReservationCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}";
        }
    }
}
