using MediatR;

namespace Playground.Application.Features.DigitalMenuItem.Query.GetAll.Models
{
    public class GetAllDigitalMenuItemQuery : IRequest<IEnumerable<GetAllDigitalMenuItemOutput>>
    {
        public IEnumerable<string> ErrosList()
        {
            return new List<string>();
        }

        public bool IsInvalid() => ErrosList().Any();

        public string FormattedErrosList() => $"({string.Join("|", ErrosList())})";
    }
}
