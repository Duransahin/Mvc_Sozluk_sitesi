using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazaradı Adı Boş Geçilemez");
            RuleFor(X => X.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı  Boş Geçilemez");
            RuleFor(X => X.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı  Boş Geçilemez");
            RuleFor(X => X.WriterTitle).NotEmpty().WithMessage("Hakkımda kısmı  Boş Geçilemez");
            RuleFor(X => X.WriterName).MinimumLength(2).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(X => X.WriterSurName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");

        }
    }
}
