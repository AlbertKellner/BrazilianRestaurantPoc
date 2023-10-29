namespace Playground.Application.Features.DigitalMenuItem.Command.Create.Models
{
    public static class CreateDigitalMenuItemCommandExtensions
    {
        public static string ToWarning(this CreateDigitalMenuItemCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this CreateDigitalMenuItemCommand input)
        {
            return $@"{nameof(input.DishName)}:{input.DishName}|{nameof(input.Price)}:{input.Price}|{nameof(input.IsAvailable)}:{input.IsAvailable}";
        }
    }
}
