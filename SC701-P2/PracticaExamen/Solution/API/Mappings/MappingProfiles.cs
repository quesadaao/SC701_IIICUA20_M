using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DO.Objects.GroupComment, Models.GroupComment>().ReverseMap();
            CreateMap<DO.Objects.GroupUpdate, Models.GroupUpdate>().ReverseMap();
            CreateMap<DO.Objects.GroupUpdateSupport, Models.GroupUpdateSupport>().ReverseMap();
        }
    }
}
