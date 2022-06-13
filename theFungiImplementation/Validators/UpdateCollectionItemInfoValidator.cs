using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;

namespace theFungiImplementation.Validators
{
    public class UpdateCollectionItemInfoValidator : AbstractValidator<CollectionItemInfoCreateDto>
    {
        public UpdateCollectionItemInfoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Info Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Info Content is required");
        }
    }

}
