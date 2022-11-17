using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("You cannot create new category without name");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category name has to have at least 3 characters");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Category name has to have at most 20 characters");
        }
       
    }
}
