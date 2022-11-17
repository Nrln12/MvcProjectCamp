using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Mail address can not be empty");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Message Subject can not be empty");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Username can not be empty");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Message Subject must contain at least 3 characters");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Username must contain at least 3 characters");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Subject must contain at most 50 characters");
        }
    }
}
