using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.RececiverMail).NotEmpty().WithMessage("Receiver email can not be empty");

            RuleFor(x => x.RececiverMail).Must(IsValid).WithMessage("Enter valid email address");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Message subject can not be empty.");
            
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Subject has to contain at least 3 chars");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Subject has to contain at most 100 characters");
        }
        private bool IsValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
