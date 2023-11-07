namespace Playground.Application.Features.Order.Command.Create.Models
{
    public static class CreateOrderCommandExtensions
    {
        public static string ToWarning(this CreateOrderCommand input)
        {
            return $@"{nameof(input.OrderName)}:{input.OrderName}|{nameof(input.Price)}:{input.Price}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this CreateOrderCommand input)
        {
            return $@"{nameof(input.OrderName)}:{input.OrderName}|{nameof(input.Price)}:{input.Price}";
        }
    }
}
