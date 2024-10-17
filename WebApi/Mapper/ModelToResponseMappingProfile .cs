using AutoMapper;
using WebApi.Dto.Drug;
using WebApi.Dto.DrugManufacturer;
using WebApi.Entities;

namespace WebApi.Mapper
{
    /// <summary>
    /// Настройки mapper (определяет в какой тип будет конвертироваться entity)
    /// </summary>
    public class ModelToResponseMappingProfile : Profile
    {
        public ModelToResponseMappingProfile()
        {
            CreateMap<DrugEntity, DrugResponse>();
            CreateMap<DrugCreateRequest, DrugEntity>();
            CreateMap<DrugUpdateRequest, DrugEntity>();

            CreateMap<DrugManufacturerEntity, DrugManufacturerResponse>();
        }
    }
}
