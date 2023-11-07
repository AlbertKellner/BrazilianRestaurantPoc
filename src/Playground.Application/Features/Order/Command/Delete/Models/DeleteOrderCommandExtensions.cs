namespace Playground.Application.Features.Order.Command.Delete.Models
{
    public static class DeleteOrderCommandExtensions
    {
        public static string ToWarning(this DeleteOrderCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this DeleteOrderCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
