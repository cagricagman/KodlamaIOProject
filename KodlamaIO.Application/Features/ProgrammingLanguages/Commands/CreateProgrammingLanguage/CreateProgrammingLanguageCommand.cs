using AutoMapper;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaIO.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;
using MediatR;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }

    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingNameCanNotBeDuplicatedWhenInserted(request.Name); // business tarafında gerekli kontroller yapılarak create işlemi gerçekleştirme aşamasına geçer
            
            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);//Gelen request i brand clasına map işlemi gerçekleştirdi
            ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage); // ekleme işlemi yapıldı.
            CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage); // veritabanına eklenen kaydın tüm bilgilerinden ilgili alanlarının geri dönüşünü sağlayarak dto doldurmasına imkan sağlar
            
            return createdProgrammingLanguageDto;
        }
    }
}