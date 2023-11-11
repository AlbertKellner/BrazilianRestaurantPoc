namespace Playground.Application.Features.Order.Command.Create.Models
{
    public static class DataBaseOrderItemExtensions
    {
        public static string ToWarning(this CreateOrderCommand input)
        {
            var dishesIdsString = string.Join(", ", input.DishesIds);
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.DishesIds)}:[{dishesIdsString}]|{nameof(input.Price)}:{input.Price}";
        }

        public static string ToInformation(this CreateOrderCommand input)
        {
            var dishesIdsString = string.Join(", ", input.DishesIds);
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.DishesIds)}:[{dishesIdsString}]|{nameof(input.Price)}:{input.Price}";
        }
    }
}
