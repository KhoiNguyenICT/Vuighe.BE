using AutoMapper;
using Microsoft.AspNetCore.Http;
using Vuighe.Model.Entities;

namespace Vuighe.Service.Mapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<IFormFile, Asset>()
                .ForMember(d => d.FileExtension, s => s.MapFrom(x => x.ContentType))
                .ForMember(d => d.FileSize, s => s.MapFrom(x => x.Length));
        }
    }
}