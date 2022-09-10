using AutoMapper;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaIO.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;
using MediatR;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class
        UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand,
            UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingNameCanNotBeDuplicatedWhenInserted(request.Name);

            ProgrammingLanguage mapperProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mapperProgrammingLanguage);
            UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
            return updatedProgrammingLanguageDto;
        }
    }
}