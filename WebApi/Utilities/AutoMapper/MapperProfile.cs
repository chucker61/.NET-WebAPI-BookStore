using AutoMapper;
using Entities.DataTransferObjects;
using Entity.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookDtoForUpdate,Book>();
        }
    }
}
