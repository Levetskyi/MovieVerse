using FluentValidation;

namespace CinemaVerse.Models.Validation
{
    public class ProducerValidator : AbstractValidator<Producer>
    {
        public ProducerValidator()
        {
            RuleFor(producer => producer.ProfilePictureURL)
                .NotEmpty().WithMessage("Profile picture is required");

            RuleFor(producer => producer.FullName)
                .NotEmpty().WithMessage("Full Name is required")
                .Length(5, 50).WithMessage("Full Name must be between 5-50 chars");

            RuleFor(producer => producer.Bio)
                .NotEmpty().WithMessage("Bio is required");
        }
    }
}