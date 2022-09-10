﻿using AutoMapper;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaIO.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;
using MediatR;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto>
{
    public int Id { get; set; }

    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

            _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequest(programmingLanguage);

            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto =
                _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);

            return programmingLanguageGetByIdDto;
        }
    }
}