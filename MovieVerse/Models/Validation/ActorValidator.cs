using FluentValidation;

namespace MovieVerse.Models.Validation
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(actor => actor.ProfilePictureURL)
                .NotEmpty().WithMessage("Profile picture is required");

            RuleFor(actor => actor.FullName)
                .NotEmpty().WithMessage("Full Name is required")
                .Length(5, 50).WithMessage("Full Name must be between 5-50 chars");

            RuleFor(actor => actor.Bio)
                .NotEmpty().WithMessage("Bio is required");
        }
    }
}