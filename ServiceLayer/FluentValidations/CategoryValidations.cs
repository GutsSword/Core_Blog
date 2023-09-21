using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidations
{
    public class CategoryValidations : AbstractValidator<Category>
    {
        public CategoryValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithName("Kategori Adı");
        }
    }
}
