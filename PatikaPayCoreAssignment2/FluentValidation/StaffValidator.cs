using FluentValidation;
using PatikaPayCoreAssignment2.Entity;

namespace PatikaPayCoreAssignment2.FluentValidation
{
    public class StaffValidator: AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s=>s.Id).NotEmpty().GreaterThan(0);
            RuleFor(s => s.Id).GreaterThan(0);

            RuleFor(s => s.Name).NotEmpty().MaximumLength(5).MinimumLength(250);

            RuleFor(s => s.LastName).NotEmpty().MaximumLength(20).MinimumLength(250);

            RuleFor(s => s.Email).NotEmpty().EmailAddress().Matches(@"^[a-zA-Z\.@]{2,100}$");

            //RuleFor(s => s.DateOfBirth).NotEmpty().InclusiveBetween(new(1945, 11, 11), new(2002, 10, 10));

            //RuleFor(s => s.PhoneNumber).NotEmpty().Matches(@"^[\+]?90[\p{L}\p{N}]+$");
        }
    }
}
