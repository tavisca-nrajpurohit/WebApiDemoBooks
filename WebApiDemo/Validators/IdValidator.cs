using FluentValidation;

namespace WebApiDemo.Validators
{
    public class IdValidator : AbstractValidator<int>
    {

        public IdValidator()
        {
            BookIdValidation();
        }

        public void BookIdValidation()
        {
            RuleFor(b => b)
                .NotEmpty()
                .WithMessage("Error: Book Id Should Not Be Empty")
                .GreaterThan(0)
                .WithMessage("Error: Book Id Should Not Be Negative");
        }
    }
}
