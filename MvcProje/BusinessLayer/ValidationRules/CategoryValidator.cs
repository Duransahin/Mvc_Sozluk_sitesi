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
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(X => X.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez"); 
            RuleFor(X => X.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız"); 
            RuleFor(X => X.CategoryName).MaximumLength(30).WithMessage("En fazla 30 karakter girebilirsiniz"); 

        }

    }
}
