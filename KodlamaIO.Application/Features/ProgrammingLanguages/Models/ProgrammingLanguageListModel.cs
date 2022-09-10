using Core.Persistence.Paging;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Models;

public class ProgrammingLanguageListModel : BasePageableModel
{
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}