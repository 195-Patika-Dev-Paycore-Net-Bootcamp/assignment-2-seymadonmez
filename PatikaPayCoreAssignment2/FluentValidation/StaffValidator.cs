using FluentValidation;
using PatikaPayCoreAssignment2.Entity;

namespace PatikaPayCoreAssignment2.FluentValidation
{
    public class StaffValidator: AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s=>s.Id).NotEmpty().GreaterThan(0);
            //RuleFor(s => s.Id).GreaterThan(0);

            RuleFor(s => s.Name).NotEmpty().MaximumLength(20).MinimumLength(250);

            RuleFor(s => s.LastName).NotEmpty().MaximumLength(20).MinimumLength(250);

            RuleFor(s => s.Email).NotEmpty().EmailAddress();

            RuleFor(s => s.PhoneNumber).NotEmpty().Matches(@"^[\+]?90[\p{L}\p{N}]+$");
        }
    }
}
