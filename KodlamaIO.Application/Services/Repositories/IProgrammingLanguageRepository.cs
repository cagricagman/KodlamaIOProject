using Core.Persistence.Repositories;
using KodlamaIO.Domain.Entities;

namespace KodlamaIO.Application.Services.Repositories;

public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>,IRepository<ProgrammingLanguage>
{
    
}