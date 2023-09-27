using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidations
{
    public class UserValidation : AbstractValidator<AppUser>
    {
        public UserValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Soyisim");
            RuleFor(x => x.PhoneNumber)
               .NotEmpty()
               .NotNull()
               .MinimumLength(11)
               .MaximumLength(15)
               .WithName("Telefon Numarası");
        }
    }
}
