namespace Playground.Application.Features.Dish.Query.GetById.Models
{
    public static class GetByIdDishQueryExtensions
    {
        public static string ToWarning(this GetByIdDishQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this GetByIdDishQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
