namespace Playground.Application.Features.Dish.Command.Update.Models
{
    public static class UpdateDishCommandExtensions
    {
        public static string ToWarning(this UpdateDishCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this UpdateDishCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}";
        }
    }
}
