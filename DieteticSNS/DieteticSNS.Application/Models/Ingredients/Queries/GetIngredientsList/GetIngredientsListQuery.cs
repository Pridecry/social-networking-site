using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class GetIngredientsListQuery : IRequest<CustomersListViewModel>
    {
        public class Handler : IRequestHandler<GetIngredientsListQuery, PlaceOffersModel>
        {
            public Handler()
            {

            }

            public Task<PlaceOffersModel> Handle(GetIngredientsListQuery request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
