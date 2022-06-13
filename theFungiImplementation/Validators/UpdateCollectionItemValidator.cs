using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;

namespace theFungiImplementation.Validators
{
    public class UpdateCollectionItemValidator : AbstractValidator<CollectionItemCreateDto>
    {
        public UpdateCollectionItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required");
        }
    }
}
