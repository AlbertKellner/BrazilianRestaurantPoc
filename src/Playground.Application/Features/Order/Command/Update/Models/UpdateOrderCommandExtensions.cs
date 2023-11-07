namespace Playground.Application.Features.Order.Command.Update.Models
{
    public static class UpdateOrderCommandExtensions
    {
        public static string ToWarning(this UpdateOrderCommand input)
        {
            return $@"{nameof(input.OrderName)}:{input.OrderName}|{nameof(input.Price)}:{input.Price}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this UpdateOrderCommand input)
        {
            return $@"{nameof(input.OrderName)}:{input.OrderName}|{nameof(input.Price)}:{input.Price}";
        }
    }
}
