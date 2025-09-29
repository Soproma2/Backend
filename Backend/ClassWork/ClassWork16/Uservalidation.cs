using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork16
{
    public class Uservalidation : AbstractValidator<User>
    {
        public Uservalidation()
        {
            RuleFor(e=> e.Username)
                .NotEmpty().WithMessage("tu shevseba ar gindoda ras mawuxebdi")
                .MinimumLength(3).WithMessage("gtxov minimum 3 simbolo sheiyvane");
            RuleFor(e=> e.Email)
                .NotEmpty().WithMessage("tu shevseba ar gindoda ras mawuxebdi")
                .EmailAddress().WithMessage("emailis truqturac me unda gaswavlo?");
            RuleFor(e=> e.Password)
                .NotEmpty().WithMessage("tu shevseba ar gindoda ras mawuxebdi")
                .MinimumLength(8).WithMessage("gtxov minimum 8 simbolo sheiyvane");
        }
    }
}
