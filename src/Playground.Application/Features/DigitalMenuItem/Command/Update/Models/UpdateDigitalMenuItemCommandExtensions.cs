namespace Playground.Application.Features.DigitalMenuItem.Command.Update.Models
{
    public static class UpdateDigitalMenuItemCommandExtensions
    {
        public static string ToWarning(this UpdateDigitalMenuItemCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this UpdateDigitalMenuItemCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}";
        }
    }
}
