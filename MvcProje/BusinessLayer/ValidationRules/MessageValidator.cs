using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class MessageValidator:AbstractValidator<Message>
    { 
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adı Boş Geçilemez");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konuyu Boş Geçilemez");
            RuleFor(X => X.MessageContent).NotEmpty().WithMessage("Mesaj metnini boş geçemezsiniz");
            RuleFor(X => X.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(X => X.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapınız.");

        }
    }
}
