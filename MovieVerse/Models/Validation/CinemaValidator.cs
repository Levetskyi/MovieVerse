    using FluentValidation;

namespace MovieVerse.Models.Validation
{
    public class CinemaValidator : AbstractValidator<Cinema>
    {
        public CinemaValidator()
        {
            RuleFor(cinema => cinema.Logo)
                .NotEmpty().WithMessage("Profile picture is required");

            RuleFor(cinema => cinema.Name)
                .NotEmpty().WithMessage("Full Name is required")
                .Length(3, 50).WithMessage("Full Name must be between 5-50 chars");

            RuleFor(cinema => cinema.Description)
                .NotEmpty().WithMessage("Bio is required");
        }
    }
}