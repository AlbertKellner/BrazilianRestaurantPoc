using MediatR;

namespace Playground.Application.Features.Order.Query.GetAll.Models
{
    public class GetAllOrderQuery : IRequest<IEnumerable<GetAllOrderOutput>>
    {
        public IEnumerable<string> ErrosList()
        {
            return new List<string>();
        }

        public bool IsInvalid() => ErrosList().Any();

        public string FormattedErrosList() => $"({string.Join("|", ErrosList())})";
    }
}
