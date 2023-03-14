using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {

            RuleFor(x => x.UserMail).NotEmpty().WithMessage("MAil Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanını Boş Geçilemez");
            RuleFor(X => X.UserName).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(X => X.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(X => X.UserName).MaximumLength(20).WithMessage("En fazla 20 karakter girebilirsiniz");
            RuleFor(X => X.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
        }
    }
}
