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
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Skill name cannot be empty");
            RuleFor(x => x.SkillName).MaximumLength(20).WithMessage("Skill Name length cannot be greater than 20 characters");
            RuleFor(x => x.SkillRange.ToString()).Must(IsValid).WithMessage("Skill range must contain only numbers");
            RuleFor(x => x.SkillRange).InclusiveBetween(0, 100).WithMessage("Skill range value must be between 0 and 100 ");
        }

        private bool IsValid(string number)
        {
            try
            {
                Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");
                return regex.IsMatch(number);
            }
            catch
            {
                return false;
            }
        }
    }
}
