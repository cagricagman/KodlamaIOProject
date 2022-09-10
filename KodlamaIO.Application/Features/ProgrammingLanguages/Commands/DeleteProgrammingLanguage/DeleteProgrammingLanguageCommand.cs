using AutoMapper;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaIO.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;
using MediatR;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
{
    public int Id { get; set; }

    public class
        DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand,
            DeletedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _businessRules;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = await _businessRules.ProgrammingLanguageIdShouldExistWhenRequest(request.Id);
            
            ProgrammingLanguage deletedLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedLanguage);
            return deletedProgrammingLanguageDto;
        }
    }
}