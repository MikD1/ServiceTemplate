namespace ServiceTemplate.WebApi;

using AutoMapper;
using ServiceTemplate.Dto;
using ServiceTemplate.Model;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<ExampleModel, ExampleModelDto>();
        CreateMap<ExampleModelCreateDto, ExampleModel>()
            .ForMember(x => x.Id, options => options.Ignore())
            .ConstructUsing(x => new ExampleModel(x.Property1, x.Property2));
    }
}