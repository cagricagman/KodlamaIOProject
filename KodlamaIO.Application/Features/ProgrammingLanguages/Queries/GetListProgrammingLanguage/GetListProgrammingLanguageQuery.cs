using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIO.Application.Features.ProgrammingLanguages.Models;
using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Domain.Entities;
using MediatR;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }

    public class
        GetListProgrammingLanguageHandler : IRequestHandler<GetListProgrammingLanguageQuery,
            ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ProgrammingLanguageListModel _mappedLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmLanguages);

            return _mappedLanguageListModel;
        }
    }
}