using AutoMapper;
using EFCORE.Models;

namespace EFCORE.Mapping
{
    public class DTOToModel : Profile
    {
        public DTOToModel()
        {
            CreateMap<ProvinceDTO, Province>();

            CreateMap<DistrictDTO, District>();
        }
    }
}
