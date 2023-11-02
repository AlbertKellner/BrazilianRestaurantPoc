namespace Playground.Application.Features.TableReservation.Command.Create.Models
{
    public static class CreateTableReservationCommandExtensions
    {
        public static string ToWarning(this CreateTableReservationCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this CreateTableReservationCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}";
        }
    }
}
