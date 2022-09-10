using FluentValidation;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
        RuleFor(p => p.Name).MinimumLength(1).WithMessage("Min. 1 Karakter Giriniz");
    }
}