namespace Playground.Application.Features.Dish.Command.Delete.Models
{
    public static class DeleteDishCommandExtensions
    {
        public static string ToWarning(this DeleteDishCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this DeleteDishCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
