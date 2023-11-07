namespace Playground.Application.Features.Order.Query.GetById.Models
{
    public static class GetByIdOrderQueryExtensions
    {
        public static string ToWarning(this GetByIdOrderQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this GetByIdOrderQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
