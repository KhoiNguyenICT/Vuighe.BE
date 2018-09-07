using AutoMapper;
using Vuighe.Model.Entities;
using Vuighe.Service.Dtos.LoginHistory;

namespace Vuighe.Service.Mapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Asset, Asset>();
        }
    }
}