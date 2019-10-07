using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientDetails
{
    public class GetIngredientDetailsQueryValidator : AbstractValidator<GetIngredientDetailsQuery>
    {
        public GetIngredientDetailsQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
