using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task ProgrammingNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<ProgrammingLanguage> results = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
        if (results.Items.Any()) throw new BusinessException("Programming Language Name Exist.");
    }

    public void ProgrammingLanguageShouldExistWhenRequest(ProgrammingLanguage? programmingLanguage)
    {
        if (programmingLanguage == null) throw new BusinessException("Request programming language does not exist");
    }

    public async Task<ProgrammingLanguage> ProgrammingLanguageIdShouldExistWhenRequest(int? programmingLanguageId)
    {
        if (programmingLanguageId == null) throw new BusinessException("Request programming language id does not exist");
        if (programmingLanguageId == 0) throw new BusinessException("Request Id cannot be zero.");
        ProgrammingLanguage? result = await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);
        if(result == null) throw new BusinessException("No record was found for the Id information.");
        return result; 
    }
}