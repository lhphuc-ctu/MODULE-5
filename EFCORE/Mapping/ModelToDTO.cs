using AutoMapper;
using EFCORE.Models;

namespace EFCORE.Mapping
{
    public class ModelToDTO : Profile
    {
        public ModelToDTO() 
        { 
            CreateMap<Province, ProvinceDTO>();

            CreateMap<District, DistrictDTO>();
        }
    }
}
