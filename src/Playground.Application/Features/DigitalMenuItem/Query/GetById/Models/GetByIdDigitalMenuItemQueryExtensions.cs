namespace Playground.Application.Features.DigitalMenuItem.Query.GetById.Models
{
    public static class GetByIdDigitalMenuItemQueryExtensions
    {
        public static string ToWarning(this GetByIdDigitalMenuItemQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this GetByIdDigitalMenuItemQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
