using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator :AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorFirstName).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.AuthorLastName).NotEmpty().WithMessage("Last name cannot be empty");
            RuleFor(x => x.AuhtorAbout).NotEmpty().WithMessage("About field cannot be empty");
            RuleFor(x => x.AuhtorAbout).Must(x => x.ToLower().Contains("a")).When(x => x.AuhtorAbout != null).WithMessage("About must contain at least one 'a' character");
            RuleFor(x => x.AuthorFirstName).MinimumLength(3).WithMessage("Name has at least 3 characters");
            RuleFor(x => x.AuthorLastName).MinimumLength(3).WithMessage("Last Name has at least 3 characters");
            RuleFor(x => x.AuthorLastName).MaximumLength(20).WithMessage("Last Name has at most 20 characters");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Author Title cannot be empty");
        }
    }
}
