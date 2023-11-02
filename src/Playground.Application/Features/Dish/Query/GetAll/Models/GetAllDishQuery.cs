using MediatR;

namespace Playground.Application.Features.Dish.Query.GetAll.Models
{
    public class GetAllDishQuery : IRequest<IEnumerable<GetAllDishOutput>>
    {
        public IEnumerable<string> ErrosList()
        {
            return new List<string>();
        }

        public bool IsInvalid() => ErrosList().Any();

        public string FormattedErrosList() => $"({string.Join("|", ErrosList())})";
    }
}
