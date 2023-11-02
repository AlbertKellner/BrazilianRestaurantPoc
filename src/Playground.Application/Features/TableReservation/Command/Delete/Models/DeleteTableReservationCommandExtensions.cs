namespace Playground.Application.Features.TableReservation.Command.Delete.Models
{
    public static class DeleteTableReservationCommandExtensions
    {
        public static string ToWarning(this DeleteTableReservationCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this DeleteTableReservationCommand input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
