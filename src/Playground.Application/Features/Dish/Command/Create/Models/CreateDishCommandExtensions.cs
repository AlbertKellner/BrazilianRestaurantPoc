namespace Playground.Application.Features.Dish.Command.Create.Models
{
    public static class CreateDishCommandExtensions
    {
        public static string ToWarning(this CreateDishCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.Quantity)}:{input.Quantity}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this CreateDishCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.Quantity)}:{input.Quantity}";
        }
    }
}
