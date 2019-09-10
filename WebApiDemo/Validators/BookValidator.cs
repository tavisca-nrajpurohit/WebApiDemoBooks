using FluentValidation;
using WebApiDemo.Data;

namespace WebApiDemo.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {

        public BookValidator()
        {
            Initialize();
        }

        private void Initialize()
        {
            BookNameValidation();
            BookAuthorValidation();
            BookCategoryValidation();
            BookPriceValidation();
            BookIdValidation();
        }

        public void BookNameValidation()
        {
            RuleFor(b => b.title)
                .NotEmpty()
                .WithMessage("Error: Book Title Should Not Be Empty");


        }

        public void BookAuthorValidation()
        {
            RuleFor(b => b.author)
                .NotEmpty()
                .WithMessage("Error: Book Author Should Not Be Empty")
                .Matches("[A-Za-z]")
                .WithMessage("Error: Book Author Name Should Only Contain Letters");

        }

        public void BookCategoryValidation()
        {
            RuleFor(b => b.category)
                .NotEmpty()
                .WithMessage("Error: Book Category Should Not Be Empty")
                .Matches("[A-Za-z]")
                .WithMessage("Error: Book Category Should Only Contain Letters");

        }

        public void BookPriceValidation()
        {
            RuleFor(b => b.price)
                .NotEmpty()
                .WithMessage("Error: Book Price Should Not Be Empty")
                .GreaterThan(0)
                .WithMessage("Error: Book Price Should Not Be Negative");

        }

        public void BookIdValidation()
        {
            RuleFor(b => b.id)
                .NotEmpty()
                .WithMessage("Error: Book Id Should Not Be Empty")
                .GreaterThan(0)
                .WithMessage("Error: Book Id Should Not Be Negative");

        }
    }
}
