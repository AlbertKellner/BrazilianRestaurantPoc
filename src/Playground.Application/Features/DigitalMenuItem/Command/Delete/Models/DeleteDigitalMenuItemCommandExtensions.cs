namespace Playground.Application.Features.DigitalMenuItem.Command.Delete.Models
{
    public static class DeleteDigitalMenuItemCommandExtensions
    {
        public static string ToWarning(this DeleteDigitalMenuItemCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this DeleteDigitalMenuItemCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
