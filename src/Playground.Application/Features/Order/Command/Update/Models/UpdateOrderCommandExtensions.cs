namespace Playground.Application.Features.Order.Command.Update.Models
{
    public static class UpdateOrderCommandExtensions
    {
        public static string ToWarning(this UpdateOrderCommand input)
        {
            var dishesIdsString = string.Join(", ", input.DishesIds);
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.DishesIds)}:[{dishesIdsString}]|{nameof(input.Price)}:{input.Price}";
        }

        public static string ToInformation(this UpdateOrderCommand input)
        {
            var dishesIdsString = string.Join(", ", input.DishesIds);
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.DishesIds)}:[{dishesIdsString}]|{nameof(input.Price)}:{input.Price}";
        }
    }
}
