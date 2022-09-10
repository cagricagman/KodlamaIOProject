using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIO.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaIO.Application.Features.ProgrammingLanguages.Models;
using KodlamaIO.Domain.Entities;

namespace KodlamaIO.Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
    }
}