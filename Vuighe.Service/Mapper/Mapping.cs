using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Vuighe.Model.Entities;

namespace Vuighe.Service.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<IFormFile, Asset>()
                .ForMember(d => d.FileExtension, s => s.MapFrom(x => x.ContentType))
                .ForMember(d => d.FileSize, s => s.MapFrom(x => x.Length));
        }
    }
}