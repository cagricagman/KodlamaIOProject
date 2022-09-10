using FluentValidation;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
{
    public DeleteProgrammingLanguageCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Bilgisi Boş Geçilemez");
    }
}