using Core.Persistence.Repositories;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;
using KodlamaIO.Persistence.Context;

namespace KodlamaIO.Persistence.Repositories;

public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage,BaseDbContext>,IProgrammingLanguageRepository
{
    public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}