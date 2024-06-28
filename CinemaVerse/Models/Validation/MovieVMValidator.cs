using FluentValidation;

namespace CinemaVerse.Models.Validation
{
    public class MovieVMValidator : AbstractValidator<NewMovieVM>
    {
        public MovieVMValidator()
        {
            RuleFor(movie => movie.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(movie => movie.Category)
                .IsInEnum().WithMessage("Category is required");

            RuleFor(movie => movie.LongDescription)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(movie => movie.PosterImageURL)
                .NotEmpty().WithMessage("Image URL is required");

            RuleFor(movie => movie.Year)
                .NotEmpty().WithMessage("Year is required")
                .GreaterThan(0);

            RuleFor(movie => movie.Country)
                .NotEmpty().WithMessage("Country is required");

            RuleFor(movie => movie.Language)
                .NotEmpty().WithMessage("Language is required");

            RuleFor(movie => movie.StartDate)
                .NotEmpty().WithMessage("Start Date is required");

            RuleFor(movie => movie.EndDate)
                .NotEmpty().WithMessage("End Date is required")
                .GreaterThan(DateTime.Now);

            RuleFor(movie => movie.Duration)
                .NotEmpty().WithMessage("Duration is required")
                .GreaterThan(0);

            RuleFor(movie => movie.AgeRating)
                .NotEmpty().WithMessage("Age Rating is required")
                .GreaterThanOrEqualTo(0);

            RuleFor(movie => movie.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0);
        }
    }
}